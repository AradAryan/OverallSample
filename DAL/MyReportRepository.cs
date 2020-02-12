using BusinessModel;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace DAL
{
    public class MyReportRepository : RepositoryBase<MyReportVM>
    {
        public MyReportRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<MyReportVM> Search(MyReportVM filters,
                                    int userId,
                                    int skip, 
                                    int take, 
                                    out int totalCount)
        {
            totalCount = 0;
            var totalrecords = new ObjectParameter("totalRecords", totalCount.GetType());
            var dbResult = _dataContext.spJafari(filters.StartDate,
                                                         filters.EndDate,
                                                         filters.UniversityId != 0 ? filters.UniversityId.ToString() : "",
                                                         filters.ProvinceId != 0 ? filters.ProvinceId.ToString() : "",
                                                         filters.SyndromicId != 0 ? filters.SyndromicId.ToString() : "",
                                                         skip,
                                                         take,
                                                         filters.NetworkId != 0 ? filters.NetworkId.ToString() : "",
                                                         filters.CenterId != 0 ? filters.CenterId.ToString() : "",
                                                         userId,
                                                         totalrecords)
                                                 .ToList();
            totalCount = (int)totalrecords.Value;
            List<MyReportVM> result = new List<MyReportVM>();
            foreach (var item in dbResult)
            {
                result.Add(new MyReportVM()
                {
                    RowNumber = (int)item.Row,
                    ProvinceTitle = item.Province,
                    UniversityId = (int)item.UniversityId.GetValueOrDefault(),
                    UniversityTitle = item.UniversityName,
                    NetworkId = (int)item.NetworkId.GetValueOrDefault(),
                    NetworkTitle = item.NetworkName,
                    CenterId = (int)item.CenterId.GetValueOrDefault(),
                    CenterTitle = item.CenterName,
                    SyndromicId = item.SyndromId,
                    SyndromicTitle = item.SyndromName,
                    Count = (int)item.Cnt.GetValueOrDefault()
                });
            }
            return result;
        }
    }
}
