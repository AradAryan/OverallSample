using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabBasicDataRepository :RepositoryBase<LabBasicData>
    {
        public LabBasicDataRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }

        public List<spGetToxins_Result> GetToxins(int diseaseId)
        {
            return _dataContext.spGetToxins(diseaseId).ToList();
        }
    }
}
