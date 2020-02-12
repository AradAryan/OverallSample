using BusinessModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using CommonLib;
using Sso.UMProxy;
using System.Web;

namespace BLL
{
    public class ProSyndromRegisterBLL
    {
        public static Patient GetDetails(int AdmissionId, out string registerDate)
        {
            try
            {
                Patient b = new Patient();
                using (UnitOfWork unitofwork = new UnitOfWork())
                {
                    var a = unitofwork.SyndromRegisterRepository.Where(u => u.SyndromRegisterId == AdmissionId).FirstOrDefault();
                    b = unitofwork.PatientRepository.Where(u => u.PatientID == a.PatientID).ToList().Select(g => new Patient()
                    {
                        BirthDate = CommonLib.Common.NormalizePersianDate(g.BirthDate),
                        CellPhone = g.CellPhone,
                        FirstName = g.FirstName,
                        FirstNameFather = g.FirstNameFather,
                        FullAddress = g.FullAddress,
                        GenderID = g.GenderID,
                        LastName = g.LastName,
                        NationalCode = g.NationalCode,
                        NationalityID = g.NationalityID,
                        TelPhone = g.TelPhone,
                        UserID = g.UserID,
                        EducationID = g.EducationID,
                        AddressProvinceId = g.AddressProvinceId,
                        AddressCityId = g.AddressCityId
                    }).FirstOrDefault();
                    b.UserID = a.AdmissionType;
                    b.EducationID = a.SyndromicId;
                    //GetSyndromDetailsPatientInformation_Result result = new GetSyndromDetailsPatientInformation_Result();
                    //result = unitofwork.GetSyndromDitailsPatientInformationCallSp(AdmissionId).FirstOrDefault();
                    registerDate = CommonLib.Common.NormalizePersianDate(a.PersianDate);
                }
                return b;
            }
            catch (Exception Ex)
            {
                throw Ex;
                return null;
            }
        }
    }
}
