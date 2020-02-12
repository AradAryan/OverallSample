using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserCorporatesHierarchyRepository : RepositoryBase<UserCorporatesHierarchy>
    {
        public UserCorporatesHierarchyRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public UserCorporatesHierarchy GetByUserId(int userId)
        {
            return FirstOrDefault(x => x.UserId == userId);
        }

        public string GetUserCorporateName(int id)
        {
            var data = GetByUserId(id);
            if (!string.IsNullOrEmpty(data.CenterCorporateName))
                return data.CenterCorporateName;
            if (!string.IsNullOrEmpty(data.NetworkCorporateName))
                return data.NetworkCorporateName;
            if (!string.IsNullOrEmpty(data.UniversityCorporateName))
                return data.UniversityCorporateName;
            return "وزارت بهداشت";
        }
    }
}
