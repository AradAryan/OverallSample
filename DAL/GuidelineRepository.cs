using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GuidelineRepository:RepositoryBase<Guideline>
    {
        public GuidelineRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
