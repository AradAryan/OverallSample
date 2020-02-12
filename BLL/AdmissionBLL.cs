using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BusinessModel;

namespace BLL
{
    public class AdmissionBLL
    {
        public static void Add(Admission admission)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                unitofwork.AdmissionRepository.Add(admission);
                unitofwork.Save();
            }
        }
        public static long? Get(string CompositionUID)
        {
            if (string.IsNullOrEmpty(CompositionUID))
                return null;
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                return unitofwork.AdmissionRepository.Get(CompositionUID);
            }
        }

        public static List<NameAndType> getAddmissionWithAllRelation(string PaperCode)
        {
            using (UnitOfWork un = new UnitOfWork())
            {
                return un.AdmissionRepository.getAddmissionWithAllRelation(PaperCode);
            }
        }

        public static void DeleteAll(long admissionID)
        {
            using (UnitOfWork unitofwork = new UnitOfWork())
            {
                unitofwork.AdverseReactionRepository.Delete(admissionID);
             // unitofwork.ChiefComplaintRepository.Delete(admissionID);
                unitofwork.ClinicalFindingRepository.Delete(admissionID);
                unitofwork.ComplicationRepository.Delete(admissionID);
                unitofwork.DeathRepository.Delete(admissionID);
                unitofwork.DiagnosisRepository.Delete(admissionID);
                unitofwork.DrugHistoryRepository.Delete(admissionID);
                unitofwork.DrugTreatmentRepository.Delete(admissionID);
                unitofwork.MSGRepository.Delete(admissionID);
                unitofwork.PastMedicalHistoryRepository.Delete(admissionID);
                unitofwork.TravelRepository.Delete(admissionID);
                unitofwork.MSGAdmissionRepository.Delete(admissionID);
                unitofwork.AdmissionRepository.Delete(admissionID);
                unitofwork.LabRequestRepository.Delete(admissionID);
            }
        }

        public static List<Admission> GetByPaperCode(string paperCode)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return db.AdmissionRepository.GetMany(x => x.PaperCode == paperCode).ToList();
            }
        }

        public static List<Admission> GetByNationalCode(List<Patient> NationalListCode)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<long> pli = new List<long>();
                foreach (var item in NationalListCode)
                    pli.Add(item.PatientID);

                return db.AdmissionRepository.GetByNationalCode(pli);
            }
        }

        public static DAL.Admission GetAdmissionByPaperCode(string paperCode)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return db.AdmissionRepository.Get(x => x.PaperCode == paperCode);
            }
        }
    }
}
