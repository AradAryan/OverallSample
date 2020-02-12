using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
   public class AdverseReactionRepository:RepositoryBase<AdverseReaction>
    {
       public AdverseReactionRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }

       public void Delete(long AdmissionID)
       {
           SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
           _dataContext.Database.ExecuteSqlCommand("Delete TblAdverseReaction where AdmissionID = @AdmissionID ", id);
       }
    }
}
