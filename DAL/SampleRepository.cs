using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SampleRepository : RepositoryBase<Sample>
    {
        public SampleRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
