using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ThresholdWarningMetaDataRepository : RepositoryBase<ThresholdWarningMetaData>
    {
        public ThresholdWarningMetaDataRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

    }
}
