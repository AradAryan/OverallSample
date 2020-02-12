using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BasicDataTypeRepository : RepositoryBase<BasicDataType>
    {
        public BasicDataTypeRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
