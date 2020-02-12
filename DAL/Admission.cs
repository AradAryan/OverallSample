//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admission
    {
        public Admission()
        {
            this.TblAdverseReactions = new HashSet<AdverseReaction>();
            this.TblClinicalFindings = new HashSet<ClinicalFinding>();
            this.TblComplications = new HashSet<Complication>();
            this.TblDeaths = new HashSet<Death>();
            this.TblDrugHistories = new HashSet<DrugHistory>();
            this.TblDrugTreatments = new HashSet<DrugTreatment>();
            this.TblMSG_Admission = new HashSet<MSG_Admission>();
            this.TblPastMedicalHistories = new HashSet<PastMedicalHistory>();
            this.TblTravels = new HashSet<Travel>();
            this.TblDiagnosis = new HashSet<Diagnosi>();
        }
    
        public long AdmissionID { get; set; }
        public string AdmissionDate { get; set; }
        public Nullable<System.DateTime> AdmissionTime { get; set; }
        public Nullable<int> AdmissionType { get; set; }
        public Nullable<int> InstituteID { get; set; }
        public string MedicalRecordNumber { get; set; }
        public Nullable<int> ReasonforEncounter { get; set; }
        public Nullable<long> PatientID { get; set; }
        public string PaperCode { get; set; }
        public string PostDate { get; set; }
        public string SamplingDate { get; set; }
        public string CompositionUID { get; set; }
    
        public virtual AdmissionType AdmissionType1 { get; set; }
        public virtual ICollection<AdverseReaction> TblAdverseReactions { get; set; }
        public virtual ICollection<ClinicalFinding> TblClinicalFindings { get; set; }
        public virtual ICollection<Complication> TblComplications { get; set; }
        public virtual ICollection<Death> TblDeaths { get; set; }
        public virtual ICollection<DrugHistory> TblDrugHistories { get; set; }
        public virtual ICollection<DrugTreatment> TblDrugTreatments { get; set; }
        public virtual ICollection<MSG_Admission> TblMSG_Admission { get; set; }
        public virtual ICollection<PastMedicalHistory> TblPastMedicalHistories { get; set; }
        public virtual ICollection<Travel> TblTravels { get; set; }
        public virtual ICollection<Diagnosi> TblDiagnosis { get; set; }
        public virtual Patient Patient { get; set; }
    }
}