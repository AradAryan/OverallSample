using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabDetailResultRepository : RepositoryBase<LabDetailResult>
    {
        public LabDetailResultRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<SpGetAdmissionLabResultDetails_Result> GetAdmissionLabResultDetails(int admissionId)
        {
            return _dataContext.SpGetAdmissionLabResultDetails(admissionId).ToList();
        }

        public List<SpGetAdmissionLabResultDetails_Result> GetLabResultDetails(int labResultId)
        {
            return _dataContext.SpGetLabResultDetails(labResultId).ToList();
        }
    }
}
