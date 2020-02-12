using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class MethodRepository:RepositoryBase<Method>
    {
       public MethodRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }
    }
}
