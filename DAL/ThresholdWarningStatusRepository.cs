using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ThresholdWarningStatusRepository : RepositoryBase<ThresholdWarningStatu>
    {
        public ThresholdWarningStatusRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<spGetThresholdWarningStatusHistory_Result> GetStatusHistory(int thresholdWarningId)
        {
            return _dataContext.spGetThresholdWarningStatusHistory(thresholdWarningId).ToList();
        }
    }
}
