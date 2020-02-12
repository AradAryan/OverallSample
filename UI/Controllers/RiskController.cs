using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using UI.Models;
using DAL;

namespace UI.Controllers
{
    public class RiskController : BaseController
    {

        public ActionResult BranchUserManageRisk()
        {
            return View();
        }

        public ActionResult BranchUserCreateRisk()
        {
            return View();
        }

        public ActionResult BossViewRisk()
        {
            return View();
        }

   
        public ActionResult RiskType()
        {
            var result = new List<TellTypeItem>()
            {
                new TellTypeItem() {Id=0,Title= "انتخاب کنید"},
                new TellTypeItem() {Id=1,Title= "انجام تراکنش خارج از سطح نرمال مشتری "},
                new TellTypeItem() {Id=2,Title="حرکات مشکوک "},
                new TellTypeItem() {Id=3,Title="ارائه مدارک جعلی "},
                new TellTypeItem() {Id=4,Title="سایر"}
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetRisk( int take = 10, int skip = 0)
        {
            var bll = new RiskBLL();
            List<RiskVM> list = new List<RiskVM>();
            int total = 0;
            list = bll.SearchRisk(take, skip, out total);

            return Json(new
            {
                Data = list,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateRisk(RiskVM risk)
        {
            var bll = new RiskBLL();
            var x = bll.InsertRisk(risk);
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetRisksByCashierId(int id,int take = 10, int skip = 0)
        {
            var bll = new RiskBLL();
            List<RiskVM> list = new List<RiskVM>();
            int total = 0;
            list = bll.GetRisksByCashierId(id,take, skip, out total);

            return Json(new
            {
                Data = list,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
