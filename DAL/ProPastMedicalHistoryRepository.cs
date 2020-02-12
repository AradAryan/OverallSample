using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProPastMedicalHistoryRepository : RepositoryBase<ProPastMedicalHistory>
    {
        public ProPastMedicalHistoryRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
