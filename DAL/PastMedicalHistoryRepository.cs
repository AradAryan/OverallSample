using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PastMedicalHistoryRepository:RepositoryBase<PastMedicalHistory>
    {
        public PastMedicalHistoryRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
        public void Delete(long AdmissionID)
        {
            SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
            _dataContext.Database.ExecuteSqlCommand("Delete TblPastMedicalHistory where AdmissionID = @AdmissionID ", id);
        }
    }
}
