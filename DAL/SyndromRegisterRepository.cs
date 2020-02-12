using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;
using BusinessModel.Statistics;

namespace DAL
{
    public class SyndromRegisterRepository : RepositoryBase<SyndromRegister>
    {
        public SyndromRegisterRepository(SyndromeDBEntities context)
            : base(context)
        {
        }

        public List<SyndromeRegisterModel> SyndromRegisterHistory(string startdate, string enddate, string patientLikename, string UniversityId, string ProvinceId, string CityId, long centerid, string Centertypeid)
        {

            string StrSql = "SELECT TblCenter.CenterName as CenterName, Tbl_Syndromic.SyndromicName AS SyndromeName, Tbl_University.UniversityName AS universityName,  "
               + " CONVERT(VARCHAR(5),TblSyndromRegister.RegisterDateTime,108) as Times, TblSyndromRegister.SyndromRegisterId AS SyndromeRegisterId,TblSyndromRegister.AdmissionType, TblSyndromRegister.PersianDate as Dates,  "
               + " TblPatient.FirstName + ' ' + TblPatient.LastName AS PatientName, Tbl_Syndromic.SyndromicName,TblSyndromRegister.IsOutRegister, TblPatient.Age as Age,TblSyndromRegister.Latitude,TblSyndromRegister.Longitude "
               + " FROM  TblUser INNER JOIN "
              + " TblSyndromRegister INNER JOIN "
                     + " Tbl_Syndromic ON TblSyndromRegister.SyndromicId = Tbl_Syndromic.SyndromicId INNER JOIN "
                     + " TblPatient ON TblSyndromRegister.PatientID = TblPatient.PatientID ON TblUser.UserID = TblSyndromRegister.UserID INNER JOIN "
                     + " Tbl_CenterType INNER JOIN "
                     + " TblCenter ON Tbl_CenterType.CenterTypeID = TblCenter.CenterTypeID INNER JOIN "
                     + " Tbl_University ON TblCenter.UniversityID = Tbl_University.UniversityID ON TblUser.CenterID = TblCenter.CenterID   where 1=1 ";

            if (!string.IsNullOrEmpty(startdate))
                StrSql += " And  TblSyndromRegister.PersianDate >= '" + startdate + "'";

            if (!string.IsNullOrEmpty(enddate))
                StrSql += "And TblSyndromRegister.PersianDate <= '" + enddate + "'";

            if (centerid != -1)
                StrSql += " And  TblCenter.CenterId = " + centerid + " ";

            if (!string.IsNullOrEmpty(patientLikename))
                StrSql += " AND (TblPatient.FirstName + ' ' + TblPatient.LastName) LIKE N'%" + patientLikename + "%'";

            if (UniversityId != null && UniversityId != "-1")
                StrSql += " AND TblCenter.UniversityId = '" + UniversityId + "'";

            if (CityId != null && CityId != "-1" && !string.IsNullOrEmpty(CityId))
                StrSql += " AND TblCenter.CityId = '" + CityId + "'";

            if (ProvinceId != null && ProvinceId != "-1")
                StrSql += " AND TblCenter.ProvinceId = '" + ProvinceId + "'";

            if (Centertypeid != null && Centertypeid != "-1")
                StrSql += " AND TblCenter.CenterTypeId = '" + Centertypeid + "'";

            StrSql += " order by TblSyndromRegister.SyndromRegisterId desc";
            var queryResult = _dataContext.Database.SqlQuery<SyndromeRegisterModel>(StrSql).ToList();
            return queryResult;
        }

        public List<SyndromeRegisterModel> SyndromRegisterHistory(string startdate, string enddate, string University, string Province, string City)
        {
            string StrSql = string.Format("exec SpGetHistory  '{0}','{1}','{2}','{3}','{4}'", startdate, enddate, University, Province, City);
            var queryResult = _dataContext.Database.SqlQuery<SyndromeRegisterModel>(StrSql).ToList();
            return queryResult;
        }
        public IEnumerable<GetSyndromRegisterNotSepas_Result> SyndromRegisterHistory()
        {
            //string StrSql = "exec GetSyndromRegisterNotSepas";

            //var queryResult = _dataContext.Database.SqlQuery<SyndromeRegisterModel>(StrSql).ToList();
            //return queryResult;
            return _dataContext.GetSyndromRegisterNotSepas();
        }

        public List<SpGetHistoryById_Result> SyndromRegisterHistory(long userId)
        {
            return _dataContext.SpGetHistoryById(userId).ToList();
        }
         
        public spCheckIsDuplicateSyndrom_Result CheckDuplicate(string nationalCode, int syndromicId)
        {
            // var lst = (from m in _dataContext.SyndromRegisters
            //            join s in _dataContext.Patients
            //            on m.PatientID equals s.PatientID
            //            where s.NationalCode == NationalCode && m.SyndromicId == SyndromicId && m.PersianDate == CurrentDate
            //            select m).ToList();
            // return (lst.Count == 0);
            // 
            // string StrSql = string.Format("Select cast(COUNT(*) as int) CC from TblSyndromRegister a inner join TblPatient  b  on a.PatientID=b.PatientID where b.nationalcode='{0}' and a.SyndromicId={1}   and PersianDate='{2}'", NationalCode, SyndromicId, CurrentDate);
            // var queryResult = _dataContext.Database.SqlQuery<int>(StrSql).ToList();
            // int count = int.Parse(queryResult.FirstOrDefault().ToString());
            // return (count == 0);
            return _dataContext.spCheckIsDuplicateSyndrom(nationalCode, syndromicId).FirstOrDefault();
        }

