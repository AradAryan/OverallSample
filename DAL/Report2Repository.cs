using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{

    public class Report2Repository : RepositoryBase<SpGetHistoryReportHeidari_Result>
    {
        public Report2Repository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<ReportVM2> Search2(ReportVM2 filter, int skip, int take)
        {
            int totalCount = 0;
            var totalrecords = new ObjectParameter("totalRecords", 0.GetType());
            // var dbResult = _dataContext.SpGetHistoryReportHeidarii(filter.Univercity, 
            var dbResult = _dataContext.SpGetHistoryReportHeidarii("د.ع.پ شهید بهشتی",
                                                                   "بيماري شديد تنفسي",
                                                                   "تهران",
                                                                   0,
                                                                   skip,
                                                                   take,
                                                                   totalrecords)
                                                        .ToList();
            totalCount = (int)totalrecords.Value;
            List<ReportVM2> result = new List<ReportVM2>();
            foreach (var item in dbResult)
            {
                result.Add(new ReportVM2()
                {
                    province = int.Parse(item.City),
                    Row = (int)item.row,
                    syndromId = int.Parse(item.SyndromicName),
                    university = int.Parse(item.UniversityCorporateName)
                    
                });
            }
            return result;
        }
    }
}
