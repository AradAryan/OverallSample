using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class ErrorRepository:RepositoryBase<Error>
    {
       public ErrorRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }
    }
}
