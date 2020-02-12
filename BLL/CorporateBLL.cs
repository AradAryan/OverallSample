using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BusinessModel;
namespace BLL
{
    public class CorporateBLL
    {
        public static Corporate Get(long ID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.GetById(ID);
            }
        }

        #region getListOf university
        public static List<Corporate> GetListAllofPatternId(int i)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.Where(x => x.ParentId == i).ToList();
            }
        }
        #endregion


        public static List<Corporate> GetAllStructuralCorporat()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.GetAll().ToList();
            }
        }

        public static List<Corporate> GetAll_NotStructuralCorporatBaseOnUniversiy_Province_City(Guid? Universiy, int? Province, int? City)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.Where(x =>
                    (!Universiy.HasValue) &&
                    (!Province.HasValue) &&
                    (!City.HasValue)
                    ).ToList();
            }
        }

        public static List<CenterList_BaseFieldOfView_Model> GetCenterListForRegisterUserBasedOnFieldOfView(Guid? Universiy, int? Province, int? City, int CorporateId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.GetCenterListForRegisterUserBasedOnFieldOfView(CorporateId)
                    .Where(x =>
                        // (!Universiy.HasValue || x.UniversityId == Universiy) &&
                    (!Province.HasValue || x.ProvinceId == Province) &&
                    (!City.HasValue || x.CityId == City)).ToList();
            }
        }

        public static List<Corporate> GetAll_ContainText(string word, int take)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.GetMany(x => x.Name.Contains(word)).Take(take).ToList();
            }
        }

        public static void Update(Corporate s)
        {
            //using (UnitOfWork unitOfWork = new UnitOfWork())
            //{
            //    Corporate co = unitOfWork.CorporateRepository.GetById(s.Id);
            //    co.CenterTypeId = s.CenterTypeId;
            //    co.Name = s.Name;
            //    co.Code = s.Code;
            //    co.EnName = s.EnName;
            //    co.Description = s.Description;
            //    co.FullAddress = s.FullAddress;
            //    co.PostalCode = s.PostalCode;
            //    co.ProvinceId = s.ProvinceId;
            //    co.CityId = s.CityId;
            //    co.UniversityId = s.UniversityId;
            //    co.Code = "Not_Code";
            //    unitOfWork.Save();
            //}
        }

        public static long GetMaxId()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.CorporateRepository.GetMaxId();
            }
        }

        public static void Add(Corporate s)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CorporateRepository.Add(s);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<SpGetLabs_Result> GetLabs()
        {
            var currentUser = CommonLib.Common.CurrentUser;
            long? labId = null;
            if (currentUser.IsInGroup("lab"))
            {
                labId = currentUser.CorporateList[0].Id;
            }
            using (UnitOfWork u = new UnitOfWork())
            {
                return u.CorporateRepository.GetLabs(labId);
            }
        }

        public static string GetName(long id)
        {
            using (UnitOfWork u = new UnitOfWork())
            {
                return u.CorporateRepository.GetNameById(id);
            }
        }

        public static System.Collections.Generic.List<spGetCenters_Result> GetCenters(string province, string universityId, string networkId, int currentUserId)
        {
            using (UnitOfWork u = new UnitOfWork())
            {
                return u.CorporateRepository.GetCenters(province, universityId, networkId, currentUserId);
            }
        }

        public static ProvinceAndCity GetProvinceAndCity(long corporateId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.GetProvinceAndCity(corporateId);
            }
        }

        public static List<spSearchCorp_Result> Search(string province, string university, string networkId, string centerId, string name, string guid, int skip, int take, bool showLabs)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.Search(province, university, networkId, centerId, name, guid, skip, take, CommonLib.Common.CurrentUser.Id, showLabs);
            }
        }

        public static LabCorporateModel SaveLab(LabCorporateModel lab)
        {
            if (lab.CenterId == -1)
                lab.CenterId = 0;
            if (lab.NetworkId == -1)
                lab.NetworkId = 0;
            if (lab.UniversityId == -1)
                lab.UniversityId = 0;

            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                fillMissedHierarchy(lab, unitofwork);
                Corporate corp = null;
                if (lab.CorporateId == 0)
                {
                    lab.CorporateId = unitofwork.CorporateRepository.GetMaxId() + 1;
                    corp = Mapper.Map(lab);
                    unitofwork.CorporateRepository.Add(corp);
                }
                else
                {
                    corp = unitofwork.CorporateRepository.GetById(lab.CorporateId);
                    corp.Name = lab.CorporateName;

                    if (lab.CenterId != 0)
                        corp.ParentId = lab.CenterId;
                    else if (lab.NetworkId != 0)
                        corp.ParentId = lab.NetworkId;
                    else if (lab.UniversityId != 0)
                        corp.ParentId = lab.UniversityId;

                    corp.EnName = lab.CorporateGuid;
                }

                unitofwork.Save();
                unitofwork.CorporatesHierarchyRepository.UpdateCorporate(corp.Id);

                return Mapper.Map(corp);
            }


        }

        private static void fillMissedHierarchy(LabCorporateModel lab, UnitOfWork unitofwork)
        {
            if (lab.CenterId != 0)
            {
                var hierarchy = unitofwork.CorporatesHierarchyRepository.GetByCorporateId(lab.CenterId);
                lab.NetworkId = hierarchy.NetworkCorporateId.GetValueOrDefault();
                lab.UniversityId = hierarchy.UniversityCorporateId.GetValueOrDefault();
                lab.ProvinceId = unitofwork.AreaLocationRepository.GetProvinceId(hierarchy.Province);
                lab.ProvinceName = hierarchy.Province;
            }
            else if (lab.NetworkId != 0)
            {
                var hierarchy = unitofwork.CorporatesHierarchyRepository.GetByCorporateId(lab.NetworkId);
                lab.UniversityId = hierarchy.UniversityCorporateId.GetValueOrDefault();
                lab.ProvinceId = unitofwork.AreaLocationRepository.GetProvinceId(hierarchy.Province);
                lab.ProvinceName = hierarchy.Province;
            }
            else if (lab.UniversityId != 0)
            {
                var hierarchy = unitofwork.CorporatesHierarchyRepository.GetByCorporateId(lab.UniversityId);
                lab.ProvinceId = unitofwork.AreaLocationRepository.GetProvinceId(hierarchy.Province);
                lab.ProvinceName = hierarchy.Province;
            }
        }

        public static CorporatesHierarchy GetHierarchy(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporatesHierarchyRepository.GetByCorporateId(id);
            }
        }

        public static LabCorporateModel GetLabCorporateModel(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var hierarchy = unitofwork.CorporatesHierarchyRepository.GetByCorporateId(id);
                if (hierarchy == null)
                    return null;
                var corp = Get(id);

                return new LabCorporateModel()
                {
                    CenterId = hierarchy.CenterCorporateId.GetValueOrDefault(),
                    CenterName = hierarchy.CenterCorporateName,
                    CorporateId = hierarchy.CorporateId,
                    NetworkId = hierarchy.NetworkCorporateId.GetValueOrDefault(),
                    NetworkName = hierarchy.NetworkCorporateName,
                    ProvinceName = hierarchy.Province,
                    ProvinceId = unitofwork.AreaLocationRepository.GetProvinceId(corp.Provience),
                    UniversityId = hierarchy.UniversityCorporateId.GetValueOrDefault(),
                    UniversityName = hierarchy.UniversityCorporateName,
                    CorporateGuid = corp.EnName,
                    CorporateName = corp.Name
                };
            }
        }

        public static DAL.Corporate GetUniversity(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && x.ClientName == "University");
            }
        }

        public static DAL.Corporate GetSubCenter(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && (x.ClientName == "kh-b"));
            }
        }

        public static DAL.Corporate GetCenter(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && (x.ClientName == "bimarestan" || x.ClientName == "a"));
            }
        }

        public static DAL.Corporate GetNetwork(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && x.ClientName == "Network");
            }
        }

        public static BusinessModel.CorporateModel GetUniversityModel(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var model = unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && x.ClientName == "University");
                return Mapper.MapCorp(model);
            }
        }

        public static BusinessModel.CorporateModel GetSubCenterModel(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var model = unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id /* && (x.ClientName == "kh-b")*/);
                return Mapper.MapCorp(model);
            }
        }

        public static BusinessModel.CorporateModel GetCenterModel(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var model = unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id /* && (x.ClientName == "bimarestan" || x.ClientName == "a") */);
                return Mapper.MapCorp(model);
            }
        }

        public static BusinessModel.CorporateModel GetNetworkModel(long id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var model = unitofwork.CorporateRepository.FirstOrDefault(x => x.Id == id && x.ClientName == "Network");
                return Mapper.MapCorp(model);
            }
        }

        private static long getParentId(long universityId, long networkId, long centerId)
        {
            if (centerId != 0)
                return centerId;
            if (networkId != 0)
                return networkId;
            if (universityId != 0)
                return universityId;
            return new UnitOfWork().CorporateRepository.FirstOrDefault(x => x.ClientName == "Ministry").Id;
        }

        private static string getCityName(int provinceId, long universityId, long networkId, long centerId, long subCenterId)
        {
            // todo: پیاده سازی این متد
            return "";
        }

        public static SearchResult<spSearchCorp_Result> Search(CorporateModel searchParams, int skip, int take)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var items = uow.CorporateRepository.Search(searchParams.ProvinceId, searchParams.UniversityId, searchParams.NetworkId, searchParams.CenterId, searchParams.Name, searchParams.Guid.ToString(), skip, take, CommonLib.Common.CurrentUser.Id, false);
                return new SearchResult<spSearchCorp_Result>()
                {
                    Items = items,
                    TotalCount = items == null || items.Count == 0 ? 0 : items[0].TotalCount.GetValueOrDefault()
                };
            }
        }

        public static List<spGetCorpTypesWithTheSameLevel_Result> GetCorpTypesWithTheSameLevel(CorpTypeCode corpType)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.CorporateRepository.GetCorpTypesWithTheSameLevel(corpType);
            }
        }

        public static CorpTypeCode GetCorpType(long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                int typeCode = uow.CorporateRepository.GetCorpType(id);
                return (CorpTypeCode)typeCode;
            }
        }

        public static BusinessModel.CorporateModel GetByUserId(int userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DAL.Corporate corp = uow.CorporateRepository.GetByUserId(userId);
                return Mapper.MapCorp(corp);
            }
        }

        public static List<spGetNetworkLabs_Result> GetNetworkLabs(long labId, int currentUserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.CorporateRepository.GetNetworkLabs(labId, currentUserId);
            }
        }

        public static List<spGetCenterLabs_Result> GetCenterLabs(long labId, long networkLabId, int currentUserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.CorporateRepository.GetCenterLabs(labId, networkLabId, currentUserId);
            }
        }

        public static List<spGetProvinceUniversities_Result> GetProvinceUniversities(int provinceId, int currentUserId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.CorporateRepository.GetProvinceUniversities(provinceId, currentUserId);
            }
        }

        public static DAL.Corporate GetByUniqueId(Guid guid)
        {
            string guidString = guid.ToString();
            return new UnitOfWork().CorporateRepository.FirstOrDefault(x => x.EnName == guidString);
        }

        public static List<DAL.spGetSubLabs_Result> GetSubLabs(long labId)
        {
            return new UnitOfWork().CorporateRepository.GetSubLabs(labId);
        }
    }
}
