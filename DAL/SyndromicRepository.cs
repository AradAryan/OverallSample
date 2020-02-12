using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class SyndromicRepository:RepositoryBase<Syndromic>
    {
       public SyndromicRepository(SyndromeDBEntities Context):base(Context)
       {

       }
    }
}
