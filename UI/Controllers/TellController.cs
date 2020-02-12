using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class TellController : BaseController
    {
        //
        // GET: /Tell/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(TellVM searchData,int skip = 0 , int take = 0)
        {
            List<TellVM> result = new List<TellVM>();
            result.Add(new TellVM(){
                Id=1, 
                Firstname= "milad",
                Lastname="karami",
                Mobile = "09185889888"
            });
            result.Add(new TellVM()
            {
                Id = 2,
                Firstname = "fateme",
                Lastname = "karami",
                Mobile = "09185889888"
            });
            result.Add(new TellVM()
            {
                Id = 3,
                Firstname = "amir",
                Lastname = "karami",
                Mobile = "09185889888"
            });
            return Json(new {Data=result,Total = 3}, JsonRequestBehavior.AllowGet);
            //return json(new
            //{
            //    data = result,
            //    total = 23
            //}, jsonrequestbehavior.allowget);
        }
        public ActionResult GetTellType()
        {
            List<TellTypeItem> list = new List<TellTypeItem>();
            list.Add(new TellTypeItem { Id = 1, Title = "mobile" });
            list.Add(new TellTypeItem { Id = 2, Title = "sabet" });
            return Json(list, JsonRequestBehavior.AllowGet);

        }
    }
}
