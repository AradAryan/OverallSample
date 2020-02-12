using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class subSystemRepository : RepositoryBase<Subsystem>
    {
       public subSystemRepository(SyndromeDBEntities Context)
           : base(Context)
        {

        }
    }
}
