using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DrugHistoryRepository:RepositoryBase<DrugHistory>
    {
        public DrugHistoryRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
        public void Delete(long AdmissionID)
        {
            SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
            _dataContext.Database.ExecuteSqlCommand("Delete TblDrugHistory where AdmissionID = @AdmissionID ", id);
        }
    }
}
