using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class PatientBLL
    {
        public static List<DAL.Patient> GetAll()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.PatientRepository.GetAll().ToList();
            }
        }
        public static DAL.Patient GetByID(long PatientID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.PatientRepository.GetById(PatientID);
            }
        }
        public static void Add(Patient patient)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                unitofwork.PatientRepository.Add(patient);
                unitofwork.Save();
            }
        }
        public static void Update(Patient patient)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                unitofwork.PatientRepository.Update(patient);
            }
        }
        public static DAL.Patient GetByNationalCode(string NationalCode)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.PatientRepository.Get(m => m.NationalCode == NationalCode);
            }
        }
        public static BusinessModel.PatientModel Get(string NationalCode)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return Mapper.Map(unitofwork.PatientRepository.Get(m => m.NationalCode == NationalCode));
            }
        }
        public static List<DAL.Patient> GetMaxyNationalCode(string NationalCode)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.PatientRepository.GetMany(m => m.NationalCode == NationalCode).ToList();
            }
        }


        public static DAL.Patient GetByProAdmissionId(int id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.ProAdmissionRepository.Where(m => m.AdmissionID == id).Select(x => x.Patient).FirstOrDefault();
            }
        }


        public static DAL.Patient GetByAdmissionId(int id)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.SyndromRegisterRepository.Where(m => m.SyndromRegisterId == id).Select(x => x.Patient).FirstOrDefault();
            }
        }

        public static void FixPatientAge()
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                var patients = unitofwork.PatientRepository.Where(m => m.Age > 100).ToList();
                foreach (var p in patients)
                {
                    Console.WriteLine(string.Format("{0}: \tbefore: {1},\t{2}", p.PatientID, p.BirthDate, p.Age));
                    p.BirthDate = CommonLib.Common.NormalizePersianDate(p.BirthDate);
                    DateTime birthDate = CommonLib.Common.GetMiladiDate(p.BirthDate);
                    p.Age = (DateTime.Now - birthDate).Days / 365;
                    Console.WriteLine(string.Format("{0}: \tafter: {1},\t{2}", p.PatientID, p.BirthDate, p.Age));

                    try
                    {
                        unitofwork.PatientRepository.SaveAge(p.PatientID, p.BirthDate, p.Age);
                        // unitofwork.PatientRepository.Update(p);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("#" + p.PatientID + "\r\n" + ex.Message);
                    }
                }
            }
        }
    }
}
