using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SmslogRepository:RepositoryBase<SmsLog>
    {
        public SmslogRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<GetSMSLogs_Result> GetAll(long skip, long take, bool? IsSend, string startdate, string enddate,out int count)
        {
            count = _dataContext.GetSMSLogsCount(IsSend, startdate, enddate).First().Value;
            return _dataContext.GetSMSLogs(skip, take, IsSend, startdate, enddate).ToList();
        }

        public List<SmsLog> GetAll(long skip, long take, int UserId, out int count)
        {
            var model = _dataContext.SmsLogs.Where(x => x.UserID == UserId).ToList();
            count = model.Count;
            return model;
        }
    }
}
