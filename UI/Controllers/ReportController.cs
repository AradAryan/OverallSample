using DAL;
using Faranam.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Text;
using System.Drawing;
using Sso.UMProxy;
using OfficeOpenXml;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using BLL;

namespace UI.Controllers
{
    public class ReportController : BaseController
    {
        //
        // GET: /CP/Report/


        /// <summary>




        #region get list of university GetListOfCorporate

        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetListCorporate()
        {
            return View();

        }
        #endregion


        #region call view GetListOfCorporate
        //public ActionResult GetListOfCorporate(int? UniversityId)
        //{
        //    int a = UniversityId ?? 8803;
        //    var lst = BLL.CorporateBLL.GetListAllofPatternId(a);
        //    if (lst.Count > 0)
        //    lst.Insert(0, new DAL.Corporate() { Name = "همه موارد", Id = -1 });
        //    return this.Json(lst.Select(x => new { Id = x.Id, Title = x.Name,ParentId=x.ParentId }), JsonRequestBehavior.AllowGet);

        //}
        #endregion

        /// ////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        [NeedPermission(CommonLib.Permission.MinimumReport)]
        public ActionResult Index()
        {
          //  Faranam.Utils.Log.x.Info(TextMessages.Message(CommonLib.LogKey.ViewReportMin.ToString()), new Exception(((int)CommonLib.LogKey.ViewReportMin).ToString()));

            ViewData["hasDeleteAccess"] = CommonLib.Common.CurrentUserHasPermission(CommonLib.Permission.DeleteMinimumSyndrom) && !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.ReadOnly);
            ViewData["canFilterIndirect"] = CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Network) || CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.University);
            return View();
        }
        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult ReportPro()
        {
         //   Faranam.Utils.Log.x.Info(Faranam.Utils.TextMessages.Message(CommonLib.LogKey.ViewReportPro.ToString()), new Exception(((int)CommonLib.LogKey.ViewReportPro).ToString()));
            ViewData["hasDeleteAccess"] = CommonLib.Common.CurrentUserHasPermission(CommonLib.Permission.DeleteMaximumSyndrom) && !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.ReadOnly);
            ViewData["showHierarchy"] = !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab);
            ViewData["canFilterIndirect"] = CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Network) || CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.University);
            return View();
        }



        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetAllSyndromics(bool addEmptyItem = false)
        {
            var lst = BLL.SyndromicBLL.Get().ToList();
            if (addEmptyItem)
                lst.Insert(0, new BusinessModel.SyndromicModel() { SyndromicId = 0, SyndromicName = "" });
            return this.Json(lst.Select(x => new
            {
                Id = x.SyndromicId,
                Name = x.SyndromicName
            }).ToList(), JsonRequestBehavior.AllowGet);
        }


        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetLocation(int Areatype, bool addShowAllItems = true, bool addEmptyItem = false)
        {
            //if (!CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Admin))
            //{
            //    var userPositionHierarchy = BLL.UserBLL.GetUserPositionHierarchy((this.User as SsoUser).Id);
            //    List<object> result = new List<object>();
            //    result.Add(new { areaName = userPositionHierarchy.ProvinceName, id = userPositionHierarchy.ProvinceId });
            //    return this.Json(result, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{




            var currentUser = (this.User as SsoUser);
            var lst = new List<AreaLocation>();
            if (currentUser.CorporateList.Count == 1 || CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            {
                lst = BLL.AreaLocationBLL.GetAreLocations(Areatype);
                if (lst.Count > 0 && addShowAllItems)
                    lst.Insert(0, new DAL.AreaLocation() { areaName = addEmptyItem ? "" : "همه موارد", AreLocationID = -1 });
            }
            else
            {
                // string province;
                // using (var unitOfWork = new UnitOfWork())
                // {
                //     long corpId = currentUser.CorporateList[currentUser.CorporateList.Count - 2].Id;
                //     province = unitOfWork.CorporateRepository.Where(u => u.Id == corpId).FirstOrDefault().Provience;
                //     //v = a.AreaLocationRepository.Where(u => u.areaName == b).FirstOrDefault();
                // }
                // lst.Insert(0, new DAL.AreaLocation() { areaName = province, AreLocationID = 0 });
                var provinceAndCity = BLL.UserBLL.GetProvinceAndCity(CommonLib.Common.CurrentUser.Id);
                lst.Insert(0, new DAL.AreaLocation() { areaName = provinceAndCity.ProvinceName, AreLocationID = provinceAndCity.ProvinceId });

            }
            return this.Json(lst.Select(x => new { areaName = x.areaName, AreLocationID = x.AreLocationID }), JsonRequestBehavior.AllowGet);
            // }
        }

        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetArealocationDetail(int Areatype, int ProvinceID)
        {
            var lst = BLL.AreaLocationBLL.GetAreLocations(Areatype, ProvinceID);
            if (lst.Count > 0)
                lst.Insert(0, new DAL.AreaLocation() { areaName = "همه موارد", AreLocationID = -1 });
            return this.Json(lst.Select(x => new { areaName = x.areaName, CityID = x.AreLocationID }), JsonRequestBehavior.AllowGet);
        }


        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetProUniversity(string province, bool addShowAllItems = true, bool addEmptyItem = false)
        {
            // اگر کاربر جاری مربوط به دانشگاه است، فقط دانشگاه خودش لود شود
            //if (!CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Admin))
            //{
            //    var userPositionHierarchy = BLL.UserBLL.GetUserPositionHierarchy((this.User as SsoUser).Id);
            //    List<object> result = new List<object>();
            //    result.Add(new { Id = userPositionHierarchy.UniversityId, Name = userPositionHierarchy.UniversityName });
            //    return this.Json(result, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            var currentUser = (this.User as SsoUser);
            var lst = new List<DAL.Corporate>();
            if (currentUser.CorporateList.Count == 1 || CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            {
                lst = BLL.UniversityBLL.GetProUniversity(province);
                if (addShowAllItems)
                    lst.Insert(0, new DAL.Corporate() { Name = addEmptyItem ? "" : "همه موارد", Id = -1 });
            }
            else
            {
                lst.Insert(0, new DAL.Corporate() { Name = currentUser.CorporateList[currentUser.CorporateList.Count - 2].Name, Id = currentUser.CorporateList[currentUser.CorporateList.Count - 2].Id });
            }
            return this.Json(lst.Select(x => new
            {
                Id = x.Id,
                Name = (x.Name ?? "").Replace("دانشگاه علوم پزشکی و خدمات بهداشتی درمانی", "د.ع.پ").Replace("دانشکده علوم پزشکی و خدمات بهداشتی درمانی", "د.ع.پ")
            }), JsonRequestBehavior.AllowGet);
            //}
        }


        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetProNetwork(int? universityID, string province, bool addShowAllItems = true, bool addEmptyItem = false)
        {
            // اگر کاربر جاری مربوط به شبکه، فقط شبکه خودش لود شود
            //if (!CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.University))
            //{
            //    var userPositionHierarchy = BLL.UserBLL.GetUserPositionHierarchy((this.User as SsoUser).Id);
            //    List<object> result = new List<object>();
            //    result.Add(new { Id = userPositionHierarchy.NetworkId, Name = userPositionHierarchy.NetworkName });
            //    return this.Json(result, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            if (!universityID.HasValue)
                universityID = 0;

            var currentUser = (this.User as SsoUser);
            var lst = new List<DAL.Corporate>();
            if (CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            {
                lst = BLL.UniversityBLL.GetProNetwork(universityID.Value, province);
                if (addShowAllItems)
                    lst.Insert(0, new DAL.Corporate() { Name = addEmptyItem ? "" : "همه موارد", Id = -1 });
            }
            else if (currentUser.CorporateList.Count <= 2)
            {
                if (currentUser.CorporateList.Count == 2)
                {
                    lst = BLL.UniversityBLL.GetProNetwork(Convert.ToInt32(currentUser.CorporateList.ToArray()[0].Id), province);
                }
                else
                {
                    lst = BLL.UniversityBLL.GetProNetwork(universityID.Value, province);
                }
                if (addShowAllItems)
                    lst.Insert(0, new DAL.Corporate() { Name = addEmptyItem ? "" : "همه موارد", Id = -1 });
            }
            else
            {
                lst.Insert(0, new DAL.Corporate() { Name = currentUser.CorporateList[currentUser.CorporateList.Count - 3].Name, Id = currentUser.CorporateList[currentUser.CorporateList.Count - 3].Id });
            }
            return this.Json(lst.Select(x => new { Id = x.Id, Name = (x.Name ?? "").Replace("شبکه بهداشت و درمان شهرستان ", "") }), JsonRequestBehavior.AllowGet);
            //}
        }

        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetProCenter(string networkId, string universityId, string province, bool addShowAllItems = true, bool addEmptyItem = false)
        {
            // // اگر کاربر جاری مربوط به مرکز بهداشت است، فقط مرکز بهداشت خودش لود شود
            // //if (!CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Network))
            // //{
            // //    var userPositionHierarchy = BLL.UserBLL.GetUserPositionHierarchy((this.User as SsoUser).Id);
            // //    List<object> result = new List<object>();
            // //    result.Add(new { Id = userPositionHierarchy.CenterId, Name = userPositionHierarchy.CenterName });
            // //    return this.Json(result, JsonRequestBehavior.AllowGet);
            // //}
            // //else
            // //{
            // var currentUser = (this.User as SsoUser);
            // var lst = new List<DAL.Corporate>();
            // if (currentUser.CorporateList.Count <= 3)
            // {
            //     if (currentUser.CorporateList.Count == 3 && !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            //     {
            //         lst = BLL.UniversityBLL.GetProCenter(Convert.ToInt32(currentUser.CorporateList.ToArray()[0].Id), Convert.ToInt32(currentUser.CorporateList.ToArray()[1].Id), province);
            //     }
            //     else if (currentUser.CorporateList.Count == 2 && !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            //     {
            //         lst = BLL.UniversityBLL.GetProCenter(NetworkId, Convert.ToInt32(currentUser.CorporateList.ToArray()[0].Id), province);
            //     }
            //     else
            //     {
            //         lst = BLL.UniversityBLL.GetProCenter(NetworkId, UniversityID, province);
            //     }
            //     lst.Insert(0, new DAL.Corporate() { Name = "همه موارد", Id = -1 });
            // }
            // else
            // {
            //     lst.Insert(0, new DAL.Corporate() { Name = currentUser.CorporateList[currentUser.CorporateList.Count - 4].Name, Id = currentUser.CorporateList[currentUser.CorporateList.Count - 4].Id });
            // }
            // return this.Json(lst.Select(x => new { Id = x.Id, Name = x.Name }), JsonRequestBehavior.AllowGet);
            // //}

            if (province == "0" || province == "-1")
                province = "";
            if (universityId == "0" || universityId == "-1")
                universityId = "";
            if (networkId == "0" || networkId == "-1")
                networkId = "";

            var userCorpId = BLL.UserBLL.GetCorporateId(CommonLib.Common.CurrentUser.Id);
            var userCorp = BLL.CorporateBLL.Get(userCorpId);
            var corpType = userCorp.ClientName.ToLower();

            if (corpType == "university")
                universityId = userCorpId.ToString();
            else if (corpType == "network")
                networkId = userCorpId.ToString();

            List<spGetCenters_Result> centers = BLL.CorporateBLL.GetCenters(province, universityId, networkId, CommonLib.Common.CurrentUser.Id);
            foreach (var item in centers)
            {
                item.Name = (item.Name ?? "").Replace("مرکز بهداشتی درمانی", "م.ب.د").Replace("بیمارستان", "ب.");
            }
            if (addShowAllItems && (corpType == "network" || corpType == "university" || corpType == "ministry" || corpType == "lab"))
                centers.Insert(0, new spGetCenters_Result() { Name = addEmptyItem ? "" : "همه موارد", Id = -1 });

            return this.Json(centers, JsonRequestBehavior.AllowGet);
        }



        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult GetUniversity()
        {// اگر کاربر جاری مربوط به دانشگاه است، فقط دانشگاه خودش لود شود
            if (!CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Admin) && !CommonLib.Common.CurrentUserIsInGroup(CommonLib.UserRole.Lab))
            {
                var userPositionHierarchy = BLL.UserBLL.GetUserPositionHierarchy((this.User as SsoUser).Id);
                List<object> result = new List<object>();
                result.Add(new { Id = userPositionHierarchy.UniversityId, Name = userPositionHierarchy.UniversityName });
                return this.Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var lst = BLL.UniversityBLL.GetAll();
                if (lst.Count > 0)
                    lst.Insert(0, new DAL.University() { UniversityName = "همه موارد", UniversityID = Guid.Parse("00000000-0000-0000-0000-000000000000") });
                return this.Json(lst.Select(x => new { UniversityID = x.UniversityID, UniversityName = x.UniversityName }), JsonRequestBehavior.AllowGet);
            }
        }


        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult Search2(int? skip, int? take, string university, string province, string startdate, string enddate, string syndromId, string National_Code, string name, string family, string admissionType, string paper, string networkId, string centerId, string subCenterId, bool deleted = false, bool indirect = false, bool duplicate = false)
        {
            try
            {

                //if (university == "0")
                //    university = "";
                //if (province == "0")
                //    province = "";
                //if (centerId == "0")
                //    centerId = "";
                //if (networkId == "0")
                //    networkId = "";
                //if (syndromId == "0")
                //    syndromId = "";
                //if (admissionType == "0")
                //    admissionType = "";

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


                var lst = BLL.SyndromRegisterBLL.Search(skip, take, university, province, startdate, enddate, syndromId, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, National_Code, name, family);
                var result = new PegedData<SpGetHistory_Result>()
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
        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult Export(string university = "", string province = "", string startdate = "", string enddate = "", string syndromId = "", string National_Code = "", string name = "", string family = "", string admissionType = "", string paper = "", string networkId = "", string centerId = "", string subCenterId = "", bool deleted = false, bool indirect = false, bool duplicate = false)
        {
            try
            {
              //  Faranam.Utils.Log.x.Info(Faranam.Utils.TextMessages.Message(CommonLib.LogKey.ExportMinimum.ToString()), new Exception(((int)CommonLib.LogKey.ExportMinimum).ToString()));
                //university = (university == "-1") ? "" : university;
                //university = (university == "00000000-0000-0000-0000-000000000000") ? "" : university;
                //province = (province == "-1") ? "" : province;
                //city = (city == "-1") ? "" : city;
                if (university == "0")
                    university = "";
                if (province == "0")
                    province = "";
                if (centerId == "0")
                    centerId = "";
                if (subCenterId == "0")
                    subCenterId = "";
                if (networkId == "0")
                    networkId = "";
                if (syndromId == "0")
                    syndromId = "";
                if (admissionType == "0")
                    admissionType = "";

                var lst = BLL.SyndromRegisterBLL.Search(0, int.MaxValue, university, province, startdate, enddate, syndromId, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, National_Code, name, family);

                return exportMin(lst.ToList());
            }
            catch (Exception e)
            {
                return this.Json(e.ToString());
            }
        }

        private ActionResult exportMin(List<SpGetHistory_Result> lst)
        {
            using (var fs = new FileStream(Server.MapPath(@"~/Excel/ExportMin.xlsx"), FileMode.Open, FileAccess.Read))
            {
                var excel = new ExcelPackage(fs);
                var worksheet = excel.Workbook.Worksheets[1];

                int rowIndex = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    var record = lst[i];
                    rowIndex = i + 4;
                    worksheet.Cells["A" + rowIndex].Value = i + 1; // ردیف
                    worksheet.Cells["B" + rowIndex].Value = record.Province; // استان
                    worksheet.Cells["C" + rowIndex].Value = record.UniversityName; // دانشگاه
                    worksheet.Cells["D" + rowIndex].Value = record.NetworkName; // شبکه بهداشت
                    worksheet.Cells["E" + rowIndex].Value = record.CenterName; // بیمارستان
                    worksheet.Cells["F" + rowIndex].Value = record.UserName; // نام کاربر
                    worksheet.Cells["G" + rowIndex].Value = record.SyndromName; // نوع سندروم
                    worksheet.Cells["H" + rowIndex].Value = record.Date; // تاریخ
                    worksheet.Cells["I" + rowIndex].Value = record.PatientName; // نام بیمار
                    worksheet.Cells["J" + rowIndex].Value = record.PatientNationalCode; // کد ملی بیمار
                    worksheet.Cells["K" + rowIndex].Value = record.BirthDate; // تاریخ تولد
                    worksheet.Cells["L" + rowIndex].Value = record.Age; // سن بیمار
                    worksheet.Cells["M" + rowIndex].Value = record.CellPhone; // شماره تماس
                    worksheet.Cells["N" + rowIndex].Value = record.AdmissionType; // وضعیت بیمار
                    // worksheet.Cells["O" + rowIndex].Value = record.Gender; // وضعیت بیمار
                    // worksheet.Cells["P" + rowIndex].Value = record.Country; // کشور
                }



                // System.Drawing.Font v = new System.Drawing.Font("tahoma", 0.689F);
                // var range = (object[,])((OfficeOpenXml.ExcelRangeBase)(worksheet.Cells)).Value;
                // //var c = b[0,0];
                // for (int j = 0; j <= range.GetUpperBound(1); j++)
                // {
                //     int max = 0;
                //     for (int i = 1; i <= range.GetUpperBound(0); i++)
                //     {
                //         if (range[i, j] != null)
                //             if (TextRenderer.MeasureText(range[i, j].ToString(), v).Width > max)
                //                 max = TextRenderer.MeasureText(range[i, j].ToString(), v).Width;
                //     }
                //     worksheet.Column(j + 1).Width = max;
                // }

                string filename = string.Format("syndrome-report-{0}.xlsx", CommonLib.Common.GetPersianDate(DateTime.Now).Replace('/', '-'));
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spearsheetml.sheet", filename);
            }
        }


        public List<GetProSyndromDitails_Result> MAPPER(List<GetProSyndromDitailsWithIds_Result> model)
        {
            return model.ConvertAll(
                x => new GetProSyndromDitails_Result
                {
                    AreaNameOrNull = x.AreaNameOrNull,
                    BHOrNull = x.BHOrNull,
                    birds = x.birds,
                    CountryOrTime = x.CountryOrTime,
                    Value = x.Value,
                    vId = x.vId
                }).ToList();
        }

        public GetProSyndromDitailsPatientInformation_Result mapper(GetProSyndromDitailsPatientInformationWithIDs_Result model)
        {
            return new GetProSyndromDitailsPatientInformation_Result
            {
                AddressCityId = model.AddressCityId,
                AddressProvinceId = model.AddressProvinceId,
                AdmissionDate = model.AdmissionDate,
                AdmissionTime = model.AdmissionTime,
                AdmissionType = model.AdmissionType,
                AdmissionTypeName = model.AdmissionTypeName
            };
        }




        /// <summary>
        /// سن بیمار را به ماه بر می گرداند. بیمارانی که زیر یک سال هستند، سن آنها در اکسل در ستون مجزایی به ماه نمایش داده میشود
        /// سن بیمار با توجه به تاریخ ثبت محاسبه میشود و نه تاریخ امروز
        /// </summary>
        /// <param name="age">سن بیمار</param>
        /// <param name="birthDate">تاریخ تولد</param>
        /// <param name="registerDate">تاریخ ثبت در سیستم</param>
        /// <returns></returns>
        private object getPatientAgeInMonth(int? age, string birthDate, string registerDate)
        {
            if (age.GetValueOrDefault() == 0 && !string.IsNullOrEmpty(birthDate))
            {
                try
                {
                    DateTime birth = CommonLib.Common.GetMiladiDate(birthDate);
                    DateTime register = CommonLib.Common.GetMiladiDate(registerDate);
                    return ((register - birth).TotalDays / 30).ToString("0");
                }
                catch { }
            }
            return null;
        }

        private Dictionary<string, string> getTanExcelMapping()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("تب بالای 38 درجه", "AU");
            result.Add("لرز", "AV");
            result.Add("احساس خستگی/ضعف عمومی", "AW");
            result.Add("بدحالی", "AX");
            result.Add("سردرد", "AY");
            result.Add("درد عضلانی و کوفتگی", "AZ");
            result.Add("درد مفاصل", "BA");
            result.Add("بی اشتهایی", "BB");
            result.Add("تهوع", "BC");
            result.Add("استفراغ", "BD");
            result.Add("احساس نفخ", "BE");
            result.Add("دل درد", "BF");
            result.Add("دل پیچه(کرامپ)", "BG");
            result.Add("اسهال شل کم حجم", "BH");
            result.Add("اسهال آبکی کم حجم", "BI");
            result.Add("اسهال شل حجیم", "BJ");
            result.Add("اسهال آبکی حجیم", "BK");
            result.Add("موکوس در مدفوع", "BL");
            result.Add("مدفوع چرب", "BM");
            result.Add("بدبو بودن", "BN");
            result.Add("زورپیچ(تنسم)", "BO");
            result.Add("خشکی مخاطات", "BP");
            result.Add("کاهش تورگور پوست", "BQ");
            result.Add("کاهش اشک", "BR");
            result.Add("افت فشار واضح(خوابیده)", "BS");
            result.Add("ناتوانی در نوشیدن", "BT");
            result.Add("اختلال هشیاری", "BU");

            return result;
        }

        private Dictionary<string, string> getHadExcelMapping()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("تب بالای 38 درجه", "AU");
            result.Add("گلودرد", "AV");
            result.Add("سرفه", "AW");
            result.Add("تنگی نفس", "AX");
            result.Add("تنفس دشوار", "AY");
            result.Add("خلط خونی", "AZ");
            result.Add("احساس ناراحتی قفسه سینه", "BA");
            result.Add("افت فشار خون", "BB");
            result.Add("احساس  گیجی/سرگیجه", "BC");
            result.Add("خواب آلودگی/کما", "BD");
            result.Add("تشنج", "BE");
            result.Add("بیقراری/بالغین", "BF");
            result.Add("بیقراری در آغوش مادر", "BG");
            result.Add("تحریک پذیری کودک", "BH");
            result.Add("عدم تحرک و بازی", "BI");
            result.Add("عدم شیر نوشیدن(تهوع کودک)", "BJ");
            result.Add("درد عضلانی و کوفتگی", "BK");
            result.Add("بی اشتهایی", "BL");
            result.Add("لرز", "BM");
            result.Add("کبودی پوست", "BN");
            result.Add("درد مفاصل", "BO");
            result.Add("سردرد", "BP");
            result.Add("تهوع/استفراغ", "BQ");
            result.Add("گرفتگی بینی", "BR");
            result.Add("ابریزش بینی/عطسه", "BS");
            result.Add("قرمزی چشم", "BT");
            result.Add("اسهال", "BU");
            result.Add("عود تب و سرفه بعد از بهبود", "BV");
            return result;
        }

        private Dictionary<string, string> getFluExcelMapping()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("تب بالای 38 درجه", "AM");
            result.Add("گلودرد", "AN");
            result.Add("سرفه", "AO");
            result.Add("تنگی نفس", "AP");
            result.Add("تنفس دشوار", "AQ");
            result.Add("خلط خونی", "AR");
            result.Add("احساس ناراحتی قفسه سینه", "AS");
            result.Add("افت فشار خون", "AT");
            result.Add("احساس  گیجی/سرگیجه", "AU");
            result.Add("خواب آلودگی/کما", "AV");
            result.Add("تشنج", "AW");
            result.Add("بیقراری/بالغین", "AX");
            result.Add("بیقراری در آغوش مادر", "AY");
            result.Add("تحریک پذیری کودک", "AZ");
            result.Add("عدم تحرک و بازی", "BA");
            result.Add("عدم شیر نوشیدن(تهوع کودک)", "BB");
            result.Add("درد عضلانی و کوفتگی", "BC");
            result.Add("بی اشتهایی", "BD");
            result.Add("لرز", "BE");
            result.Add("کبودی پوست", "BF");
            result.Add("درد مفاصل", "BG");
            result.Add("سردرد", "BH");
            result.Add("تهوع/استفراغ", "BI");
            result.Add("گرفتگی بینی", "BJ");
            result.Add("ابریزش بینی/عطسه", "BK");
            result.Add("قرمزی چشم", "BL");
            result.Add("اسهال", "BM");
            result.Add("عود تب و سرفه بعد از بهبود", "BN");
            return result;
        }

        private string getCellName(Dictionary<string, string> dic, string key)
        {
            if (dic.ContainsKey(key))
                return dic[key];
            return "";
        }




        [NeedPermission(CommonLib.Permission.BasicView)]
        public ActionResult Map(string x, string y)
        {
            ViewBag.x = x;
            ViewBag.y = y;
            return View();



        }







    }
}
