using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrganizationRepository : RepositoryBase<Organization>
    {
        public OrganizationRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
