using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GetPatintInfoRepository : RepositoryBase<GetPatintInfo>
    {        
        public GetPatintInfoRepository(SyndromeDBEntities context)
            : base(context)
        {

        }


    }
}
