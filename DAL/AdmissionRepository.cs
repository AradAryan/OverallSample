using BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AdmissionRepository : RepositoryBase<Admission>
    {
        public AdmissionRepository(SyndromeDBEntities Context)
            : base(Context)
        {

        }
        public void Delete(long AdmissionID)
        {
            SqlParameter id = new SqlParameter("AdmissionID", AdmissionID);
            _dataContext.Database.ExecuteSqlCommand("Delete tblAdmission where AdmissionID = @AdmissionID ", id);
        }
        public long? Get(string CompositionUID)
        {
            var obj = from codes in _dataContext.Admissions
                      where codes.CompositionUID == CompositionUID
                      select codes;
            if (obj.Count() > 0)
                return obj.FirstOrDefault().AdmissionID;
            else
                return null;
        }

        public List<NameAndType> getAddmissionWithAllRelation(string PaperCode)
        {
            List<NameAndType> liNameAndType = new List<NameAndType>();
            var model = _dataContext.Admissions.FirstOrDefault(x => x.PaperCode == PaperCode);
            if (model != null)
            {
                ////تاریخچه مصرف دارو
                var DrugeHistory = model.TblDrugHistories;
                //سابقه بیماری
                var TblPastMedicalHistory = model.TblPastMedicalHistories;
                //مسافرت
                var travel = model.TblTravels;
                //مرگ
                var Death = model.TblDeaths;
                //عوارض
                var Complications = model.TblComplications;
                //مراجعه به پزشک
                var ClinicalFindings = model.TblClinicalFindings;
                //اطلاعات مربوط به آنتی بیوتیک و آنتی ویروس
                var AdverseReactions = model.TblAdverseReactions;
                //DRUG TREATMENT (حمایت های درمانی اسیدوز و ...)

                var DrugTreatment = model.TblDrugTreatments.Where(x =>
                    x.DrugCodeID == 561 /*ORS*/|| x.DrugCodeID == 562 /*مایع وریدی*/ ||
                    x.DrugCodeID == 563 /*درمان اسیدوز*/|| x.DrugCodeID == 564 /*درمان اورمی*/);

                foreach (var item in DrugTreatment)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee.ToString(), Type = (int)CommonLib.MaximumDataSetTypes.DrugTretment });

                foreach (var item in DrugeHistory)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.DrugeHistory });

                foreach (var item in TblPastMedicalHistory)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.PastMedicalHistory });

                var requestModel = _dataContext.RequestLabs.FirstOrDefault(x => x.AdmissionID == model.AdmissionID);
                if (requestModel != null)
                    liNameAndType.Add(new NameAndType() { Name = requestModel.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.RequestLabs });

                foreach (var item in travel)
                {
                    string BirdHistoryStatus = "";
                    if (item.BirdHistory == null)
                        BirdHistoryStatus = "false";
                    else
                        BirdHistoryStatus = "true";
                    if (item.AreaLocationID == null)
                    {
                        liNameAndType.Add(new NameAndType() { Name = item.Tbl_Country.country, Type = (int)CommonLib.MaximumDataSetTypes.Country });
                    }
                    else
                        liNameAndType.Add(new NameAndType() { Name = item.Tbl_AreaLocation.areaName, Type = (int)CommonLib.MaximumDataSetTypes.AreaLocatuion });

                    liNameAndType.Add(new NameAndType() { Name = BirdHistoryStatus, Type = (int)CommonLib.MaximumDataSetTypes.BirdHistory });
                }

                foreach (var item in Complications)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.Complications });

                foreach (var item in ClinicalFindings)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.ClinicalFindings });

                foreach (var item in AdverseReactions)
                    liNameAndType.Add(new NameAndType() { Name = item.Tbl_Coded.valuee, Type = (int)CommonLib.MaximumDataSetTypes.AdverseReaction });

                //اطلاعات فوت
                foreach (var item in Death)
                {
                    string deathhospitalward = "";
                    if (!string.IsNullOrEmpty(item.deathhospitalward))
                        deathhospitalward = item.deathhospitalward;

                    liNameAndType.Add(new NameAndType() { Name = deathhospitalward, Type = (int)CommonLib.MaximumDataSetTypes.deathhospitalward });
                    string DeathLocationName = "";
                    if (item.DeathLocation == 1)
                        DeathLocationName = "بیمارستان";
                    else
                        DeathLocationName = "خارج بیمارستان";
                    liNameAndType.Add(new NameAndType() { Name = DeathLocationName, Type = (int)CommonLib.MaximumDataSetTypes.DeathLocationName });
                    liNameAndType.Add(new NameAndType() { Name = item.deathtime, Type = (int)CommonLib.MaximumDataSetTypes.deathtime });
                }
                string admissionType = "";
                if (model.AdmissionType == 1)
                    admissionType = "سرپایی";
                if (model.AdmissionType == 2)
                    admissionType = "بستری";
                if (model.AdmissionType == 3)
                    admissionType = "انتقالی";
                if (model.AdmissionType == 4)
                    admissionType = "اورژانس";
                //فوت بعدا اضافه شود
                liNameAndType.Add(new NameAndType() { Name = admissionType, Type = (int)CommonLib.MaximumDataSetTypes.AdmissionType });
                return liNameAndType;
            }
            return null;
        }

        public List<Admission> GetByNationalCode(List<long> pli)
        {
            var model = _dataContext.Admissions
                        .Where(x => pli.Contains(x.PatientID.Value))
                        .ToList();
            return model;
        }
    }
}


