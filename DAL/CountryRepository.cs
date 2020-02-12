using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class CountryRepository:RepositoryBase<Country>
    {
       public CountryRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }
    }
}
