using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MyReportBLL
    {
        public List<MyReportVM> Search(MyReportVM filters,
                                       int userId,
                                       int skip, 
                                       int take, 
                                       out int totalCount)
        {
            var uow = new UnitOfWork();
            return uow.MyReportRepository.Search(filters,
                                              userId,
                                              skip, 
                                              take, 
                                              out totalCount);
        }
    }
}
