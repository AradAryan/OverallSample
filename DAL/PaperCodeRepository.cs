using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class PaperCodeRepository:RepositoryBase<PaperCode>
    {
       public PaperCodeRepository(SyndromeDBEntities Context):base(Context)
       {

       }

    }
}
