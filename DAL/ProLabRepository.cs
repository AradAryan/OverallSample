using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProLabRepository : RepositoryBase<ProLab>
    {
        public ProLabRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
