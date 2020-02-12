using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class VisitCountRepository : RepositoryBase<visitCount>
    {
        public VisitCountRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public List<spGetVisitHistory_Result> GetVisitHistory(int skip, int take, string startDate, string endDate, long corporateId)
        {
            return _dataContext.spGetVisitHistory(startDate, endDate, corporateId, skip, take).ToList();
        }

        public List<string> GetuserWarning(string Date)
        {
            return _dataContext.GetUserNotSendVisit(Date).ToList();
        }

        /// <summary>
        /// آیا سازمان جاری و سازمان های سطح پایین (تا یک سطح) تعداد مراجعات روز مشخص شده را وارد کرده اند یا خیر.
        /// حتی اگر یک نمونه از سازمان های زیرمجموعه تعداد بازدید را واردنکرده باشد، خروجی متد 
        /// false
        /// خواهد بود. سازمانهایی که کاربر نداشته باشند، لحاظ نخواهند شد
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool UserAndSubUsersHasEnteredVisitCount(int userId, string date)
        {
            var result = _dataContext.spUserAndSubUsersHasEnteredVisitCount(userId, date).FirstOrDefault();
            if (result == null)
                return false;
            return result.Result;
        }

        public List<KeyValuePair<long, string>> CorporatesNotEnteredVisitCount(int userId, string date)
        {
            var result = _dataContext.spGetCorporatesNotEnteredVisitCount(userId, date).ToList();
            return Mapper.Map(result);
        }

        public int CorporatesCountNotEnteredVisitCount(int userId, string date)
        {
            return _dataContext.spGetCorporatesNotEnteredVisitCount(userId, date).Count();
        }

        public List<spSearchVisits_Result> SearchVisits(string province, string university, string networkId, string centerId, string startDate, string endDate, bool missed, int skip, int take, int currentUserId)
        {
            return _dataContext.spSearchVisits(province, university, networkId, centerId, startDate, endDate, missed, skip, take, currentUserId).ToList();
        }

        public void AutoInsertMissedVisitCounts(string date)
        {
            _dataContext.spAutoInsertMissedVisitCounts(date);
        }

        public spCorporateHasVisit_Result CorporateHasVisit(int userId, int currentUserId, long centerId, string persianDate)
        {
            return _dataContext.spCorporateHasVisit(userId, currentUserId, centerId, persianDate).FirstOrDefault();
        }

        public spGetVisitByCorporateId_Result GetByCorpId(long corpId, string date)
        {
            return _dataContext.spGetVisitByCorporateId(corpId, date).FirstOrDefault();
        }

        public List<spListTotalVisits_Result> ListTotalVisitCount(BusinessModel.FilterVM filter, string startDate, string endDate)
        {
            var result = _dataContext.spListTotalVisits(filter.ProvinceId, filter.UniversityId, filter.NetworkId, filter.CenterId, startDate, endDate, filter.CurrentUserId).ToList();
            return result;
        }
    }
}
