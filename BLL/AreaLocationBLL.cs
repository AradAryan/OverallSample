using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
  public class AreaLocationBLL
    {
        public static List<AreaLocation> GetAreLocations(int AreaType)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.GetLocations(AreaType);
            }
        }
        public static List<AreaLocation> GetAllProvince()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.Where(q => q.areaParentId == null).OrderBy(x => x.areaName).ToList();
            }
        }

        public static AreaLocation GetProvince(string name)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.Where(q => q.areaName == name && q.areaType == 1).FirstOrDefault();
            }
        }
        public static AreaLocation GetProvinceByEnName(string name)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.Where(q => q.EnglishName == name && q.areaType == 1).FirstOrDefault();
            }
        }
        public static List<AreaLocation> GetAreFirstLocations(int ProvinceId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.GetFirstLocations(ProvinceId);
            }
        }


        public static AreaLocation Get(string code,string areaname)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.Where(m => m.areaName == areaname && m.CodeString == code).FirstOrDefault();
            }
        }
        public static AreaLocation Get(long ID)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.GetById(ID);
            }
        }

        public static List<AreaLocation> GetAreLocations(int AreaType, int AreaParentId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.AreaLocationRepository.GetLocations(AreaType, AreaParentId);
            }
        }
    }
}
