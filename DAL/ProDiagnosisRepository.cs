using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProDiagnosisRepository : RepositoryBase<ProDiagnosi>
    {
        public ProDiagnosisRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
