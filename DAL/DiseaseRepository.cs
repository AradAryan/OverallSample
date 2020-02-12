using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DiseaseRepository : RepositoryBase<DAL.Disease>
    {
        public DiseaseRepository(SyndromeDBEntities context)
            : base(context)
        {

        }

        public Disease GetByName(string item)
        {
            return _dataContext.Diseases.FirstOrDefault(x => x.DiseasesName == item);
        }

        public List<Disease> GetLabSupportedDiseases(int syndromId, int userId)
        {
            var dbItems = _dataContext.spGetLabSupportedDiseases(syndromId, userId).ToList();
            return Mapper.Map(dbItems);
        }
    }
}
