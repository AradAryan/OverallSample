using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GetDiseasesAccessRepository : RepositoryBase<DAL.SpGetDiseasesAccess_Result>,IDisposable
    {
        public GetDiseasesAccessRepository(SyndromeDBEntities context)
            : base(context)
        {

        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
