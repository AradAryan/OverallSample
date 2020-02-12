using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabDiseaseAssignmentRepository : RepositoryBase<LabDiseaseAssignment>
    {
        public LabDiseaseAssignmentRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<spGetLabDiseaseAssignments_Result> GetAssignments(string labId, string syndromId, string diseaseId, string levelId, int skip, int take)
        {
            return _dataContext.spGetLabDiseaseAssignments(labId, syndromId, diseaseId, levelId, skip, take).ToList();
        }
    }
}
