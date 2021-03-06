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
    
    public partial class Coded
    {
        public Coded()
        {
            this.TblAdverseReactions = new HashSet<AdverseReaction>();
            this.TblAdverseReactions1 = new HashSet<AdverseReaction>();
            this.TblComplications = new HashSet<Complication>();
            this.TblDrugHistories = new HashSet<DrugHistory>();
            this.TblDrugTreatments = new HashSet<DrugTreatment>();
            this.TblPastMedicalHistories = new HashSet<PastMedicalHistory>();
            this.TblClinicalFindings = new HashSet<ClinicalFinding>();
            this.RequestLabs = new HashSet<RequestLab>();
            this.TblDiagnosis = new HashSet<Diagnosi>();
            this.ProClinicalFindings = new HashSet<ProClinicalFinding>();
            this.ProDiagnosis = new HashSet<ProDiagnosi>();
            this.ProDrugHistories = new HashSet<ProDrugHistory>();
            this.ProPastMedicalHistories = new HashSet<ProPastMedicalHistory>();
        }
    
        public int CodeID { get; set; }
        public string coded { get; set; }
        public string terminologyid { get; set; }
        public string valuee { get; set; }
        public string CodeType { get; set; }
        public string english { get; set; }
        public string EnglishTerm { get; set; }
        public string InterfaceTerm { get; set; }
        public string FieldName { get; set; }
    
        public virtual ICollection<AdverseReaction> TblAdverseReactions { get; set; }
        public virtual ICollection<AdverseReaction> TblAdverseReactions1 { get; set; }
        public virtual ICollection<Complication> TblComplications { get; set; }
        public virtual ICollection<DrugHistory> TblDrugHistories { get; set; }
        public virtual ICollection<DrugTreatment> TblDrugTreatments { get; set; }
        public virtual ICollection<PastMedicalHistory> TblPastMedicalHistories { get; set; }
        public virtual ICollection<ClinicalFinding> TblClinicalFindings { get; set; }
        public virtual ICollection<RequestLab> RequestLabs { get; set; }
        public virtual ICollection<Diagnosi> TblDiagnosis { get; set; }
        public virtual ICollection<ProClinicalFinding> ProClinicalFindings { get; set; }
        public virtual ICollection<ProDiagnosi> ProDiagnosis { get; set; }
        public virtual ICollection<ProDrugHistory> ProDrugHistories { get; set; }
        public virtual ICollection<ProPastMedicalHistory> ProPastMedicalHistories { get; set; }
    }
}
