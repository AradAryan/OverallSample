using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CorporateRepository : RepositoryBase<Corporate>
    {
        public CorporateRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }

        public long GetMaxId()
        {
            return _dbset.Max(x => x.Id);
        }

        public List<CenterList_BaseFieldOfView_Model> GetCenterListForRegisterUserBasedOnFieldOfView(int corporateId)
        {
            return _dataContext.GetCenterListForRegisterUserBasedOnFieldOfView("", corporateId, 100000000).ToList();
        }

        public List<SpGetLabs_Result> GetLabs(long? labId)
        {
            return _dataContext.SpGetLabs(labId).ToList();
        }

        public string GetNameById(long id)
        {
            return Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public List<spGetCenters_Result> GetCenters(string province, string universityId, string networkId, int currentUserId)
        {
            return _dataContext.spGetCenters(province, universityId, networkId, currentUserId).ToList();
        }

        public BusinessModel.ProvinceAndCity GetProvinceAndCity(long corporateId)
        {
            var item = _dataContext.spGetCorporateProvinceAndCity(corporateId).FirstOrDefault();
            return Mapper.Map(item);
        }

        public List<spSearchCorp_Result> Search(string province, string university, string networkId, string centerId, string name, string guid, int skip, int take, int currentUserId, bool showLabs)
        {
            return _dataContext.spSearchCorp(province, university, networkId, centerId, name, guid, skip, take, currentUserId, showLabs).ToList();
        }

        public List<spSearchCorp_Result> Search(int province, long university, long networkId, long centerId, string name, string guid, int skip, int take, int currentUserId, bool showLabs)
        {
            if (!string.IsNullOrEmpty(guid) && Guid.Parse(guid) == Guid.Empty)
                guid = "";

            return _dataContext.spSearchCorp(province <= 0 ? "" : province.ToString(), university <= 0 ? "" : university.ToString(), networkId <= 0 ? "" : networkId.ToString(), centerId <= 0 ? "" : centerId.ToString(), name, guid, skip, take, currentUserId, showLabs).ToList();
        }

        public List<spGetCorpTypesWithTheSameLevel_Result> GetCorpTypesWithTheSameLevel(BusinessModel.CorpTypeCode corpType)
        {
            return _dataContext.spGetCorpTypesWithTheSameLevel((int)corpType).ToList();
        }

        public int GetCorpType(long id)
        {
            return _dataContext.spGetCorpType(id).FirstOrDefault().GetValueOrDefault();
        }

        public Corporate GetByUserId(int userId)
        {
            long corpId = _dataContext.Users.Where(x => x.Id == userId).Select(x => x.CorporateId).FirstOrDefault();
            return _dataContext.Corporates.FirstOrDefault(x => x.Id == corpId);
        }

        public List<spGetNetworkLabs_Result> GetNetworkLabs(long labId, int currentUserId)
        {
            return _dataContext.spGetNetworkLabs(labId, currentUserId).ToList();
        }

        public List<spGetCenterLabs_Result> GetCenterLabs(long labId, long networkId, int currentUserId)
        {
            return _dataContext.spGetCenterLabs(labId, networkId, currentUserId).ToList();
        }

        public List<spGetProvinceUniversities_Result> GetProvinceUniversities(int provinceId, int currentUserId)
        {
            return _dataContext.spGetProvinceUniversities(provinceId, currentUserId).ToList();
        }

        public List<spGetSubLabs_Result> GetSubLabs(long labId)
        {
            return _dataContext.spGetSubLabs(labId).ToList();
        }
    }
}
