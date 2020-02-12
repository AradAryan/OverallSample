using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
   public class TravelRepository:RepositoryBase<Travel>
    {
       public TravelRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }
       public void Delete(long AdmissionID)
       {
           SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
           _dataContext.Database.ExecuteSqlCommand("Delete TblTravel where AdmissionID = @AdmissionID ", id);
       }
    }
}
