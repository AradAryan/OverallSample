using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LabResultRepository : RepositoryBase<LabResult>
    {
        public LabResultRepository(SyndromeDBEntities Context)
            : base(Context)
        {
            
        }

        public int GetAdmissionIdByLabResult(int labResultId)
        {
            return _dataContext.spGetAdmissionIdByLabResult(labResultId).FirstOrDefault().GetValueOrDefault();
        }

        public List<SpSearchLab_Result> SearchLabForLabUsers(int? skip, int? take, string university, string province, string networkId, string centerId, string labId, string startdate, string enddate, string syndromId, string National_Code, string name, string family, string paper, string primaryLabResult, string subLabId, bool showSubLabResults, bool deleted, string dateType)
        {
            return _dataContext.SpSearchLabForLabUsers(labId, university, province, networkId, centerId, startdate, enddate, syndromId, name, family, National_Code, primaryLabResult, paper, skip, take, showSubLabResults, subLabId, deleted, dateType).ToList();
        }

        public List<SpSearchLab_Result> SearchLab(int? skip, int? take, string university, string province, string networkId, string centerId, string startdate, string enddate, string syndromId, string National_Code, string name, string family, string paper, string primaryLabResult, int currentUserId, bool deleted)
        {
            return _dataContext.SpSearchLab(university, province, networkId, centerId, startdate, enddate, syndromId, name, family, National_Code, primaryLabResult, paper, skip, take, currentUserId, deleted).ToList();
        }

        public List<SpGetLabResult_Result> GetLabResult(int admissionId, int currentUserId)
        {
            return _dataContext.SpGetLabResult(admissionId, currentUserId).ToList();
        }

        public List<SpGetAdmissionLabResults_Result> GetAdmissionLabResults(int admissionId)
        {
            return _dataContext.SpGetAdmissionLabResults(admissionId).ToList();
        }

        public SpGetAdmissionLabResults_Result GetLabResults(int labResultId)
        {
            return _dataContext.SpGetLabResults(labResultId).FirstOrDefault();
        }
    }
}
