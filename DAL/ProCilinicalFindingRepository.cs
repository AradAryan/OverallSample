using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProCilinicalFindingRepository : RepositoryBase<ProClinicalFinding>
    {
        public ProCilinicalFindingRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
