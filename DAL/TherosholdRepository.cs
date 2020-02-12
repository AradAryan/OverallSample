using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TherosholdRepository : RepositoryBase<Theroshold>
    {
        public TherosholdRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<GetAllThrosholds_Result> GetAllTheroShold()
        {
            return _dataContext.GetAllThrosholds().ToList();
        }

        public void DeleteTheroshold(Theroshold entity)
        {
            var theroshold = _dataContext.TblTherosholds.Single(m => m.TherosholdID == entity.TherosholdID);
            _dataContext.TblTherosholds.Remove(theroshold);
            _dataContext.SaveChanges();
        }

        public int TheroSholdCalc(long SyndromicId)
        {
            return _dataContext.TheroSholdCalc(SyndromicId).FirstOrDefault().Value;
        }


        public List<GetAbsolutValue_Result> GetTherosholdAbsolute(int syndromicId, string persianDate, int provinceId)
        {
            return _dataContext.GetAbsolutValue(syndromicId, persianDate, provinceId).ToList();
        }

        public List<spGetThresholdWarningReceivers_Result> GetTherosholdWarningSmsReceivers(long networkId)
        {
            return _dataContext.spGetThresholdWarningReceivers(networkId).ToList();
        }

        public List<spGetThresholdWarningReceivers_Managers_Result> GetTherosholdWarningSmsReceivers_Managers(long networkId)
        {
            return _dataContext.spGetThresholdWarningReceivers_Managers(networkId).ToList();
        }


        public List<GetRelativeValue_Result> GetTherosholdRelative(int syndromicId, string startpersianDate, string endpersianDate, int provinceId)
        {
            return _dataContext.GetRelativeValue(syndromicId, startpersianDate, endpersianDate, provinceId).ToList();
        }

        public decimal GetSyndromPercent(int syndromicId, string startDate, string endDate, long networkId)
        {
            return _dataContext.spThresholdGetSyndromPercent(syndromicId, startDate, endDate, networkId).Select(x => x.Result).FirstOrDefault();
        }


        public List<GetStatisticalCutoffPointValue_Result> GetStatisticalCutoffPoint(int syndromicId, string startpersianDate, string endpersianDate, int provinceId)
        {
            return _dataContext.GetStatisticalCutoffPointValue(syndromicId, startpersianDate, endpersianDate, provinceId).ToList();
        }


        public void SetAlertThroshold(int syndromicId, string persianDate, int cityId, int provinceId)
        {
            _dataContext.SetAlertThroshold(syndromicId, persianDate, cityId, provinceId);
        }


        public List<GetCusumValue_Result> GetCusumValue(int syndromicId, string startpersianDate, string endpersianDate, int provinceId)
        {
            return _dataContext.GetCusumValue(syndromicId, startpersianDate, endpersianDate, provinceId).ToList();
        }

        public List<ThresholdWarning_Result> GetAbsoluteValueWarnings(int thresholdId, string currentDate)
        {
            return _dataContext.spThresholdGetAbsoluteValueWarnings(thresholdId, currentDate).ToList();
        }

        public List<ThresholdWarning_Result> GetStatisticalCutoffPointWarnings(int thresholdId, string currentDate)
        {
            return _dataContext.spThresholdGetStatisticalCutoffPointWarnings(thresholdId, currentDate).ToList();
        }

        public List<spThresholdGetCuSumRawData_Result> GetThresholdGetCuSumRawData(int thresholdId, string currentDate)
        {
            return _dataContext.spThresholdGetCuSumRawData(thresholdId, currentDate).ToList();
        }

        public IEnumerable<spThresholdSearch_Result> Search(BusinessModel.ThresholdSearchModel filter)
        {
            return _dataContext.spThresholdSearch(
                    filter.ProvinceId == 0 ? "" : filter.ProvinceId.ToString(),
                    filter.UniversityId == 0 ? "" : filter.UniversityId.ToString(),
                    filter.NetworkId == 0 ? "" : filter.NetworkId.ToString(),
                    filter.SyndromicId == 0 ? "" : filter.SyndromicId.ToString(),
                    filter.MethodID == 0 ? "" : filter.MethodID.ToString(),
                    filter.PreProcessMethod == 0 ? "" : filter.PreProcessMethod.ToString(),
                    filter.PercentBased,
                    filter.CountBased,
                    filter.CurrentUserId,
                    filter.Skip,
                    filter.Take
            );
        }
    }
}
