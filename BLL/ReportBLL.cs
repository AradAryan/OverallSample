using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class ReportBLL
    {
        public List<ReportVM> Search(ReportVM filter, int skip, int take,int userID , out int totalCount)
        {
            var uow = new UnitOfWork();
             
            return uow.ReportRepository.Search(filter, skip, take,userID, out totalCount);
        }
    }
}
