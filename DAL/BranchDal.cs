using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BranchDAL : MainAccess
    {
        private static readonly BranchDAL _instance = new BranchDAL();
        public static BranchDAL Instance
        {
            get
            {
                return _instance;
            }
        }
        public IEnumerable<Corporate> GetAllZones(int area)
        {
            return UMDb.GetZoneCode(area);
        }
        public IEnumerable<Corporate> GetAllAreas()
        {
            var selectedarear = CommonLib.Common.CurrentUserAreaCode > 0 ? CommonLib.Common.CurrentUserAreaCode : -1;
            return UMDb.GetAreaCode(selectedarear);
        }
        public IEnumerable<Corporate> GetAllBranches(int area)
        {
            return UMDb.GetShoab(area);
        }
        public List<Corporate> GetBranches(string name, int code, int? selectedArea)
        {
            var result = UMDb.FindeBranches(name, code, selectedArea).ToList();
            return result;
        }

    }
}
