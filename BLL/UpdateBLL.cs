using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class UpdateBLL
    {
        public static Patient GetAdmissionDetails(int AdmissionId, out string registerDate)
        {
            return BLL.ProSyndromRegisterBLL.GetDetails(AdmissionId, out registerDate);
        }
    }
}
