using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProAntivirusRepository : RepositoryBase<ProAntiviru>
    {
        public ProAntivirusRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
