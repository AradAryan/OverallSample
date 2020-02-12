using BusinessModel;
using DAL;
using Faranam.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LabCorpController : BaseController
    {

 
        public ActionResult GetDiseases(int? syndromId)
        {
            List<Disease> data = null;
            if (syndromId.GetValueOrDefault() != 0)
                data = BLL.DiseasesBLL.GetBySyndromicId(syndromId.Value);
            else
                data = BLL.DiseasesBLL.GetAll();
            data.Insert(0, new Disease() { DiseasesName = "" });
            return Json(data.Select(x => new
            {
                x.Id,
                Name = x.DiseasesName + (syndromId.GetValueOrDefault() != 0 || string.IsNullOrEmpty(x.Comment) ? "" : " -" + x.Comment)
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Grading()
        {
            return View();
        }

        public ActionResult GetLabGrading(string province = null, string university = null, string networkId = null, string centerId = null, int skip = 0, int take = 10, string startDate = null, string endDate = null)
        {
            if (province == "0" || province == "-1")
                province = "";
            if (university == "0" || university == "-1")
                university = "";
            if (networkId == "0" || networkId == "-1")
                networkId = "";
            if (centerId == "0" || centerId == "-1")
                centerId = "";

            var result = BLL.GetLabGradingBLL.Get(province, university, networkId, centerId, skip, take, startDate, endDate);

            return Json(new 
            {
                Data = result,
                Total = result.Count == 0 ? 0 : result[0].TotalCount
            });
            
            
        }

        public ActionResult Export(string province = null, string university = null, string networkId = null, string centerId = null, int skip = 0, int take = 10, string startDate = null, string endDate = null)
        {   
            try
            {
                if (province == "0" || province == "-1")
                    province = "";
                if (university == "0" || university == "-1")
                    university = "";
                if (networkId == "0" || networkId == "-1")
                    networkId = "";
                if (centerId == "0" || centerId == "-1")
                    centerId = "";

                var result = BLL.GetLabGradingBLL.Get(province, university, networkId, centerId, skip, take, startDate, endDate);

                return exportRate(result);
            
            }
            catch (Exception e)
            {
                return this.Json(e.ToString());
            }
        }

        private ActionResult exportRate(List<spGetLabsBySampleResultCount_Result> lst)
        {
            using (var fs = new FileStream(Server.MapPath(@"~/Excel/ExportLabRate.xlsx"), FileMode.Open, FileAccess.Read))
            {
                var excel = new ExcelPackage(fs);
                var worksheet = excel.Workbook.Worksheets[1];

                int rowIndex = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    var record = lst[i];
                    rowIndex = i + 4;
                    worksheet.Cells["A" + rowIndex].Value = record.Row; // ردیف
                    worksheet.Cells["B" + rowIndex].Value = record.Name; // نام آزمایشگاه
                    worksheet.Cells["C" + rowIndex].Value = record.ProcessedCount; // تعداد نتایج ثبت شده
                }

                string filename = string.Format("syndrome-report-{0}.xlsx", CommonLib.Common.GetPersianDate(DateTime.Now).Replace('/', '-'));
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spearsheetml.sheet", filename);
            }
        }
    }
}
