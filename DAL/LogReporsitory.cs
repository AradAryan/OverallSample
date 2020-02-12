using System.Data.SqlClient;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{
    public class LogReporsitory : RepositoryBase<Log>
    {
        public LogReporsitory(SyndromeDBEntities Context)
            : base(Context)
        {

        }


        //public PegedData<LogReportModel> GetAll(int take, int skip)
        //{
        //    var model = _dataContext.Logs.OrderByDescending(x => x.DateTime).Skip(skip).Take(take).Join(_dataContext.Users, x => x.UserId, y => y.Id, (x, y) => new BusinessModel.LogReportModel() { Message = x.Message, Type = x.Type, DateTime = x.DateTime, UserName = y.FirstName+" "+y.LastName }).ToList(); 
        //   // var model = _dataContext.Logs.OrderByDescending(x => x.DateTime).Skip(skip).Take(take).ToList();
        //    BusinessModel.PegedData<LogReportModel> l = new BusinessModel.PegedData<LogReportModel>();
        //    l.Data = model;
        //    l.Total = _dataContext.Logs.Count();
        //    return l;
        //}
        public PegedData<GetLog_Result> Search(int skip, int take, string province, string university, string networkId, string centerId, string subCenterId, string fromDate, string toDate, string userName, string firstname, string lastname, string actionType, int currentUserId)
        {
            // SqlParameter takeParameter = new SqlParameter("@Take", take);
            // SqlParameter skipParameter = new SqlParameter("@Skip", skip);
            // 
            // SqlParameter provinceParameter = new SqlParameter("@Province", province != null ? province : (object)DBNull.Value);
            // 
            // SqlParameter universityParameter = new SqlParameter("@University", university != null ? university : (object)DBNull.Value);
            // SqlParameter networkParameter = new SqlParameter("@NetworkId", networkId != null ? networkId : (object)DBNull.Value);
            // SqlParameter centerParameter = new SqlParameter("@CenterId", centerId != null ? centerId : (object)DBNull.Value);
            // 
            // SqlParameter fromDateParameter = new SqlParameter("@FromDate", fromDate != null ? fromDate : (object)DBNull.Value);
            // SqlParameter toDateParameter = new SqlParameter("@ToDate", toDate != null ? toDate : (object)DBNull.Value);
            // //SqlParameter levelParameter = new SqlParameter("@Level", level != null ? level : (object)DBNull.Value);
            // SqlParameter userNameParameter = new SqlParameter("@UserName", userName != null ? userName : (object)DBNull.Value);
            // //SqlParameter ipParameter = new SqlParameter("@Ip", actionType != null ? actionType : (object)DBNull.Value);
            // SqlParameter logTypeParameter = new SqlParameter("@LogType", logType != null ? logType : (object)DBNull.Value);
            // SqlParameter totalParameter = new SqlParameter("@Total", 0);
            // totalParameter.Direction = System.Data.ParameterDirection.Output;
            // 
            // SqlParameter takeCurrentUserId = new SqlParameter("@currentUserId", currentUserId != null ? currentUserId : (object)DBNull.Value);
            // 
            // var db = new SyndromeDBEntities();
            // 
            // var result = db.Database.SqlQuery<LogReportModel>("GetLog @Take, @Skip,@Province,@University,@NetworkId,@CenterId, @currentUserId , @FromDate, @ToDate, @UserName , @LogType ,  @Total output", takeParameter, skipParameter, provinceParameter
            //     , universityParameter, networkParameter, centerParameter,takeCurrentUserId, fromDateParameter,
            //     toDateParameter, userNameParameter,
            //     totalParameter,logTypeParameter).ToList();
            // 
            // total = int.Parse(totalParameter.Value.ToString());

            var items = _dataContext.GetLog(province, university, networkId, centerId, subCenterId, currentUserId, fromDate, toDate, userName, firstname, lastname, actionType, take, skip).ToList();

            return new PegedData<GetLog_Result>()
            {
                Data = items,
                Total = items.Count == 0 ? 0 : items[0].TotalRows.GetValueOrDefault()
            };
        }
    }
}
