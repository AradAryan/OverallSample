using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{

    public class ReportRepository : RepositoryBase<SpGetHistoryReportHeidari_Result>
    {
        public ReportRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<ReportVM> Search(ReportVM filter, int skip, int take,int userID ,out int totalCount)
        {
            totalCount = 0;
            var totalrecords = new ObjectParameter("totalRecords", totalCount.GetType());
            // var dbResult = _dataContext.SpGetHistoryReportHeidarii(filter.Univercity, 
            var dbResult = _dataContext.SpGetHistoryReportHeidarii(filter.Univercity, 
                                                                   filter.Syndromic, 
                                                                   filter.City, 
                                                                   userID, 
                                                                   skip, 
                                                                   take, 
                                                                   totalrecords)
                                                        .ToList();
            totalCount = (int)totalrecords.Value;
            List<ReportVM> result = new List<ReportVM>();
            foreach (var item in dbResult)
            {
                result.Add(new ReportVM()
                {
                    City = item.City,
                    Row = (int)item.row,
                    Syndromic = item.SyndromicName,
                    Univercity = item.UniversityCorporateName,
                    Count =(int) item.cntSynd
                });
            }
            return result;
        }        
    }
}
