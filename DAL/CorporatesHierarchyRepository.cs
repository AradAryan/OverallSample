using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CorporatesHierarchyRepository : RepositoryBase<CorporatesHierarchy>
    {
        public CorporatesHierarchyRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public CorporatesHierarchy GetByCorporateId(long corpId)
        {
            return FirstOrDefault(x => x.CorporateId == corpId);
        }

        public void UpdateCorporate(long corpId)
        {
            _dataContext.UpdateCorporateHierarchy(corpId);
        }
    }
}
