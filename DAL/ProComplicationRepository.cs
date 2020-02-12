using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProComplicationRepository : RepositoryBase<ProComplication>
    {
        public ProComplicationRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
