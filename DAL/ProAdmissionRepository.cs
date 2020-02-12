using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProAdmissionRepository : RepositoryBase<ProAdmission>
    {
        public ProAdmissionRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }


        public List<GetProSyndromDitailsWithIds_Result> GetProSyndromDetailsWithIds(string ids)
        {
            return _dataContext.GetProSyndromDitailsWithIds(ids).ToList();
        }

        /// <summary>
        /// گزارش روند جامع اپیدمیک ماکزیمم
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="grouping"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<spGetEpidemicMaxFlowReport_Result> GetEpidemicMaxFlowReport(BusinessModel.FilterProVM filter, CommonLib.ChartGrouping grouping, string type = "count")
        {
            setExectionTimeout(180);
            
            return _dataContext.spGetEpidemicMaxFlowReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, (filter.SyndromId ?? "").ToString(), type, filter.CurrentUserId, filter.Standing, filter.Admitted, filter.Died, filter.Positive, filter.Negative, filter.Reject, filter.NoSample, filter.AnimalTouch).ToList();
        }


        public bool IsRegister(string NationalCode, int SyndromicId, string CurrentDate)
        {
            var lst = (from m in _dataContext.SyndromRegisters
                       join s in _dataContext.Patients
                       on m.PatientID equals s.PatientID
                       where s.NationalCode == NationalCode && m.SyndromicId == SyndromicId && m.PersianDate == CurrentDate
                       select m).ToList();
            return (lst.Count == 0);

            string StrSql = string.Format("Select cast(COUNT(*) as int) CC from TblSyndromRegister a inner join TblPatient  b  on a.PatientID=b.PatientID where b.nationalcode='{0}' and a.SyndromicId={1}   and PersianDate='{2}'", NationalCode, SyndromicId, CurrentDate);
            var queryResult = _dataContext.Database.SqlQuery<int>(StrSql).ToList();
            int count = int.Parse(queryResult.FirstOrDefault().ToString());
            return (count == 0);
        }

        public ProAdmission Get(int admissionId)
        {
            return FirstOrDefault(x => x.AdmissionID == admissionId);
        }

        public BusinessModel.Statistics.MaxRespiratory GetMaxRespiratoryReport(BusinessModel.FilterVM filter)
        {
            setExectionTimeout(180);

            var dbResult = _dataContext.spGetMaxRespiratoryReport(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, filter.StartDate, filter.EndDate, filter.CurrentUserId).ToList().FirstOrDefault();
            return Mapper.Map(dbResult);
        }

        public spGetLastMaximumInfo_Result GetLastMaximumInfo(string nationalCode)
        {
            return _dataContext.spGetLastMaximumInfo(nationalCode).FirstOrDefault();
        }
    }
}
