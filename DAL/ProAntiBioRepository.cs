using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProAntiBioRepository : RepositoryBase<ProAntiBio>
    {
        public ProAntiBioRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
