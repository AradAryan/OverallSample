﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.TempEfHelper
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SandromicEntities_TempEfHelper : DbContext
    {
        public SandromicEntities_TempEfHelper()
            : base("name=SandromicEntities_TempEfHelper")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BasicData> BasicDatas { get; set; }
        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<AreaType> AreaTypes { get; set; }
        public DbSet<BasicDataType> BasicDataTypes { get; set; }
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<DeathLocation> DeathLocations { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<InfoBase> InfoBases { get; set; }
        public DbSet<InfoBaseValue> InfoBaseValues { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ProDischarge> ProDischarges { get; set; }
        public DbSet<RequestLab> RequestLabs { get; set; }
        public DbSet<SyndromRegister> SyndromRegisters { get; set; }
        public DbSet<Tbl_AreaLocation> Tbl_AreaLocation { get; set; }
        public DbSet<Tbl_CenterType> Tbl_CenterType { get; set; }
        public DbSet<Tbl_Coded> Tbl_Coded { get; set; }
        public DbSet<Tbl_Country> Tbl_Country { get; set; }
        public DbSet<Tbl_Guideline> Tbl_Guideline { get; set; }
        public DbSet<Tbl_Syndromic> Tbl_Syndromic { get; set; }
        public DbSet<Tbl_University> Tbl_University { get; set; }
        public DbSet<TblAdmission> TblAdmissions { get; set; }
        public DbSet<TblAdverseReaction> TblAdverseReactions { get; set; }
        public DbSet<TblClinicalFinding> TblClinicalFindings { get; set; }
        public DbSet<TblComplication> TblComplications { get; set; }
        public DbSet<TblDeath> TblDeaths { get; set; }
        public DbSet<TblDiagnosi> TblDiagnosis { get; set; }
        public DbSet<TblDrugHistory> TblDrugHistories { get; set; }
        public DbSet<TblDrugTreatment> TblDrugTreatments { get; set; }
        public DbSet<TblError> TblErrors { get; set; }
        public DbSet<TblMethod> TblMethods { get; set; }
        public DbSet<TblMSG> TblMSGs { get; set; }
        public DbSet<TblMSG_Admission> TblMSG_Admission { get; set; }
        public DbSet<TblPaperCode> TblPaperCodes { get; set; }
        public DbSet<TblPastMedicalHistory> TblPastMedicalHistories { get; set; }
        public DbSet<TblSmsLog> TblSmsLogs { get; set; }
        public DbSet<TblSMSTemplate> TblSMSTemplates { get; set; }
        public DbSet<TblTheroshold> TblTherosholds { get; set; }
        public DbSet<TblTravel> TblTravels { get; set; }
        public DbSet<TblvisitCount> TblvisitCounts { get; set; }
        public DbSet<WarningThreshold> WarningThresholds { get; set; }
        public DbSet<LabBasicData> LabBasicDatas { get; set; }
        public DbSet<LabDetailResult> LabDetailResults { get; set; }
        public DbSet<LabDiseasesCharacter> LabDiseasesCharacters { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<ProAdmission> ProAdmissions { get; set; }
        public DbSet<ProAntiBio> ProAntiBios { get; set; }
        public DbSet<ProAntiviru> ProAntivirus { get; set; }
        public DbSet<ProBreath> ProBreaths { get; set; }
        public DbSet<ProCenter> ProCenters { get; set; }
        public DbSet<ProCenterType> ProCenterTypes { get; set; }
        public DbSet<ProChiefComplaint> ProChiefComplaints { get; set; }
        public DbSet<ProClinicalFinding> ProClinicalFindings { get; set; }
        public DbSet<ProCoded> ProCodeds { get; set; }
        public DbSet<ProComplication> ProComplications { get; set; }
        public DbSet<ProDeath> ProDeaths { get; set; }
        public DbSet<ProDiagnosi> ProDiagnosis { get; set; }
        public DbSet<ProDrugHistory> ProDrugHistories { get; set; }
        public DbSet<ProDrugTreatment> ProDrugTreatments { get; set; }
        public DbSet<ProFood> ProFoods { get; set; }
        public DbSet<ProLab> ProLabs { get; set; }
        public DbSet<ProPaperCode> ProPaperCodes { get; set; }
        public DbSet<ProPastMedicalHistory> ProPastMedicalHistories { get; set; }
        public DbSet<ProPatient> ProPatients { get; set; }
        public DbSet<ProReaction> ProReactions { get; set; }
        public DbSet<ProSemat> ProSemats { get; set; }
        public DbSet<ProTravel> ProTravels { get; set; }
        public DbSet<ProUniversity> ProUniversities { get; set; }
        public DbSet<ProWater> ProWaters { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<CorporatePath> CorporatePaths { get; set; }
        public DbSet<EntityEntityType> EntityEntityTypes { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<GroupsPermission> GroupsPermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleExtension> RuleExtensions { get; set; }
        public DbSet<Subsystem> Subsystems { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersUserGroup> UsersUserGroups { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<UsersRole> UsersRoles { get; set; }
        public DbSet<Corporate1> Corporate1 { get; set; }
        public DbSet<Positions1> Positions1 { get; set; }
        public DbSet<RuleExtension1> RuleExtension1 { get; set; }
        public DbSet<Users1> Users1 { get; set; }
        public DbSet<UsersUserGroups1> UsersUserGroups1 { get; set; }
    }
}
