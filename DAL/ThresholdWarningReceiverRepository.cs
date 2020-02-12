using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ThresholdWarningReceiverRepository : RepositoryBase<ThresholdWarningReceiver>
    {
        public ThresholdWarningReceiverRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
