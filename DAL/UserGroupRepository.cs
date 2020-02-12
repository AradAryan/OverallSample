using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserGroupRepository:RepositoryBase<UserGroup>
    {
        public UserGroupRepository(SyndromeDBEntities Context):base(Context)
        {

        }

    }
}
