using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class WarningThresholdRepository : RepositoryBase<WarningThreshold>
    {
        public WarningThresholdRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public bool UserHasUnverifiedThresholdWarning(int userId)
        {
            return _dataContext.spUserHasUnverifiedThresholdWarning(userId).FirstOrDefault().GetValueOrDefault();
        }


        public List<WarningThrosholdDashboard_Result> WarningThrosholdDashboard(int CityId, int provinceId)
        {
            return _dataContext.WarningThrosholdDashboard(CityId, provinceId).ToList();
        }

        public IEnumerable<spSearchThresholdWarnings_Result> Search(BusinessModel.ThresholdSearchModel filter)
        {
            return _dataContext.spSearchThresholdWarnings(
                    filter.ProvinceId == 0 ? "" : filter.ProvinceId.ToString(),
                    filter.UniversityId == 0 ? "" : filter.UniversityId.ToString(),
                    filter.NetworkId == 0 ? "" : filter.NetworkId.ToString(),
                    filter.SyndromicId == 0 ? "" : filter.SyndromicId.ToString(),
                    filter.MethodID == 0 ? "" : filter.MethodID.ToString(),
                    filter.PreProcessMethod == 0 ? "" : filter.PreProcessMethod.ToString(),
                    filter.PercentBased.GetValueOrDefault(),
                    filter.CountBased,
                    filter.Skip,
                    filter.Take,
                    filter.FromDate,
                    filter.ToDate,
                    filter.WarningStatusId == 0 ? "" : filter.WarningStatusId.ToString(),
                    filter.WarningId == 0 ? "" : filter.WarningId.ToString()
            );
        }
    }
}
