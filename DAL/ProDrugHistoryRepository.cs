using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProDrugHistoryRepository : RepositoryBase<ProDrugHistory>
    {
        public ProDrugHistoryRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
