using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PermissionRepository : RepositoryBase<Permission>
    {
        public PermissionRepository(SyndromeDBEntities Context)
            : base(Context)
        {
        }

        public List<BusinessModel.PermissionModel> GetNonSystemPermissions()
        {
            var items = _dataContext.spGetNonSystemPermissions();
            List<BusinessModel.PermissionModel> result = new List<BusinessModel.PermissionModel>();
            foreach (var item in items)
            {
                result.Add(Mapper.Map(item));
            }
            return result;
        }

        public List<Permission> GetByPositionId(int positionId)
        {
            var items = _dataContext.spGetPermissionsByPositionId(positionId);
            List<Permission> result = new List<Permission>();
            foreach (var item in items)
            {
                result.Add(Mapper.Map(item));
            }
            return result;
        }
    }
}
