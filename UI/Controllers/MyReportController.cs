using BusinessModel;
using DAL;
using Sso.UMProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class MyReportController : BaseController
    {
        //
        // GET: /MyReport/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(MyReportVM filters,
                                   int skip = 0,
                                   int take = 10)
        {
            var userId = (this.User as SsoUser).Id;
            int totalCount = 0;
            List<MyReportVM> result = new BLL.MyReportBLL().Search(filters,
                                                                   userId,
                                                                   skip,
                                                                   take,
                                                                   out totalCount);

            return Json(new
            {
                Data = result,
                Total = totalCount
            });
        }

        public ActionResult Detail(string id)
        {
            string[] data = id.Split(',');

            MyReportVM model = new MyReportVM()
            {
                CenterId = int.Parse(data[0]),
                EndDate = data[1],
                NetworkId = int.Parse(data[2]),
                ProvinceId = int.Parse(data[3]),
                StartDate = data[4],
                SyndromicId = int.Parse(data[5]),
                UniversityId = int.Parse(data[6])
            };

            return View(model);
        }

        //public ActionResult Search2(int? skip,
        //                            int? take,
        //                            string university,
        //                            string province,
        //                            string startdate,
        //                            string enddate,
        //                            string syndromId,
        //                            string National_Code,
        //                            string name,
        //                            string family,
        //                            string admissionType,
        //                            string paper,
        //                            string networkId,
        //                            string centerId,
        //                            bool deleted = false,
        //                            bool indirect = false,
        //                            bool duplicate = false)
        //{
        //    MyReportVM model = new MyReportVM();
        //    model.ProvinceTitle = province;
        //    model.UniversityTitle = university;
        //    model.StartDate = startdate;
        //    model.EndDate = enddate;
        //    model.SyndromicTitle = syndromId;
        //    model.NetworkTitle = networkId;
        //    model.CenterTitle = centerId;

        //    return View(model);
        //}

        public ActionResult Search2(int? skip,
                                    int? take,
                                    string university,
                                    string province,
                                    string startdate,
                                    string enddate,
                                    string syndromId,
                                    string National_Code,
                                    string name,
                                    string family,
                                    string admissionType,
                                    string paper,
                                    string networkId,
                                    string centerId,
                                    bool deleted = false,
                                    bool indirect = false,
                                    bool duplicate = false)
        {
            try
            {
                if (university == "0" || university == "-1")
                    university = "";
                if (province == "0" || province == "-1")
                    province = "";
                if (centerId == "0" || centerId == "-1")
                    centerId = "";
                if (networkId == "0" || networkId == "-1")
                    networkId = "";
                if (syndromId == "0" || syndromId == "-1")
                    syndromId = "";
                if (admissionType == "0" || admissionType == "-1")
                    admissionType = "";


                var lst = BLL.SyndromRegisterBLL.Search(skip, take, university, province, startdate, enddate, syndromId, admissionType, paper, networkId, centerId, deleted, indirect, duplicate , National_Code, name, family);
                //var lst = BLL.SyndromRegisterBLL.Search(skip, take, university, province, startdate, enddate, syndromId, admissionType, paper, networkId, centerId, deleted, indirect, duplicate);
                var result = new Faranam.Utils.PegedData<SpGetHistory_Result>()
                {
                    Data = lst,
                    Total = lst.Count == 0 ? 0 : lst[0].TblCount.GetValueOrDefault()
                };


                return this.Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return this.Json(e.ToString());
            }
        }
    }
}
