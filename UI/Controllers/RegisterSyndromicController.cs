using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Faranam.Utils;
using Sso.UMProxy;
using CommonLib;

namespace UI.Controllers
{
    public class RegisterSyndromicController : BaseController
    {
        [NeedPermission(Permission.BasicView)]
        public ActionResult Update(int Id)
        {
            string registerDate = "";
            var result = BLL.UpdateBLL.GetAdmissionDetails(Convert.ToInt32(Id), out registerDate);
            return Json(new
            {
                RegisterDate = CommonLib.Common.NormalizePersianDate(registerDate),
                result.AddressCityId,
                result.AddressProvinceId,
                result.Age,
                result.BirthCityID,
                BirthDate = CommonLib.Common.NormalizePersianDate(result.BirthDate),
                result.BirthProvinceID,
                result.CardCityID,
                result.CardProvinceID,
                result.CellPhone,
                result.Email,
                result.FirstName,
                result.FirstNameFather,
                result.FullAddress,
                result.GenderID,
                result.IdentityNo,
                result.LastName,
                result.MaritalID,
                result.MotherNationalCode,
                result.NationalCode,
                result.NationalityID,
                result.PatientID,
                result.PatientUID,
                result.PostalCode,
                result.TelPhone
            });
        }
        [NeedPermission(Permission.BasicView)]
        public ActionResult Index(int id = 0)
        {
            ViewData["AdmissionId"] = id;
            ViewData["Today"] = CommonLib.Common.NormalizePersianDate(CommonLib.Common.GetPersianDate(DateTime.Now));

            if (id == 0)
            {
                var provinceAndCity = BLL.UserBLL.GetProvinceAndCity(CommonLib.Common.CurrentUser.Id);
                ViewData["defaultProvinceId"] = provinceAndCity.ProvinceId;
                ViewData["defaultCityId"] = provinceAndCity.CityId;
                ViewData["hasNationalCode"] = false;
            }
            else
            {
                var patient = BLL.PatientBLL.GetByAdmissionId(id);
                ViewData["hasNationalCode"] = !string.IsNullOrEmpty(patient.NationalCode);
            }

            return View("SyndromicForm");
        }

        [HttpPost]
        [NeedPermission(Permission.DeleteMinimumSyndrom)]
        public ActionResult Delete(int id)
        {
            bool succeed = BLL.SyndromRegisterBLL.Delete(id);
            return Json(succeed);
        }

        [HttpPost]
        [NeedPermission(Permission.BasicView)]
        public ActionResult Retrieve(int id)
        {
            bool succeed = BLL.SyndromRegisterBLL.Retrieve(id);
            return Json(succeed);
        }

        public string SetToday(long? userId)
        {
            ViewBag.RegisterDate = CommonLib.Common.NormalizePersianDate(Common.GetPersianDate(DateTime.Now));
            var user = User as SsoUser;
            if (user == null)
            {
                RedirectToAction("Index");
                return null;
            }

            //var currentuser = user.GetSpeceficUser((int)user.Id);
            string userName = "";
            string centerName = "";
            long UserId = 0;
            var currentUser = (this.User as SsoUser);
            if (userId.HasValue)
            {
                //for other user
                DAL.User TargetUser = BLL.UserBLL.GetById((int)userId.Value);
                userName = TargetUser.FirstName + " " + TargetUser.LastName;
                UserId = userId.Value;
                //centerName = BLL.UserBLL.GetUserWithItsCorporate(UserId).Corporate.Name;
            }
            else
            {
                //for currentuser
                userName = currentUser.ShowName;
                UserId = currentUser.Id;
                //centerName = BLL.UserBLL.GetUserWithItsCorporate(UserId).Corporate.Name;
            }
            ViewBag.CurrentUser = userName;
            ViewBag.CurrentUserId = UserId;
            ViewBag.CurrentCenter = centerName;

            ViewBag.UserId = currentUser.Id;
            string Today = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    Today = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    Today = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    Today = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    Today = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    Today = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    Today = "پنج شنبه";
                    break;
                case DayOfWeek.Friday:
                    Today = "جمعه";
                    break;
            }
            return Today;
            //lblDayofweek.Text = Today;
        }

        [NeedPermission(Permission.BasicView)]
        public ActionResult GetSyndromics(bool addEmptyItem = false)
        {
            var lst = BLL.SyndromicBLL.Get().ToList();
            if (addEmptyItem)
                lst.Insert(0, new BusinessModel.SyndromicModel() { SyndromicId = 0, SyndromicName = "" });

            int[] maxSyndroms = new int[] { 2, 3, 4 };

            var result = lst.Select(x => new
            {
                x.SyndromicId,
                x.SyndromicCode,
                x.SyndromicName,
                x.TerminologyID,
                DisabledForMax = !maxSyndroms.Contains(x.SyndromicId)
            }).ToList();

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [NeedPermission(Permission.BasicView)]
        public ActionResult Select(int Id)
        {
            return this.Json("", JsonRequestBehavior.AllowGet);
        }

        // todo: check permission
        // [NeedPermission(Permission.RegisterMinimumSyndrom)]
        [HttpPost]
        [NeedPermission(Permission.BasicView)]
        public ActionResult Save(BusinessModel.PatientSyndromModel entity)
        {
            if (HasFutureDate(entity.Dates, entity.BirthDate))
                return HasFutureDateResult();
            
            try
            {
                var currentUser = (this.User as SsoUser);
                entity.UserId = currentUser.Id;
                // string CurrentDate = CommonLib.Common.GetPersianDate(DateTime.Now);
                // entity.Dates = CurrentDate;
                entity.Times = DateTime.Now;
                entity.CenterId = 1;//user.GetUserSections().First().Id;
                if (!string.IsNullOrEmpty(entity.NationalCode) && entity.AdmissionId == 0)
                {
                    // چک شود که آیا این سندرم برای این بیمار طی چند روز اخیر ثبت شده است  یا نه.
                    var checkDuplicateResult = BLL.SyndromRegisterBLL.CheckDuplicate(entity.NationalCode, entity.SyndromeId.Value);
                    if (checkDuplicateResult.Result.GetValueOrDefault())
                        return Json(new JsonResultValue(string.Format("سندرم اعلامی برای بیمار فوق، قبلا در تاریخ {0} ثبت شده است", checkDuplicateResult.LastRegisterDate), JsonResultStatus.UnhandledError));
                }

                long ID = BLL.SyndromRegisterBLL.Save(entity);
                return Json(new JsonResultValue(1, JsonResultStatus.Success));

            }
            catch (Exception ex)
            {
                return Json(new JsonResultValue(0, JsonResultStatus.HandledError));
            }
        }

        [ChildActionOnly]
        [NeedPermission(Permission.BasicView)]
        public ActionResult SyndromicForm(long? userId)
        {
            ViewBag.Today = SetToday(userId);
            return View();
        }

    }
}
