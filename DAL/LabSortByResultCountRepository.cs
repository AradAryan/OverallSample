using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class LabSortByResultCountRepository : RepositoryBase<spGetLabsBySampleResultCount_Result>,IDisposable
    {
        public LabSortByResultCountRepository( SyndromeDBEntities Context)
            :base(Context)
        {

        }

        public List<spGetLabsBySampleResultCount_Result> Get(string provinceId, string universityId, string networkId, string centerId, int skip, int take, int currentUserId, string startDate, string endDate)
        {
            return _dataContext.spGetLabsBySampleResultCount(provinceId, universityId, networkId, centerId, startDate, endDate, currentUserId, skip, take).ToList();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
