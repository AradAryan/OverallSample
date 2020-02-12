using BusinessModel;
using System;
using System.Collections.Generic;
using BLL;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class CorporateController : BaseController
    {

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult search(CenterVM filter, int take = 10, int skip = 0)
        {
            if (filter.UniversityId == -1)
                filter.UniversityId = 0;
            if (filter.CenterId == -1)
                filter.CenterId = 0;
            int totalRecords = 0;
            var bll = new CenterVMBLL();
            var result = bll.Search(filter, take, skip, out totalRecords);

            return Json(new
            {
                Data = result,
                Total = totalRecords
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCorporateUsers(int id)
        {
            var bll = new CenterVMBLL();
            var corporate = bll.GetcorporateByItsCorpId(id);
            ViewBag.Corporate = $"لیست کاربران {corporate.CorporateName} - استان {corporate.Province}";
            ViewBag.CorporateID = id;
            return View();
        }


        public ActionResult NewUser(int? corporateId,int? userId)
        {
            if (corporateId.HasValue && userId.HasValue)
            {
                var bll = new CenterVMBLL();
                var corporate = bll.GetcorporateByItsCorpId(corporateId.Value);
                UserVM user = bll.GetUserById(userId.Value);
                ViewBag.CorporateName = corporate.CorporateName;
                ViewBag.CorporateId = corporateId;
                ViewBag.UserId = userId;
                return View(user);
            }
            else if (corporateId.HasValue)
            {
                var bll = new CenterVMBLL();
                var corporate = bll.GetcorporateByItsCorpId(corporateId.Value);
                UserVM user = new UserVM();
                ViewBag.CorporateName = corporate.CorporateName;
                ViewBag.CorporateId = corporateId;
                return View(user);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult GetUsers(CorporateUserVM user, int take = 10, int skip = 0)
        {
            int total = 0;
            var bll = new CenterVMBLL();
            var result = bll.GetUsersByCorpId(user.Id, user, take, skip, out total);
            return Json(new
            {
                Data = result,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
                var bll = new CenterVMBLL();

              if( bll.DeactivateUser(0, id))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Retrieve(int id)
        {
            var bll = new CenterVMBLL();

            if (bll.DeactivateUser(1, id))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetPosition()
        {
            var bll = new CenterVMBLL();
            var result = bll.GetPosition();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveUser(UserVM user)
        {
            var bll = new CenterVMBLL();
            var result = bll.InsertUser(user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}