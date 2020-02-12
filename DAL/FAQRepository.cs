using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FAQRepository : RepositoryBase<FAQ>
    {
        public FAQRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
