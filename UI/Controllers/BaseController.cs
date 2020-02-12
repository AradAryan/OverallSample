using CommonLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{

    public class BaseController : Controller
    {

        #region جلوگیری از ثبت تاریخ های آینده

        /// <summary>
        /// آیا در پارامترهای وروردی، تاریخ وجود دارد که بعد از تاریخ امروز باشد
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        protected bool HasFutureDate(params string[] dates)
        {
            if (dates == null || dates.Length == 0)
                return false;
            foreach (var item in dates)
            {
                if (string.IsNullOrEmpty(item))
                    continue;

                string date = CommonLib.Common.NormalizePersianDate(item);
                if (Common.GetMiladiDate(date) > DateTime.Now)
                    return true;
            }
            return false;
        }

        /// <summary>نتیجه برای مواردی که تاریخ بعد از تاریخ امروز ثبت شده باشد</summary>
        /// <returns></returns>
        protected ActionResult HasFutureDateResult()
        {
            return Json(new
            {
                futureDate = true,
                message = "تاریخ ها نمیتوانند بعد از تاریخ امروز باشند"
            });
        }

        #endregion

        public ActionResult ExitProgram()
        {
            if (CommonLib.Common.CurrentUser != null)
                CommonLib.Common.CurrentUser.Logout();
            return Redirect("~");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // bool userHasEnteredYesterdaysVisitCount = BLL.VisitCountBLL.UserAndSubUsersHasEnteredYesterdaysVisitCount();
            // ViewData["dont-show-menu"] = !userHasEnteredYesterdaysVisitCount;

            base.OnActionExecuting(filterContext);
        }


        public JsonResult Error(string message, object data = null)
        {
            return Json(new
            {
                error = new
                {
                    message,
                    data
                }
            });
        }

        public JsonResult Json(bool succeed, string message)
        {
            return Json(new
            {
                succeed,
                message
            }, JsonRequestBehavior.AllowGet);
        }
    }

    public class NeedPermissionAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        readonly Permission _permission;
        public NeedPermissionAttribute(Permission permission)
        {
            _permission = permission;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // بیات: کد موقتی برای استفاده دوستان
            base.OnActionExecuting(filterContext);

            return;


            if (CommonLib.Common.CurrentUser == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                filterContext.Result = new EmptyResult();
                return;
            }
            if (CommonLib.Common.CurrentUserHasPermission(_permission))
                base.OnActionExecuting(filterContext);
            else
            {
                /*
             هدایت کاربران پس از ورود به سیستم
             * کاربران آزمایشگاه باید به صفحه آزمایشگاه هدایت شوند
             * کاربران عادی به صفحه ثبت سندرم ماکزیمم هدایت شوند
             */
                // کاربران آزمایشگاه باید به صفحه آزمایشگاه هدایت شوند
                if (CommonLib.Common.CurrentUserIsInGroup(UserRole.Lab))
                {
                    filterContext.Result = new RedirectResult(string.Format("/{0}{1}", ConfigurationManager.AppSettings["virtualDirectoryName"], ConfigurationManager.AppSettings["labUrl"]));
                    return;
                }

                FormsAuthentication.RedirectToLoginPage();
                filterContext.Result = new EmptyResult();
            }
        }
    }
}

