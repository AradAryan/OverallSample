using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FoodRepository : RepositoryBase<ProFood>
    {
        public FoodRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
    }
}
