using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProDrugTreatmentRepository : RepositoryBase<ProDrugTreatment>
    {
        public ProDrugTreatmentRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
