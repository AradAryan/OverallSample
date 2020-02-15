using BLL;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class Exam19Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(UserVM filter, int take = 10, int skip = 0)
        {
            int total = 5;

            UserVMBLL bll = new UserVMBLL();
            var result = bll.Search(filter, take, skip, out total);
            return Json(new
            {
                Data = result,
                Total = total

            },
            JsonRequestBehavior.AllowGet);
        }

    }
}
