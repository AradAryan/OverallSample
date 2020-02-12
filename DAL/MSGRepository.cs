using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MSGRepository : RepositoryBase<MSG>
    {
       public MSGRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }
       public void Delete(long AdmissionID)
       {
           SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
           _dataContext.Database.ExecuteSqlCommand("Delete TblMSG where AdmissionID = @AdmissionID ", id);
       }
    }
}
