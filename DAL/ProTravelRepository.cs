using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProTravelRepository : RepositoryBase<ProTravel>
    {
        public ProTravelRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