        public Syndromic GetByTitle(string item)
        {
            return _dataContext.Tbl_Syndromic.FirstOrDefault(x => x.SyndromicName == item);
        }

        public bool Delete(int id)
        {
            try
            {
                Delete(x => x.SyndromRegisterId == id);
                this._dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ILISentinel GetILISentinelReport(FilterVM filter)
        {
            setExectionTimeout(110);
            var dbResult = _dataContext.spGetILISentinelReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, filter.SyndromId, filter.CurrentUserId).ToList().FirstOrDefault();
            return Mapper.Map(dbResult);
        }

        public List<Map> GetMapReport(FilterProVM filter)
        {
            setExectionTimeout(110);
            var dbResult = _dataContext.spGetMapReport(filter.StartDate, filter.EndDate, filter.SyndromId, filter.DiseaseId, filter.Type, filter.Source, filter.Standing, filter.Admitted, filter.Died, filter.Positive, filter.Negative, filter.Reject, filter.NoSample).ToList();
            return Mapper.Map(dbResult);
        }

        public List<ILIFlow> GetILIFlowReport(FilterVM filter, string type)
        {
            setExectionTimeout(110);
            var dbResult = _dataContext.spGetILIFlowReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, filter.SyndromId, type, filter.CurrentUserId).ToList();
            var result = new List<ILIFlow>();
            foreach (var item in dbResult)
            {
                result.Add(Mapper.Map(item));
            }
            return result;
        }

        /// <summary>
        /// گزارش جامع اپیدمیک مینیمم
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="grouping"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public BusinessModel.Statistics.EpidemicMin GetEpidemicMinReport(BusinessModel.FilterVM filter, CommonLib.ChartGrouping grouping, string type = "count")
        {
            //DateTime _timer = DateTime.Now;
            setExectionTimeout(180);
            //Faranam.Utils.Log.x.Warn("before running spGetEpidemicMinReport");
            var dbResult = _dataContext.spGetEpidemicMinReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, (filter.SyndromId ?? "").ToString(), type, filter.CurrentUserId).ToList().FirstOrDefault();
            //Faranam.Utils.Log.x.Warn("spGetEpidemicMinReport: " + (DateTime.Now - _timer).TotalMilliseconds);
            var syndroms = _dataContext.Tbl_Syndromic.ToList();
            //_timer = DateTime.Now;
            var result = Mapper.Map(dbResult, syndroms);
            //Faranam.Utils.Log.x.Warn("Map: " + (DateTime.Now - _timer).TotalMilliseconds);
            return result;
        }

        /// <summary>
        /// گزارش جامع اپیدمیک ماکزیمم
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="grouping"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public BusinessModel.Statistics.EpidemicMax GetEpidemicMaxReport(BusinessModel.FilterProVM filter, CommonLib.ChartGrouping grouping, string type = "count")
        {
            // DateTime _timer = DateTime.Now;
            setExectionTimeout(180);
            // Faranam.Utils.Log.x.Warn("before running spGetEpidemicMaxReport");
            var dbResult = _dataContext.spGetEpidemicMaxReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, (filter.SyndromId ?? "").ToString(), type, filter.CurrentUserId, filter.Standing, filter.Admitted, filter.Died, filter.Positive, filter.Negative, filter.Reject, filter.NoSample, filter.AnimalTouch).ToList().FirstOrDefault();
            // Faranam.Utils.Log.x.Warn("spGetEpidemicMaxReport: " + (DateTime.Now - _timer).TotalMilliseconds);
            var diseases = _dataContext.Diseases.ToList();
            // _timer = DateTime.Now;
            var result = Mapper.Map(dbResult, diseases);
            // Faranam.Utils.Log.x.Warn("Map: " + (DateTime.Now - _timer).TotalMilliseconds);
            return result;
        }

        /// <summary>
        /// گزارش روند جامع اپیدمیک مینیمم
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="grouping"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<spGetEpidemicMinFlowReport_Result> GetEpidemicMinFlowReport(BusinessModel.FilterVM filter, CommonLib.ChartGrouping grouping, string type = "count")
        {
            setExectionTimeout(180);

            //Faranam.Utils.Log.x.Warn("before running spGetEpidemicMinFlowReport");
            return _dataContext.spGetEpidemicMinFlowReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, (filter.SyndromId ?? "").ToString(), type, filter.CurrentUserId).ToList();
        }

        public List<spGetSyndromRegisterForNetwork_Result> GetSyndromPercents(long networkId, string fromDate, string toDate)
        {
            return _dataContext.spGetSyndromRegisterForNetwork(networkId, fromDate, toDate).ToList();
        }
    }
}
