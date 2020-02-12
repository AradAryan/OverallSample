using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessModel;

namespace DAL
{
    public class PatientRepository : RepositoryBase<Patient>
    {
        public PatientRepository(SyndromeDBEntities context)
            : base(context)
        { }

        public Patient IsExist(string NationalCode)
        {
            var nPatient = from s in _dataContext.Patients
                           where s.NationalCode == NationalCode
                           select s;
            if (nPatient.Count() > 0)
                return nPatient.FirstOrDefault();
            else
                return null;
        }
        public void Update(Patient patient)
        {
            var Pt = _dataContext.Patients.FirstOrDefault(m => m.PatientID == patient.PatientID);
            Pt.NationalCode = patient.NationalCode;
            Pt.FirstName = patient.FirstName;
            Pt.LastName = patient.LastName;
            Pt.BirthDate = patient.BirthDate;
            Pt.Age = patient.Age;
            Pt.FirstNameFather = patient.FirstNameFather;
            Pt.TelPhone = patient.TelPhone;
            Pt.CellPhone = patient.CellPhone;
            Pt.FullAddress = patient.FullAddress;
            Pt.GenderID = patient.GenderID;
            Pt.NationalityID = patient.NationalityID;
            _dataContext.SaveChanges();
        }

        public void SaveAge(long patientId, string birthDate, int? age)
        {
            _dataContext.Database.ExecuteSqlCommand(string.Format("INSERT PatientAges (PatientId, BirthDate, Age) VALUES ({0}, '{1}', {2})", patientId, birthDate, age));
        }
    }
}
