using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data.Entity.Validation;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private SyndromeDBEntities _context;
        public UnitOfWork()
        {
            _context = new SyndromeDBEntities();
        }

        public void Save()
        {
            // _context.a
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        //private PhoneRepository m_PhoneRepository;

        //public PhoneRepository PhoneRepository
        //{
        //    get
        //    {
        //        if (m_PhoneRepository == null)
        //        {
        //            m_PhoneRepository = new PhoneRepository(_context);
        //        }
        //        return m_PhoneRepository;
        //    }

        //}

        private MyReportRepository m_MyReportRepository;
        public MyReportRepository MyReportRepository
        {
            get
            {
                if (m_MyReportRepository == null)
                {
                    m_MyReportRepository = new MyReportRepository(_context);
                }
                return m_MyReportRepository;
            }
        }



        private ReportRepository m_ReportRepository;

        public ReportRepository ReportRepository
        {
            get
            {
                if (m_ReportRepository == null)
                {
                    m_ReportRepository = new ReportRepository(_context);
                }
                return m_ReportRepository;
            }

        }
        private ReportRepository m_Report2Repository;

        public ReportRepository Report2Repository
        {
            get
            {
                if (m_Report2Repository == null)
                {
                    m_Report2Repository = new ReportRepository(_context);
                }
                return m_Report2Repository;
            }

        }

        private GuidelineRepository m_GuidelineRepository;

        public GuidelineRepository GuidelineRepository
        {
            get
            {
                if (m_GuidelineRepository == null)
                {
                    m_GuidelineRepository = new GuidelineRepository(_context);
                }
                return m_GuidelineRepository;
            }

        }

 private CtrRiskRepository m_CtrRiskRepository;

        public CtrRiskRepository CtrRiskRepository
        {
            get
            {
                if (m_CtrRiskRepository == null)
                {
                    m_CtrRiskRepository = new CtrRiskRepository(_context);
                }
                return m_CtrRiskRepository;
            }

        }

        private DiseaseAccessRepository m_DiseaseAccessRepository;

        public DiseaseAccessRepository DiseaseAccessRepository
        {
            get
            {
                if (m_DiseaseAccessRepository == null)
                {
                    m_DiseaseAccessRepository = new DiseaseAccessRepository(_context);
                }
                return m_DiseaseAccessRepository;
            }
        }


        private ProAntiBioRepository m_ProAntiBioRepository;

        public ProAntiBioRepository ProAntiBioRepository
        {
            get
            {
                if (m_ProAntiBioRepository == null)
                {
                    m_ProAntiBioRepository = new ProAntiBioRepository(_context);
                }
                return m_ProAntiBioRepository;
            }

        }



        private PermissionRepository m_PermissionRepository;

        public PermissionRepository PermissionRepository
        {
            get
            {
                if (m_PermissionRepository == null)
                {
                    m_PermissionRepository = new PermissionRepository(_context);
                }
                return m_PermissionRepository;
            }
        }



        private ProAdmissionDoneStepRepository m_ProAdmissionDoneStepRepository;

        public ProAdmissionDoneStepRepository ProAdmissionDoneStepRepository
        {
            get
            {
                if (m_ProAdmissionDoneStepRepository == null)
                {
                    m_ProAdmissionDoneStepRepository = new ProAdmissionDoneStepRepository(_context);
                }
                return m_ProAdmissionDoneStepRepository;
            }

        }








        private ProComplicationRepository m_ProComplicationRepository;

        public ProComplicationRepository ProComplicationRepository
        {
            get
            {
                if (m_ProComplicationRepository == null)
                {
                    m_ProComplicationRepository = new ProComplicationRepository(_context);
                }
                return m_ProComplicationRepository;
            }

        }



        private LabDiseaseAssignmentRepository m_LabDiseaseAssignmentRepository;

        public LabDiseaseAssignmentRepository LabDiseaseAssignmentRepository
        {
            get
            {
                if (m_LabDiseaseAssignmentRepository == null)
                {
                    m_LabDiseaseAssignmentRepository = new LabDiseaseAssignmentRepository(_context);
                }
                return m_LabDiseaseAssignmentRepository;
            }

        }






        private ProDrugTreatmentRepository m_ProDrugTreatmentRepository;

        public ProDrugTreatmentRepository ProDrugTreatmentRepository
        {
            get
            {
                if (m_ProDrugTreatmentRepository == null)
                {
                    m_ProDrugTreatmentRepository = new ProDrugTreatmentRepository(_context);
                }
                return m_ProDrugTreatmentRepository;
            }

        }



        private ProAntivirusRepository m_ProAntivirusRepository;

        public ProAntivirusRepository ProAntivirusRepository
        {
            get
            {
                if (m_ProAntivirusRepository == null)
                {
                    m_ProAntivirusRepository = new ProAntivirusRepository(_context);
                }
                return m_ProAntivirusRepository;
            }
        }







        private ProBreathRepository m_ProBreathRepository;

        public ProBreathRepository ProBreathRepository
        {
            get
            {
                if (m_ProBreathRepository == null)
                {
                    m_ProBreathRepository = new ProBreathRepository(_context);
                }
                return m_ProBreathRepository;
            }

        }

        private LoanRepository m_LoanRepository;

        public LoanRepository LoanRepository
        {
            get
            {
                if (m_LoanRepository == null)
                {
                    m_LoanRepository = new LoanRepository(_context);
                }
                return m_LoanRepository;
            }

        }

        private ProDeathRepository m_ProDeathRepository;

        public ProDeathRepository ProDeathRepository
        {
            get
            {
                if (m_ProDeathRepository == null)
                {
                    m_ProDeathRepository = new ProDeathRepository(_context);
                }
                return m_ProDeathRepository;
            }

        }




        private FoodRepository m_FoodRepository;

        public FoodRepository FoodRepository
        {
            get
            {
                if (m_FoodRepository == null)
                {
                    m_FoodRepository = new FoodRepository(_context);
                }
                return m_FoodRepository;
            }

        }






        private ThresholdWarningReceiverRepository m_ThresholdWarningReceiverRepository;

        public ThresholdWarningReceiverRepository ThresholdWarningReceiverRepository
        {
            get
            {
                if (m_ThresholdWarningReceiverRepository == null)
                {
                    m_ThresholdWarningReceiverRepository = new ThresholdWarningReceiverRepository(_context);
                }
                return m_ThresholdWarningReceiverRepository;
            }
        }





        private ThresholdWarningStatusRepository m_ThresholdWarningStatusRepository;

        public ThresholdWarningStatusRepository ThresholdWarningStatusRepository
        {
            get
            {
                if (m_ThresholdWarningStatusRepository == null)
                {
                    m_ThresholdWarningStatusRepository = new ThresholdWarningStatusRepository(_context);
                }
                return m_ThresholdWarningStatusRepository;
            }

        }



        private ThresholdWarningMetaDataRepository m_ThresholdWarningMetaDataRepository;

        public ThresholdWarningMetaDataRepository ThresholdWarningMetaDataRepository
        {
            get
            {
                if (m_ThresholdWarningMetaDataRepository == null)
                {
                    m_ThresholdWarningMetaDataRepository = new ThresholdWarningMetaDataRepository(_context);
                }
                return m_ThresholdWarningMetaDataRepository;
            }

        }




        private WarningThresholdRepository m_WarningThresholdRepository;

        public WarningThresholdRepository WarningThresholdRepository
        {
            get
            {
                if (m_WarningThresholdRepository == null)
                {
                    m_WarningThresholdRepository = new WarningThresholdRepository(_context);
                }
                return m_WarningThresholdRepository;
            }

        }

        private SmsTemplateRepository m_SmsTemplateRepository;

        public SmsTemplateRepository SmsTemplateRepository
        {
            get
            {
                if (m_SmsTemplateRepository == null)
                {
                    m_SmsTemplateRepository = new SmsTemplateRepository(_context);
                }
                return m_SmsTemplateRepository;
            }

        }

        private LabResultRepository _LabResultRepository;

        public LabResultRepository LabResultRepository
        {
            get
            {
                if (_LabResultRepository == null)
                {
                    _LabResultRepository = new LabResultRepository(_context);
                }
                return _LabResultRepository;
            }
        }

        private LabDetailResultRepository _LabDetailResultRepository;

        public LabDetailResultRepository LabDetailResultRepository
        {
            get
            {
                if (_LabDetailResultRepository == null)
                {
                    _LabDetailResultRepository = new LabDetailResultRepository(_context);
                }
                return _LabDetailResultRepository;
            }
        }

        //private CorporateLabRepository _CorporateLabRepository;

        //public CorporateLabRepository CorporateLabRepository
        //{
        //    get
        //    {
        //        if (_CorporateLabRepository == null)
        //        {
        //            _CorporateLabRepository = new CorporateLabRepository(_context);
        //        }
        //        return _CorporateLabRepository;
        //    }
        //}

        private DiseaseRepository m_Disease;

        public DiseaseRepository DiseaseRepository
        {
            get
            {
                if (m_Disease == null)
                {
                    m_Disease = new DiseaseRepository(_context);
                }
                return m_Disease;
            }
        }

        //.......................................................................................
        private OrganizationRepository m_organizationRepository;

        public OrganizationRepository organizationRepository
        {
            get
            {
                if (m_organizationRepository == null)
                {
                    m_organizationRepository = new OrganizationRepository(_context);
                }
                return m_organizationRepository;
            }
        }
        //.......................................................................................
        private LabDiseasesCharacterRpository m_LabDiseasecharecter;

        public LabDiseasesCharacterRpository LabDiseasecharecterRpository
        {
            get
            {
                if (m_LabDiseasecharecter == null)
                {
                    m_LabDiseasecharecter = new LabDiseasesCharacterRpository(_context);
                }
                return m_LabDiseasecharecter;
            }
        }

        private GetPatintInfoRepository m_GetPatintInfo;

        public GetPatintInfoRepository GetPatintInfoRepository
        {
            get
            {
                if (m_GetPatintInfo == null)
                {
                    m_GetPatintInfo = new GetPatintInfoRepository(_context);
                }
                return m_GetPatintInfo;
            }
        }

        private LabRequestRepository m_LabRequestRepository;

        public LabRequestRepository LabRequestRepository
        {
            get
            {
                if (m_LabRequestRepository == null)
                {
                    m_LabRequestRepository = new LabRequestRepository(_context);
                }
                return m_LabRequestRepository;
            }
        }

        private LogReporsitory m_LogReporsitory;

        public LogReporsitory LogReporsitory
        {
            get
            {
                if (m_LogReporsitory == null)
                    m_LogReporsitory = new LogReporsitory(_context);
                return m_LogReporsitory;
            }
        }

        private LabBasicDataRepository labLabBasicDataRepository;

        public LabBasicDataRepository LabLabBasicDataRepository
        {
            get
            {
                if (labLabBasicDataRepository == null)
                    labLabBasicDataRepository = new LabBasicDataRepository(_context);
                return labLabBasicDataRepository;
            }
        }

        private CorporateRepository m_CorporateRepository;

        public CorporateRepository CorporateRepository
        {
            get
            {
                if (m_CorporateRepository == null)
                    m_CorporateRepository = new CorporateRepository(_context);
                return m_CorporateRepository;
            }

        }

        private TherosholdRepository m_TherosholdRepository;

        public TherosholdRepository TherosholdRepository
        {
            get
            {
                if (m_TherosholdRepository == null)
                    m_TherosholdRepository = new TherosholdRepository(_context);
                return m_TherosholdRepository;
            }
        }

        //private City_UniversityRepository m_City_UniversityRepository;

        //public City_UniversityRepository City_UniversityRepository
        //{
        //    get
        //    {
        //        if (m_City_UniversityRepository == null)
        //            m_City_UniversityRepository = new City_UniversityRepository(_context);
        //        return m_City_UniversityRepository;
        //    }
        //}

        private MethodRepository m_MethodRepository;

        public MethodRepository MethodRepository
        {
            get
            {
                if (m_MethodRepository == null)
                    m_MethodRepository = new MethodRepository(_context);
                return m_MethodRepository;
            }
        }

        private VisitCountRepository m_VisitCountRepository;

        public VisitCountRepository VisitCountRepository
        {
            get
            {
                if (m_VisitCountRepository == null)
                    m_VisitCountRepository = new VisitCountRepository(_context);
                return m_VisitCountRepository;
            }
        }

        private UsersUserGroupsRepository m_UsersUserGroupsRepository;

        public UsersUserGroupsRepository UsersUserGroupsRepository
        {
            get
            {
                if (m_UsersUserGroupsRepository == null)
                    m_UsersUserGroupsRepository = new UsersUserGroupsRepository(_context);
                return m_UsersUserGroupsRepository;
            }
        }

        private SmslogRepository m_SmslogRepository;

        public SmslogRepository SmslogRepository
        {
            get
            {
                if (m_SmslogRepository == null)
                    m_SmslogRepository = new SmslogRepository(_context);
                return m_SmslogRepository;
            }

        }

        private MSGAdmissionRepository m_MSGAdmissionRepository;

        public MSGAdmissionRepository MSGAdmissionRepository
        {
            get
            {
                if (m_MSGAdmissionRepository == null)
                    m_MSGAdmissionRepository = new MSGAdmissionRepository(_context);
                return m_MSGAdmissionRepository;
            }
        }


        private ErrorRepository m_ErrorRepository;

        public ErrorRepository ErrorRepository
        {
            get
            {
                if (m_ErrorRepository == null)
                    m_ErrorRepository = new ErrorRepository(_context);
                return m_ErrorRepository;
            }
        }


        private ClinicalFindingRepository m_ClinicalFindingRepository;

        public ClinicalFindingRepository ClinicalFindingRepository
        {
            get
            {
                if (m_ClinicalFindingRepository == null)
                    m_ClinicalFindingRepository = new ClinicalFindingRepository(_context);
                return m_ClinicalFindingRepository;
            }
        }


        private AdverseReactionRepository m_AdverseReactionRepository;

        public AdverseReactionRepository AdverseReactionRepository
        {
            get
            {
                if (m_AdverseReactionRepository == null)
                    m_AdverseReactionRepository = new AdverseReactionRepository(_context);
                return m_AdverseReactionRepository;
            }
        }


        private SampleRepository m_SampleRepository;

        public SampleRepository SampleRepository
        {
            get
            {
                if (m_SampleRepository == null)
                    m_SampleRepository = new SampleRepository(_context);
                return m_SampleRepository;
            }
        }


        private DrugTreatmentRepository m_DrugTreatmentRepository;

        public DrugTreatmentRepository DrugTreatmentRepository
        {
            get
            {
                if (m_DrugTreatmentRepository == null)
                    m_DrugTreatmentRepository = new DrugTreatmentRepository(_context);
                return m_DrugTreatmentRepository;
            }
        }

        private MSGRepository m_MSGRepository;

        public MSGRepository MSGRepository
        {
            get
            {
                if (m_MSGRepository == null)
                    m_MSGRepository = new MSGRepository(_context);
                return m_MSGRepository;
            }

        }

        private ComplicationRepository m_ComplicationRepository;

        public ComplicationRepository ComplicationRepository
        {
            get
            {
                if (m_ComplicationRepository == null)
                    m_ComplicationRepository = new ComplicationRepository(_context);
                return m_ComplicationRepository;
            }
        }

        private DeathRepository m_DeathRepository;

        public DeathRepository DeathRepository
        {
            get
            {
                if (m_DeathRepository == null)
                    m_DeathRepository = new DeathRepository(_context);
                return m_DeathRepository;
            }
        }

        private PastMedicalHistoryRepository m_PastMedicalHistoryRepository;

        public PastMedicalHistoryRepository PastMedicalHistoryRepository
        {
            get
            {
                if (m_PastMedicalHistoryRepository == null)
                    m_PastMedicalHistoryRepository = new PastMedicalHistoryRepository(_context);
                return m_PastMedicalHistoryRepository;
            }
        }

        private DiagnosisRepository m_DiagnosisRepository;

        public DiagnosisRepository DiagnosisRepository
        {
            get
            {
                if (m_DiagnosisRepository == null)
                    m_DiagnosisRepository = new DiagnosisRepository(_context);
                return m_DiagnosisRepository;
            }

        }

        private DrugHistoryRepository m_DrugHistoryRepository;

        public DrugHistoryRepository DrugHistoryRepository
        {
            get
            {
                if (m_DrugHistoryRepository == null)
                    m_DrugHistoryRepository = new DrugHistoryRepository(_context);
                return m_DrugHistoryRepository;
            }

        }

        //private ChiefComplaintRepository m_ChiefComplaintRepository;

        //public ChiefComplaintRepository ChiefComplaintRepository
        //{
        //    get
        //    {
        //        if (m_ChiefComplaintRepository == null)
        //            m_ChiefComplaintRepository = new ChiefComplaintRepository(_context);
        //        return m_ChiefComplaintRepository;
        //    }

        //}

        private CountryRepository m_CountryRepository;
        public CountryRepository CountryRepository
        {
            get
            {
                if (m_CountryRepository == null)
                    m_CountryRepository = new CountryRepository(_context);
                return m_CountryRepository;
            }

        }

        private TravelRepository m_TravelRepository;
        public TravelRepository TravelRepository
        {
            get
            {
                if (m_TravelRepository == null)
                    m_TravelRepository = new TravelRepository(_context);
                return m_TravelRepository;
            }
        }



        private subSystemRepository m_subSystemRepository;
        public subSystemRepository subSystemRepository
        {
            get
            {
                if (m_subSystemRepository == null)
                    m_subSystemRepository = new subSystemRepository(_context);
                return m_subSystemRepository;
            }
        }



        private AdmissionRepository m_AdmissionRepository;
        public AdmissionRepository AdmissionRepository
        {
            get
            {
                if (m_AdmissionRepository == null)
                    m_AdmissionRepository = new AdmissionRepository(_context);
                return m_AdmissionRepository;
            }

        }


        private PaperCodeRepository m_PaperCodeRepository;
        public PaperCodeRepository PaperCodeRepository
        {
            get
            {
                if (m_PaperCodeRepository == null)
                    m_PaperCodeRepository = new PaperCodeRepository(_context);
                return m_PaperCodeRepository;
            }
        }


        private CenterTypeRepository m_CenterTypeRepository;
        public CenterTypeRepository CenterTypeRepository
        {
            get
            {
                if (m_CenterTypeRepository == null)
                    m_CenterTypeRepository = new CenterTypeRepository(_context);
                return m_CenterTypeRepository;
            }
        }


        private CenterRepository m_CenterRepository;
        //public CenterRepository CenterRepository
        //{
        //    get
        //    {
        //        if (m_CenterRepository == null)
        //            m_CenterRepository = new CenterRepository(_context);
        //        return m_CenterRepository;
        //    }
        //}

        private UserGroupRepository m_UserGroupRepository;
        public UserGroupRepository UserGroupRepository
        {
            get
            {
                if (m_UserGroupRepository == null)
                    m_UserGroupRepository = new UserGroupRepository(_context);
                return m_UserGroupRepository;
            }
        }

        private UniversityRepository m_UniversityRepository;
        public UniversityRepository UniversityRepository
        {
            get
            {
                if (m_UniversityRepository == null)
                    m_UniversityRepository = new UniversityRepository(_context);
                return m_UniversityRepository;
            }
        }

        private AreaLocationRepository m_AreaLocationRepository;
        public AreaLocationRepository AreaLocationRepository
        {
            get
            {
                if (m_AreaLocationRepository == null)
                    m_AreaLocationRepository = new AreaLocationRepository(_context);
                return m_AreaLocationRepository;
            }
        }

        private SyndromRegisterRepository m_SyndromRegisterRepository;
        public SyndromRegisterRepository SyndromRegisterRepository
        {
            get
            {
                if (m_SyndromRegisterRepository == null)
                    m_SyndromRegisterRepository = new SyndromRegisterRepository(_context);
                return m_SyndromRegisterRepository;
            }
        }

        //private NetworkCityRepository m_NetworkCityRepository;
        //public NetworkCityRepository NetworkCityRepository
        //{
        //    get
        //    {
        //        if (m_NetworkCityRepository == null)
        //            m_NetworkCityRepository = new NetworkCityRepository(_context);
        //        return m_NetworkCityRepository;
        //    }
        //}

        private PostionRepository m_PostionRepository;
        public PostionRepository PostionRepository
        {
            get
            {
                if (m_PostionRepository == null)
                    m_PostionRepository = new PostionRepository(_context);
                return m_PostionRepository;
            }
        }

        private PatientRepository m_PatientRepository;
        public PatientRepository PatientRepository
        {
            get
            {
                if (m_PatientRepository == null)
                    m_PatientRepository = new PatientRepository(_context);
                return m_PatientRepository;
            }
        }

        private CodedRepository m_CodedRepository;
        public CodedRepository CodedRepository
        {
            get
            {
                if (m_CodedRepository == null)
                    m_CodedRepository = new CodedRepository(_context);
                return m_CodedRepository;
            }
        }

        private BasicDataRepository m_BasicDataRepository;
        public BasicDataRepository BasicDataRepository
        {
            get
            {
                if (m_BasicDataRepository == null)
                    m_BasicDataRepository = new BasicDataRepository(_context);
                return m_BasicDataRepository;
            }
        }

        private BasicDataTypeRepository m_BasicDataTypeRepository;
        public BasicDataTypeRepository BasicDataTypeRepository
        {
            get
            {
                if (m_BasicDataTypeRepository == null)
                    m_BasicDataTypeRepository = new BasicDataTypeRepository(_context);
                return m_BasicDataTypeRepository;
            }
        }

        private CorporatesHierarchyRepository m_CorporatesHierarchyRepository;
        public CorporatesHierarchyRepository CorporatesHierarchyRepository
        {
            get
            {
                if (m_CorporatesHierarchyRepository == null)
                    m_CorporatesHierarchyRepository = new CorporatesHierarchyRepository(_context);
                return m_CorporatesHierarchyRepository;
            }
        }

        private UserCorporatesHierarchyRepository m_UserCorporatesHierarchyRepository;
        public UserCorporatesHierarchyRepository UserCorporatesHierarchyRepository
        {
            get
            {
                if (m_UserCorporatesHierarchyRepository == null)
                    m_UserCorporatesHierarchyRepository = new UserCorporatesHierarchyRepository(_context);
                return m_UserCorporatesHierarchyRepository;
            }
        }

        private UserRepository m_UserRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (m_UserRepository == null)
                    m_UserRepository = new UserRepository(_context);
                return m_UserRepository;
            }
        }

        private UserVMRepository m_UserVMRepository;
        public UserVMRepository UservmRepository
        {
            get
            {
                if (m_UserVMRepository == null)
                    m_UserVMRepository = new UserVMRepository(_context);
                return m_UserVMRepository;
            }
        }
            
  private CenterVMRepository m_CenterVMRepository;
        public CenterVMRepository CenterVmRepository
        {
            get
            {
                if (m_CenterVMRepository == null)
                    m_CenterVMRepository = new CenterVMRepository(_context);
                return m_CenterVMRepository;
            }
        }


        private TestFaqRepository m_TestFaqRepository;
        public TestFaqRepository TestFaqRepository
        {
            get
            {
                if (m_TestFaqRepository == null)
                    m_TestFaqRepository = new TestFaqRepository(_context);
                return m_TestFaqRepository;
            }
        }



        private SyndromicRepository m_SyndromicRepository;
        public SyndromicRepository SyndromicRepository
        {
            get
            {
                if (m_SyndromicRepository == null)
                    m_SyndromicRepository = new SyndromicRepository(_context);
                return m_SyndromicRepository;
            }
        }
        //private RoleRepository m_RoleRepository;

        //public RoleRepository RoleRepository
        //{
        //    get
        //    {
        //        if (m_RoleRepository == null)
        //            m_RoleRepository = new RoleRepository(_context);
        //        return m_RoleRepository;
        //    }
        //}



        private ProAdmissionRepository m_ProAdmissionRepository;

        public ProAdmissionRepository ProAdmissionRepository
        {
            get
            {
                if (m_ProAdmissionRepository == null)
                    m_ProAdmissionRepository = new ProAdmissionRepository(_context);
                return m_ProAdmissionRepository;
            }
        }

        private ProLabRepository m_ProLabRepository;
        public ProLabRepository ProLabRepository
        {
            get
            {
                if (m_ProLabRepository == null)
                    m_ProLabRepository = new ProLabRepository(_context);
                return m_ProLabRepository;
            }
        }

        private ProTravelRepository m_ProTravelRepository;
        public ProTravelRepository ProTravelRepository
        {
            get
            {
                if (m_ProTravelRepository == null)
                    m_ProTravelRepository = new ProTravelRepository(_context);
                return m_ProTravelRepository;
            }
        }


        private ProCilinicalFindingRepository m_ProCilinicalFindingRepository;
        public ProCilinicalFindingRepository ProCilinicalFindingRepository
        {
            get
            {
                if (m_ProCilinicalFindingRepository == null)
                    m_ProCilinicalFindingRepository = new ProCilinicalFindingRepository(_context);
                return m_ProCilinicalFindingRepository;
            }
        }
        private ProDrugHistoryRepository m_ProDrugHistoryRepository;
        public ProDrugHistoryRepository ProDrugHistoryRepository
        {
            get
            {
                if (m_ProDrugHistoryRepository == null)
                    m_ProDrugHistoryRepository = new ProDrugHistoryRepository(_context);
                return m_ProDrugHistoryRepository;
            }
        }

        private ProPastMedicalHistoryRepository m_ProPastMedicalHistoryRepository;
        public ProPastMedicalHistoryRepository ProPastMedicalHistoryRepository
        {
            get
            {
                if (m_ProPastMedicalHistoryRepository == null)
                    m_ProPastMedicalHistoryRepository = new ProPastMedicalHistoryRepository(_context);
                return m_ProPastMedicalHistoryRepository;
            }
        }


        private ProDiagnosisRepository m_ProDiagnosisRepository;
        public ProDiagnosisRepository ProDiagnosisRepository
        {
            get
            {
                if (m_ProDiagnosisRepository == null)
                    m_ProDiagnosisRepository = new ProDiagnosisRepository(_context);
                return m_ProDiagnosisRepository;
            }
        }


        private FAQRepository m_FAQRepository;
        public FAQRepository FAQRepository
        {
            get
            {
                if (m_FAQRepository == null)
                    m_FAQRepository = new FAQRepository(_context);
                return m_FAQRepository;
            }
        }
        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GetProRegisterSyndroms_Result> GetProRegisterSyndromsCallSp(int? skip, int? take, string university, string province, string startdate, string enddate, string syndromId, string National_Code, string name, string family, string admissionType, string paper, string networkId, string centerId, bool showIncompleteItems, bool deleted, bool indirect, int currentUserId, string primaryResultId)
        {
            setExectionTimeout(180);
            return _context.GetProRegisterSyndroms(startdate, enddate, university, province, syndromId, name, family, National_Code, skip, take, admissionType, paper, networkId, centerId, primaryResultId, showIncompleteItems, deleted, indirect, currentUserId).ToList();
        }

        private void setExectionTimeout(int seconds)
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)this._context).ObjectContext.CommandTimeout = seconds;
        }
        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GetProSyndromDitailsPatientInformation_Result> GetProSyndromDitailsPatientInformationCallSp(int AdmissionId)
        {
            return _context.GetProSyndromDitailsPatientInformation(AdmissionId).ToList();
        }

        public List<GetProSyndromDitailsPatientInformationWithIDs_Result> GetProSyndromDitailsPatientInformationWithIdsCallSp(string AdmissionId)
        {
            return _context.GetProSyndromDitailsPatientInformationWithIDs(AdmissionId).ToList();
        }

        public List<GetSyndromDetailsPatientInformation_Result> GetSyndromDitailsPatientInformationCallSp(int AdmissionId)
        {
            return _context.GetSyndromDetailsPatientInformation(AdmissionId).ToList();
        }
        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GetProSyndromDitails_Result> GetProSyndromDitailsCallSp(int AdmissionId)
        {
            return _context.GetProSyndromDitails(AdmissionId).ToList();
        }
        public List<GetProSyndromDitailsWithIds_Result> GetProSyndromDetailsWithIds(string AdmissionIds)
        {
            return _context.GetProSyndromDitailsWithIds(AdmissionIds).ToList();
        }
        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GetProSyndromDitailsForWord_Result> GetProSyndromDitailsForWordCallSp(int AdmissionId)
        {
            return _context.GetProSyndromDitailsForWord(AdmissionId).ToList();
        }
        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<SpGetHistory_Result> SpGetHistoryCallSp(int? skip, int? take, string university, string province, string startdate, string enddate, string syndromId,string National_Code, string name, string family,string admissionType, string paper, string networkId, string centerId, bool deleted, bool indirect, bool duplicate, int currentUserId)
        {
            return _context.SpGetHistory(startdate, enddate, university, province, syndromId, name, family, National_Code, skip, take, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, currentUserId).ToList();

        }
        public List<SpGetHistoryKarami_Result> SpGetHistoryCallSpKarami
            (int? skip, int? take, string university, string province, string startdate, string enddate, string syndromId,
            string admissionType, string paper, string networkId, string centerId, bool deleted, bool indirect, bool duplicate, int currentUserId)
        {
            List<SpGetHistoryKarami_Result> retunList = _context.SpGetHistoryKarami(startdate, enddate, university, province, syndromId, skip, take, admissionType, paper, networkId, centerId, deleted, indirect, duplicate, currentUserId).ToList();
            return retunList;            

        }

        public List<GetUserPositionHierarchy_Result> GetUserPositionHierarchy(int? userId)
        {
            return _context.GetUserPositionHierarchy(userId).ToList();
        }

        /// <summary>
        /// stored prosedures
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="UniversityID"></param>
        /// <param name="cityId"></param>
        /// <param name="Date_From"></param>
        /// <param name="Date_End"></param>
        /// <param name="SyndromicId"></param>
        /// <param name="National_Code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public void SpDelete(string query)
        {
            _context.DeleteItemsWhileUpdate(query);
        }


        public List<spGetLabsBySampleResultCount_Result> LabSortByResultCount(string provinceId, string universityId, string networkId, string centerId, int skip, int take, int currentUserId, string startDate, string endDate)
        {
            using (LabSortByResultCountRepository labSortByResultCountRepository = new LabSortByResultCountRepository(_context))
            {
                return labSortByResultCountRepository.Get(provinceId, universityId, networkId, centerId, skip, take, currentUserId, startDate, endDate);
            }
        }
    }
}
