using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class Report2BLL
    {
        public List<ReportVM2> Search(ReportVM2 filter, int skip, int take)
        {
            var uow = new UnitOfWork();
            return null; 
          //  return uow.Report2Repository.Search2(filter, skip, take);
        }
    }
}
