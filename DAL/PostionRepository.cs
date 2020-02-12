using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PostionRepository : RepositoryBase<Position>
    {
        public PostionRepository(SyndromeDBEntities Context)
            : base(Context)
        {
        }

        public List<spSearchPosition_Result> Search(string name, int skip, int take)
        {
            return _dataContext.spSearchPosition(name, skip, take).ToList();
        }

        public int SavePosition(BusinessModel.PositionModel entity)
        {
            return _dataContext.spSavePosition(entity.Id, entity.Name, entity.ParentId, string.Join(",", entity.Permissions.Select(x => x.Id).ToArray())).FirstOrDefault().GetValueOrDefault();
        }
    }
}
