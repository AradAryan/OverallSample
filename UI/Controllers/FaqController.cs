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
    public class FaqController : BaseController
    {

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
                list = bll.GetFaq();
                ViewBag.SystemName = " تمامی سامانه ها";
            }

            return View(list);
        }

        public ActionResult Managment()
        {
            return View();
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

        public ActionResult GetActivityState()
        {
            var result = new List<TellTypeItem>()
            {
                new TellTypeItem() {Id=0,Title= "غیرفعال"},
                new TellTypeItem() {Id=1,Title="فعال"}

            };
            return Json(result, JsonRequestBehavior.AllowGet);
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



        public ActionResult GetFaqStatistics()
        {
            var bll = new TestFaqBLL();
            var status = bll.GetFaqStatics();
            var list = new List<FaqStatisticsVM>();
            var gpd = status.GroupBy(m => m.SystemId)
                .Select(g => new { Id = g.Key, Count = g.Count(), Items = g.ToList() })
                .OrderByDescending(m => m.Count).ToList();
            foreach (var item in gpd)
            {
                var x = new FaqStatisticsVM();
                x.Id = item.Id;
                x.Count = item.Count;
                //foreach(var i in item.Items){
                //    var y = new FaqStatsVM() {
                //        id = i.id,
                //        SystemId = i.SystemId,
                //        UserId = i.UserId,
                //        Ip_Port = i.Ip_Port,
                //        SeenTime = i.SeenTime
                //    };
                //    x.Statistics.Add(y);
                //}
                list.Add(x);
            }
            return View(list);
        }

        public ActionResult FaqViews(int id)
        {
            var bll = new TestFaqBLL();
            var status = bll.GetFaqStatics();
            var list = new List<FaqStatsVM>();
            var x = status.Where(i => i.SystemId == id).ToList();
            var l = x.Select((r, i) => new { Row = r, Index = i }).ToList();
            foreach (var i in l)
            {
                list.Add(new FaqStatsVM
                {
                    id = i.Row.id,
                    SystemId = i.Row.SystemId,
                    UserId = i.Row.UserId,
                    Ip_Port = i.Row.Ip_Port,
                    SeenTime = i.Row.SeenTime,
                    Row = i.Index + 1
                });
            }
            return View(list);

            //var gpd = status.GroupBy(m => m.SystemId)
            //    .Select(g => new { Id = g.Key, Count = g.Count(), Items = g.ToList() })
            //    .Select((r, i) => new { Row = r, Index = i })
            //    .Where(m => m.Row.Id==id)
            //    .OrderByDescending(m => m.Row.Items.Count).ToList();
            //foreach (var item in gpd)
            //{
            //    var x = new FaqStatisticsVM();
            //    x.Id = item.Row.Id;
            //    x.Row = item.Index;
            //    x.Count = item.Row.Count;
            //    foreach (var i in item.Row.Items)
            //    {
            //        var y = new FaqStatsVM()
            //        {
            //            id = i.id,
            //            SystemId = i.SystemId,
            //            UserId = i.UserId,
            //            Ip_Port = i.Ip_Port,
            //            SeenTime = i.SeenTime
            //        };
            //        x.Statistics.Add(y);
            //    }
            //    list.Add(x);
        }

        public void GetExcel()
        {
            //--Creating the list of Views-----------------------
            var bll = new TestFaqBLL();
            var status = bll.GetFaqStatics();
            var list = new List<FaqStatsVM>();
            var x = status.ToList();
            var l = x.Select((r, i) => new { Row = r, Index = i }).ToList();
            foreach (var i in l)
            {
                list.Add(new FaqStatsVM
                {
                    id = i.Row.id,
                    SystemId = i.Row.SystemId,
                    UserId = i.Row.UserId,
                    Ip_Port = i.Row.Ip_Port,
                    SeenTime = i.Row.SeenTime,
                    Row = i.Index + 1
                });
            }

            //--Creating the excel file in the server HardDrive-----------------------------
            var initialexcelfile = Server.MapPath("~/ApplicationOutputs/NumberOfViews.xlsx");
            using (FileStream stream = new FileStream(initialexcelfile, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage excel = new ExcelPackage(stream);
                var worksheet = excel.Workbook.Worksheets[1];
                int row = 0;
                row++;
                int col = 0;
                col++;
                worksheet.Cells[row, col].Value = "ردیف";
                col++;
                worksheet.Cells[row, col].Value = "نام سامانه";
                col++;
                worksheet.Cells[row, col].Value = "مشخصات بازدید";
                col++;
                worksheet.Cells[row, col].Value = "زمان بازدید";

                foreach (var line in list)
                {
                    row++;
                    col = 0;
                    col++;
                    worksheet.Cells[row, col].Value = line.Row;
                    col++;
                    worksheet.Cells[row, col].Value = line.SystemName;
                    col++;
                    worksheet.Cells[row, col].Value = line.Ip_Port;
                    col++;
                    worksheet.Cells[row, col].Value = line.SeenTime;

                }

                var resultexcelfile = Server.MapPath("~/ApplicationOutputs/NumberOfViewsResult.xlsx");
                System.IO.File.WriteAllBytes(resultexcelfile, excel.GetAsByteArray());

            }


            //--Creating Response for client to prepare Download-------------------------
            string filename = Server.MapPath("~/ApplicationOutputs/NumberOfViewsResult.xlsx");
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }
    }
}
