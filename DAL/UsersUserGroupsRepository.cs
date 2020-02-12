using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UsersUserGroupsRepository:RepositoryBase<UsersUserGroup>
    {
        public UsersUserGroupsRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public UsersUserGroup GetUsersUserGroupWithRelatedUserGroup(int userId)
        {
            var userGroup = _dataContext.UsersUserGroups.FirstOrDefault(x => x.UserId == userId);
            if (userGroup!=null)
            {
                _dataContext.Entry(userGroup).Reference(x => x.UserGroup).Load();
            }
            return userGroup;
        }

        public List<UsersUserGroup> GetByUserId(int userId)
        {
            return _dataContext.UsersUserGroups.Where(x => x.UserId == userId).ToList();
        }

    }
}
