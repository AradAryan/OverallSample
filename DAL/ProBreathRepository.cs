using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProBreathRepository : RepositoryBase<ProBreath>
    {
        public ProBreathRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
