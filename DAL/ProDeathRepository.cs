using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProDeathRepository : RepositoryBase<ProDeath>
    {
        public ProDeathRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
