using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BusinessModel;
using System.Transactions;
//using System.Windows.Forms;
namespace BLL
{
    public class SyndromRegisterBLL
    {
        public static List<SpGetHistory_Result> Search
            (int? skip,
            int? take,
            string university,
            string province,
            string startdate,
            string enddate,
            string syndromId, 
            string admissionType, 
            string paper, 
            string networkId,
            string centerId, 
            bool deleted, 
            bool indirect, 
            bool duplicate,
            string National_Code,
            string name , 
            string family 
            )
        {
            int currentUserId = CommonLib.Common.CurrentUser.Id;
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var ResultList = unitofwork.SpGetHistoryCallSp(skip, take, university, province, startdate, enddate, syndromId,National_Code, name, family, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, currentUserId).ToList();
                return ResultList;
            }
        }
        public static List<SpGetHistoryKarami_Result> SearchKarami(
            int? skip,
            int? take, 
            string university,
            string province, 
            string startdate, 
            string enddate, 
            string syndromId,
            string admissionType, 
            string paper, 
            string networkId,
            string centerId,
            bool deleted, 
            bool indirect, 
            bool duplicate)
        {
            int currentUserId = CommonLib.Common.CurrentUser.Id;

            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var ResultList = unitofwork.SpGetHistoryCallSpKarami(skip, take, university, province, startdate, enddate, syndromId, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, currentUserId).ToList();
                 return ResultList;
             
            }
        }

        public static List<SyndromeRegisterModel> SyndromRegisterHistory(string startdate, string enddate, string patientLikename, string UniversityId, string ProvinceId, string CityId, long centerid, string Centertype)
        {
            using (UnitOfWork untinofwork = new UnitOfWork())
            {
                return untinofwork.SyndromRegisterRepository.SyndromRegisterHistory(startdate, enddate, patientLikename, UniversityId, ProvinceId, CityId, centerid, Centertype);
            }
        }

        public static PegedData<SyndromeRegisterModel> SyndromRegisterHistory(int skip, int take, string startdate, string enddate, string University, string Province, string City)
        {
            using (UnitOfWork untinofwork = new UnitOfWork())
            {
                var list = untinofwork.SyndromRegisterRepository.SyndromRegisterHistory(startdate, enddate, University, Province, City);
                var result = new PegedData<SyndromeRegisterModel>()
                {
                    Data = list.Skip(skip).Take(take).AsEnumerable(),
                    Total = list.Count()
                };
                return result;
            }
        }

        public static PegedData<SpGetHistoryById_Result> SyndromRegisterHistory(int skip, int take, long userId)
        {
            using (UnitOfWork untinofwork = new UnitOfWork())
            {
                var list = untinofwork.SyndromRegisterRepository.SyndromRegisterHistory(userId);
                var result = new PegedData<SpGetHistoryById_Result>()
                {
                    Data = list.Skip(skip).Take(take).AsEnumerable(),
                    Total = list.Count()
                };
                return result;
            }
        }

        public static spCheckIsDuplicateSyndrom_Result CheckDuplicate(string NationalCode, int SyndromicId)
        {
            using (UnitOfWork un = new UnitOfWork())
            {
                return un.SyndromRegisterRepository.CheckDuplicate(NationalCode, SyndromicId);
            }

        }

        public static List<SyndromeRegisterModel> SyndromRegisterHistory()
        {
            using (UnitOfWork untinofwork = new UnitOfWork())
            {
                return untinofwork.SyndromRegisterRepository.SyndromRegisterHistory().Select(x => Mapper.Map(x)).ToList();
            }
        }

        private static string FormatSMS(string smscontent, string PatientName, string SyndromicName)
        {
            return smscontent.Replace("a", PatientName).Replace("b", SyndromicName);
        }

        public static long Save(PatientSyndromModel patientSyndModel)
        {
            try
            {
                patientSyndModel.Dates = CommonLib.Common.NormalizePersianDate(patientSyndModel.Dates);
                patientSyndModel.BirthDate = CommonLib.Common.NormalizePersianDate(patientSyndModel.BirthDate);

                SyndromRegister m_SyndromRegister = new SyndromRegister();
                using (TransactionScope TS = new TransactionScope())
                {

                    using (UnitOfWork unitofwork = new UnitOfWork())
                    {
                        patientSyndModel.UserId = CommonLib.Common.CurrentUser.Id;
                        if (patientSyndModel.AdmissionId != 0)
                        {
                            var PId = unitofwork.SyndromRegisterRepository.Where(u => u.SyndromRegisterId == patientSyndModel.AdmissionId).FirstOrDefault();
                            PId.AdmissionType = patientSyndModel.AdmissionType;
                            PId.SyndromicId = patientSyndModel.SyndromeId;
                            var CurrentPatient = unitofwork.PatientRepository.Where(u => u.PatientID == PId.PatientID).FirstOrDefault();
                            //Patient UpdatedPatient = null;
                            //UpdatedPatient = new Patient();
                            CurrentPatient.FirstName = patientSyndModel.FirstName;
                            CurrentPatient.LastName = patientSyndModel.LastName;
                            //if (PatientSyndromModel.NationalCode != null)
                            CurrentPatient.NationalCode = patientSyndModel.NationalCode;
                            CurrentPatient.GenderID = patientSyndModel.GenderID;
                            CurrentPatient.BirthDate = patientSyndModel.BirthDate;
                            DateTime birthDate = CommonLib.Common.GetMiladiDate(patientSyndModel.BirthDate);
                            CurrentPatient.Age = (DateTime.Now - birthDate).Days / 365;
                            CurrentPatient.FirstNameFather = patientSyndModel.FirstNameFather;
                            CurrentPatient.CellPhone = patientSyndModel.CellPhone;
                            CurrentPatient.TelPhone = patientSyndModel.TelPhone;
                            CurrentPatient.FullAddress = patientSyndModel.Address;
                            CurrentPatient.NationalityID = patientSyndModel.NationalityID;
                            CurrentPatient.AddressProvinceId = patientSyndModel.AddressProvinceId;
                            CurrentPatient.AddressCityId = patientSyndModel.AddressCityId;
                            //unitofwork.PatientRepository.Add(UpdatedPatient);
                            unitofwork.Save();
                            //PId.PatientID = UpdatedPatient.PatientID;
                            //unitofwork.PatientRepository.Update(
                        }
                        else
                        {

                            //Patient patient = unitofwork.PatientRepository.IsExist(PatientSyndromModel.NationalCode);
                            Patient patient = null;


                            //if (PatientSyndromModel.hasNationalCode == 0)
                            //{
                            patient = new Patient();
                            patient.FirstName = patientSyndModel.FirstName;
                            patient.LastName = patientSyndModel.LastName;
                            if (patientSyndModel.NationalCode != null)
                                patient.NationalCode = patientSyndModel.NationalCode;
                            patient.GenderID = patientSyndModel.GenderID;
                            patient.BirthDate = patientSyndModel.BirthDate;

                            DateTime birthDate = CommonLib.Common.GetMiladiDate(patientSyndModel.BirthDate);
                            patient.Age = (DateTime.Now - birthDate).Days / 365;
                            patient.FirstNameFather = patientSyndModel.FirstNameFather;
                            patient.CellPhone = patientSyndModel.CellPhone;
                            patient.TelPhone = patientSyndModel.TelPhone;
                            patient.NationalityID = patientSyndModel.NationalityID;
                            patient.FullAddress = patientSyndModel.Address;
                            patient.AddressProvinceId = patientSyndModel.AddressProvinceId;
                            patient.AddressCityId = patientSyndModel.AddressCityId;
                            unitofwork.PatientRepository.Add(patient);
                            unitofwork.Save();
                            patientSyndModel.PatientID = patient.PatientID;
                            //}

                            // m_SyndromRegister.PersianDate = PatientSyndromModel.Dates;
                            m_SyndromRegister.PersianDate = patientSyndModel.Dates;
                            m_SyndromRegister.SyndromicId = patientSyndModel.SyndromeId;
                            m_SyndromRegister.RegisterDateTime = patientSyndModel.Times;
                            m_SyndromRegister.UserID = patientSyndModel.UserId;
                            m_SyndromRegister.PatientID = patientSyndModel.PatientID;
                            m_SyndromRegister.IsOutRegister = false;
                            m_SyndromRegister.AdmissionType = patientSyndModel.AdmissionType;
                            m_SyndromRegister.IsTransferSepas = false;
                            m_SyndromRegister.Alert = false;


                            /*
                            
                            #region Sepas

                            var userCorp = unitofwork.CorporateRepository.GetByUserId(m_SyndromRegister.UserID.GetValueOrDefault());
                            var cityId = unitofwork.CorporateRepository.GetProvinceAndCity(userCorp.Id).CityId;

                            var sepas = new SyndromicGetway.TransferService();
                            string compositionUID = sepas.SendMinimumToSepas(
                                m_SyndromRegister,
                                unitofwork.SyndromicRepository.GetById(m_SyndromRegister.SyndromicId.GetValueOrDefault()),
                                patient,
                                userCorp,
                                unitofwork.UserRepository.GetById(m_SyndromRegister.UserID.GetValueOrDefault()),
                                unitofwork.AreaLocationRepository.GetById(cityId)
                            );
                            m_SyndromRegister.CompositionUID = compositionUID;
                            m_SyndromRegister.IsTransferedToSepas = !string.IsNullOrEmpty(compositionUID);
                           

                            #endregion

                            */

                            unitofwork.SyndromRegisterRepository.Add(m_SyndromRegister);
                            unitofwork.Save();
                        }
                    }
                    TS.Complete();
                    return m_SyndromRegister.SyndromRegisterId;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static void SendSepas(long SyndromRegisterId, string CompositionUID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                SyndromRegister syndromicRegister = unitofwork.SyndromRegisterRepository.GetById(SyndromRegisterId);
                syndromicRegister.IsTransferSepas = true;
                syndromicRegister.CompositionUID = CompositionUID;
                unitofwork.Save();
            }
        }

        public static void RaiseError(string Error, long SyndromRegisterId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                SyndromRegister syndromicRegister = unitofwork.SyndromRegisterRepository.GetById(SyndromRegisterId);
                syndromicRegister.ErrorMessage = Error;
                syndromicRegister.ErrorTime = DateTime.Now;
                unitofwork.Save();
            }

        }

        public static void UpdateAlert(long SyndromRegisterId)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var m_obj = unitofwork.SyndromRegisterRepository.GetById(SyndromRegisterId);
                m_obj.Alert = true;
                unitofwork.Save();
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitofwork = new UnitOfWork())
                {
                    var item = unitofwork.SyndromRegisterRepository.GetById(id);
                    if (item != null)
                        item.Deleted = true; // mark as deleted
                    unitofwork.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Retrieve(int id)
        {
            try
            {
                using (UnitOfWork unitofwork = new UnitOfWork())
                {
                    var item = unitofwork.SyndromRegisterRepository.GetById(id);
                    if (item != null)
                        item.Deleted = false; // mark as un-deleted
                    unitofwork.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static long Add(BusinessModel.Service.MinimumSyndromModel model)
        {
            /*
-1	نام کاربری یا کلمه عبور اشتباه است
-2	شناسه guid مرکز اشتباه است
-3	کاربر ثبت کننده اشتباه است
-4	اطلاعات بیمار ناقص است
-5	اطلاعات آدرس بیمار اشتباه است
-6	حداقل باید یک شماره تلفن وارد شود
-7	کد سندروم اشتباه است
-8	وضعیت بستری اشتباه است
-9	جنسیت بیمار مشخص نشده است
             */

            var centerUser = BLL.UserBLL.GetByUsername(model.CenterUserNationalCode);

            #region Validation

            if (BLL.CorporateBLL.GetByUniqueId(model.CenterGuid) == null)
                return -2;
            if (centerUser == null)
                return -3;
            if (string.IsNullOrEmpty(model.PatientFirstname) || string.IsNullOrEmpty(model.PatientLastname) || string.IsNullOrEmpty(model.PatientFathername) ||
                    string.IsNullOrEmpty(model.PatientBirthDate))
                return -4;
            if (BLL.AreaLocationBLL.Get(model.PatientProvinceId) == null || BLL.AreaLocationBLL.Get(model.PatientProvinceId) == null)
                return -5;
            if (string.IsNullOrEmpty(model.PatientMobile) && string.IsNullOrEmpty(model.PatientPhone))
                return -6;
            if (model.SyndromId <= 0 || model.SyndromId > 15)
                return -7;
            if (model.AdmissionType == 0)
                return -8;
            if (model.PatientGender == 0)
                return -9;

            #endregion

            try
            {
                DAL.Patient patient = new Patient()
                {
                    RegisterDate = DateTime.Now,
                    BirthDate = CommonLib.Common.NormalizePersianDate(model.PatientBirthDate),
                    AddressCityId = model.PatientCityId,
                    AddressProvinceId = model.PatientProvinceId,
                    CellPhone = model.PatientMobile,
                    TelPhone = model.PatientPhone,
                    FullAddress = model.PatientAddress,
                    FirstName = model.PatientFirstname,
                    LastName = model.PatientLastname,
                    FirstNameFather = model.PatientFathername,
                    NationalityID = 11, // ملیت ایرانی
                    GenderID = (int)model.PatientGender
                };
                SyndromRegister syndrom = new SyndromRegister()
                {
                    AdmissionType = (int)model.AdmissionType,
                    IsTransferSepas = true,
                    PersianDate = model.RegisterDate,
                    RegisterDateTime = DateTime.Now,
                    SyndromicId = model.SyndromId,
                    UserID = centerUser.Id
                };

                using (TransactionScope TS = new TransactionScope())
                {
                    using (UnitOfWork unitofwork = new UnitOfWork())
                    {
                        DateTime birthDate = CommonLib.Common.GetMiladiDate(patient.BirthDate);
                        patient.Age = (DateTime.Now - birthDate).Days / 365;
                        unitofwork.PatientRepository.Add(patient);

                        unitofwork.Save();

                        syndrom.PatientID = patient.PatientID;
                        unitofwork.SyndromRegisterRepository.Add(syndrom);

                        unitofwork.Save();
                    }
                    TS.Complete();
                    return syndrom.SyndromRegisterId;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
