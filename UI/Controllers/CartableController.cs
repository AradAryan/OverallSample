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
    public class CartableController : BaseController
    {

        public ActionResult BranchUserManageLoan()
        {
            return View();
        }

        public ActionResult BranchUserCreateLoan()
        {
            return View();
        }

        public ActionResult BossManageLoan()
        {
            return View();
        }

        public ActionResult EtebariManageLoan()
        {
            return View();
        }

        public ActionResult MaaliManageLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgreedByBoss(int loanId)
        {
            var bll = new LoanBLL();
            var x = bll.EditBoss(loanId, true);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RejectedByBoss(int loanId)
        {
            var bll = new LoanBLL();

            var x = bll.EditBoss(loanId, false);
            return Json(x, JsonRequestBehavior.AllowGet);

        }





        public ActionResult AgreedByEtebariUser(int loanId , string tozihat)
        {
            var bll = new LoanBLL();
            var x = bll.EditEtebari(loanId , tozihat , true);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RejectedByEtebariUser(int loanId, string tozihat)
        {
            var bll = new LoanBLL();

            var x = bll.EditEtebari(loanId, tozihat, false);
            return Json(x, JsonRequestBehavior.AllowGet);

        }




        public ActionResult AgreedByMaaliUser(int loanId, string tozihat)
        {
            var bll = new LoanBLL();
            var x = bll.EditMaali(loanId, tozihat, true);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RejectedByMaaliUser(int loanId, string tozihat)
        {
            var bll = new LoanBLL();

            var x = bll.EditMaali(loanId, tozihat, false);
            return Json(x, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetLoansForEtebariUser(LoanVM loan, int take = 10, int skip = 0)
        {
            var bll = new LoanBLL();
            List<LoanVM> list = new List<LoanVM>();
            int total = 0;
            list = bll.SearchLoanForEtebariUser(loan, take, skip, out total);

            return Json(new
            {
                Data = list,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SearchClient(ClientVM client)
        {
            var bll = new LoanBLL();
            var x = bll.SearchClient(client);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoanType()
        {
            var result = new List<TellTypeItem>()
            {
                new TellTypeItem() {Id=0,Title= "انتخاب کنید"},
                new TellTypeItem() {Id=1,Title= "وام مسکن"},
                new TellTypeItem() {Id=2,Title="وام خرید خودرو"},
                new TellTypeItem() {Id=3,Title="وام خرید لوازم خانگی ایرانی"},
                new TellTypeItem() {Id=4,Title="وام ضروری"},
                new TellTypeItem() {Id=5,Title="وام جعاله"}

            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetLoans(LoanVM loan, int take = 10, int skip = 0)
        {
            var bll = new LoanBLL();
            List<LoanVM> list = new List<LoanVM>();
            int total = 0;
            list = bll.SearchLoan(loan, take, skip, out total);

            return Json(new
            {
                Data = list,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateLoan(LoanVM loan)
        {
            var bll = new LoanBLL();
            var x = bll.InsertLoan(loan);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchFaq(FaqVM faq, int take = 10, int skip = 0)
        {
            List<FaqVM> list = new List<FaqVM>();
            int total = 0;
            var bll = new TestFaqBLL();
            list = bll.SearchFaq(faq, take, skip, out total).ToList();

            return Json(new
            {
                Data = list,
                Total = total
            }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult GetSamane()
        {
            var result = new List<TellTypeItem>()
            {
                 new TellTypeItem() {Id=0,Title= "همه موارد"},
                new TellTypeItem() {Id=1,Title= "وزارت بهداشت"},
                new TellTypeItem() {Id=2,Title="بانک آینده"},
                new TellTypeItem() {Id=3,Title="بانک ملت"}



            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult InsertFaq(FaqVM faq)
        {
            var bll = new TestFaqBLL();

            var boolian = bll.InsertFaq(faq);
            return Json(boolian, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult DeleteFaq(int id)
        {
            var bll = new TestFaqBLL();
            var result = bll.DeleteFaq(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivateFaq(int id)
        {
            var bll = new TestFaqBLL();
            var result = bll.ActivateFaq(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeactivateFaq(int id)
        {
            var bll = new TestFaqBLL();
            var result = bll.UnactivateFaq(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PostImg()
        {

            try
            {
                var httpRequest = HttpContext.Request;
                var postedFile = httpRequest.Files[0];
                Guid name = Guid.NewGuid();
                string path = HttpContext.Server.MapPath("~/FaqImgUploads/" + name + ".jpg");
                postedFile.SaveAs(path);

                return Json(new
                {
                    Result = true,
                    Name = name
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new
                {
                    Result = false,
                    Name = ""
                }, JsonRequestBehavior.AllowGet);
            }

        }


    }
}
