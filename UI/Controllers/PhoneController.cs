using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class PhoneController : BaseController
    {
        
      //   GET: /Phone/

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Edit(int id)
        //{
        //    var model = new BLL.PhoneBLL().Get(id);
        //    return View(model);
        //}

        public ActionResult GetPhoneTypes()
        {
            List<PhoneTypeItem> items = new List<PhoneTypeItem>();
            items.Add(new PhoneTypeItem()
            {
                Id = 40,
                Title = "موبایل"
            });
            items.Add(new PhoneTypeItem()
            {
                Id = 41,
                Title = "تلفن ثابت"
            });
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletePhone(int id)
        {
            // todo: delete data from database
            return Json(true);
        }

        //[HttpPost]
        //public ActionResult Save(PhoneVM model)
        //{
        //    bool result = new BLL.PhoneBLL().Save(model);
        //    return Json(true);
        //}

        //[HttpPost]
        //public ActionResult Search(PhoneVM searchData, int skip = 0, int take = 10)
        //{
        //    int totalCount = 0;
        //    List<PhoneVM> result = new BLL.PhoneBLL().Search(searchData, skip, take, out totalCount);
        //    return Json(new
        //    {
        //        Data = result,
        //        Total = totalCount
        //    });
        //    List<PhoneVM> result = new List<PhoneVM>();
        //    result.Add(new PhoneVM()
        //    {
        //        Id = 10,
        //        Firstname = "علی",
        //        Lastname = "علوی",
        //        Mobile = "4563456"
        //    });
        //    result.Add(new PhoneVM()
        //    {
        //        Id = 11,
        //        Firstname = "آناهیتا",
        //        Lastname = "رحیمی",
        //        Mobile = "34563456345"
        //    });
        //    result.Add(new PhoneVM()
        //    {
        //        Id = 12,
        //        Firstname = "آذر",
        //        Lastname = "نوبخت",
        //        Mobile = "65345632563"
        //    });

        //    return Json(new
        //    {
        //        Data = result,
        //        Total = 23
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}
