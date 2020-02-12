using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{   
    public class GetLabGradingBLL
    {
        public static List<spGetLabsBySampleResultCount_Result> Get(string provinceId, string universityId, string networkId, string centerId, int skip, int take, string startDate, string endDate)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                int currentUserId = CommonLib.Common.CurrentUser.Id;
                return unitOfWork.LabSortByResultCount(provinceId, universityId, networkId, centerId, skip, take, currentUserId, startDate, endDate);
            }
        }
    }
}
