using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AreaLocationRepository : RepositoryBase<AreaLocation>
    {
        public AreaLocationRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
        public List<AreaLocation> GetLocations(int AreaType)
        {
            try
            {
                var locations = from Area in _dataContext.Tbl_AreaLocation
                                where Area.areaType == AreaType
                                orderby Area.areaName
                                select Area;

                return locations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AreaLocation> GetFirstLocations(int provinceId)
        {
            try
            {
                return _dataContext.Tbl_AreaLocation.Where(x => x.AreLocationID == provinceId).OrderBy(x => x.areaName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AreaLocation> GetLocations(int AreaType, int areaParentID)
        {
            try
            {
                var locations = from Area in _dataContext.Tbl_AreaLocation
                                where Area.areaType == AreaType && Area.areaParentId == areaParentID
                                orderby Area.areaName
                                select Area;
                return locations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetProvinceId(string provinceName)
        {
            return Where(x => x.areaName == provinceName && x.areaType == (int)AreaLocationType.Province).Select(x => x.AreLocationID).FirstOrDefault();
        }

        public List<AreaLocation> GetProvinces()
        {
            return Where(x => x.areaType == (int)AreaLocationType.Province).ToList();
        }
    }
}
