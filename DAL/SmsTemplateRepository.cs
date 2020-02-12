using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class SmsTemplateRepository:RepositoryBase<SMSTemplate>
    {
       public SmsTemplateRepository(SyndromeDBEntities Context)
           : base(Context)
       {

       }

    }
}
