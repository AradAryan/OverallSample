using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using UI.Models;
using CommonLib;
using DAL;
using System.IO;
using OfficeOpenXml;
namespace UI.Controllers
{
    public class Exam21Controller : Controller
    {
        public FAQDBEntities FAQDB = new FAQDBEntities();
        private bool loading = false;
        //
        // GET: /Exam21/
        public ActionResult Index(int? systemId)
        {

            var user = Common.CurrentUser;

            List<FaqVM> list = new List<FaqVM>();
            var bll = new TestFaqBLL();

            //-----------for inserting the statisics of view ------------------
            if (systemId.HasValue)
            {
                var sessionId = HttpContext.Session.SessionID;
                var state = new FaqStatistic();
                state.Ip_Port = sessionId;
                state.SeenTime = DateTime.Now;
                state.SystemId = systemId.Value;
                var x = bll.InsertFaqState(state);
            }
            //-----------------------------

            if (systemId.HasValue)
            {
                list = bll.GetFaqByID(systemId.Value);
                if (list.FirstOrDefault().SystemId == 1)
                {
                    ViewBag.SystemName = "وزارت بهداشت";
                }
                else if (list.FirstOrDefault().SystemId == 2)
                {
                    ViewBag.SystemName = "بانک آینده";
                }
                else
                {
                    ViewBag.SystemName = "بانک ملت";
                }
            }
            else
            {

                // list = bll.GetFaq();
                var temp = FAQDB.SP_GetActiveFields().ToList();
                foreach (var item in temp)
                {
                    list.Add(new FaqVM
                    {
                        Id = item.SystemID,
                        AnswerText = item.AnswerText,
                        Enabled = item.Enabled,
                        ImageFileName = item.ImageFileName,
                        QustionText = item.QuestionText,
                        SystemId = item.SystemID,
                    });
                }
                ViewBag.SystemName = " تمامی سامانه ها";
            }

            return View(list);
            // return View();
        }

        public ActionResult Managment()
        {
            return View();
        }

        public ActionResult SearchFaq(FaqVM faq, int take = 10, int skip = 0)
        {
            List<FaqVM> list = new List<FaqVM>();
            if (!loading)
            {
                var temp = FAQDB.SP_GetAllFields().ToList();
                foreach (var item in temp)
                {
                    list.Add(new FaqVM
                    {
                        Id = item.SystemID,
                        AnswerText = item.AnswerText,
                        Enabled = item.Enabled,
                        ImageFileName = item.ImageFileName,
                        QustionText = item.QuestionText,
                        SystemId = item.SystemID,
                    });
                }
            }

            return Json(new
            {
                Data = list,
                Total = list.Count,
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}
