using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BasicDataRepository : RepositoryBase<BasicData>
    {
        public BasicDataRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
