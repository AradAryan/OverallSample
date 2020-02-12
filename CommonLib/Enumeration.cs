using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{

    public enum Permission : long
    {
        /// <summary>ثبت سندرم - ماکزیمم</summary>
        SyndromicRegister,
        BranchAccess,
        accessUserManager = 221,
        RegisterSyndrom = 223,
        /// <summary>ثبت سندرم مینیمم</summary>
        RegisterMinimumSyndrom,
        RegisterTheroshold = 224,
        RegisterVisit = 226,
        ReportList = 225,
        accessSmslog = 228,
        accessSmsTemplate = 227,
        //added 930130
        UsersAccess,
        //added 930201
        RegisterUser,
        RegisterCenter = 232,
        RegisterCenterType = 231,
        UserReport = 234,
        CenterReport = 235,
        //ADD 930221
        SetUserGroupDefualtAccess = 236,
        //Add 930317
        LogReport = 237,
        WarningThroshold = 238,
        WarningThrosholdDashbord = 239,
        GuidLine = 240,
        BasicView,
        // added 940828
        NetworkAccess,
        UniversityAccess,
        fullaccess,
        Network,
        Center,
        University,

        /// <summary>دسترسی آزمایشگاه</summary>
        LabAccess,

        /// <summary>حذف سندرم - مینیمم</summary>
        DeleteMinimumSyndrom,
        MinimumReport,
        /// <summary>حذف سندرم - ماکزیمم</summary>
        DeleteMaximumSyndrom,

        /// <summary>تنظیم آستانه هشدار</summary>
        ManageThreshold,

        /// <summary>مدیریت آزمایشگاه ها</summary>
        ManageLabs,

        /// <summary>مدیریت مراکز</summary>
        ManageCorporates,

        /// <summary>مدیریت کاربران</summary>
        ManageUsers,

        /// <summary>مدیریت دسترسی ها</summary>
        ManagePermissions,




        // --------------------------------- دسترسی تمام منوها
        /*
691	RegSyndrom	ثبت مینیمم
692	RegVisitCount	ثبت تعداد بیماران مراجعه کننده / بستری
693	ListVisitCount	لیست خطی تعداد بیماران مراجعه کننده / بستری
694	RegMaximum	ثبت ماکزیمم
695	ListMinimum	گزارش لیست خطی مینیمم
696	ListMaximum	گزارش لیست خطی ماکزیمم
697	ListLog	مشاهده Logها
698	ReportMaxRespiratory	موارد شدید تنفسی
699	ReportSentinel	گزارش موارد سندروم از پایگاه ها
700	ReportILIFlow	گزارش روند سندروم
701	ReportMap	گزارش نقشه
702	RegSample	مشاهده پرونده بیمار (ثبت نمونه)
703	RegLabResult	ثبت نتیجه آزمایش
704	ReportLab	گزارش آزمایشگاه
705	ListLabs	لیست آزمایشگاه ها
706	RegLab	ثبت آزمایشگاه جدید
707	ThresholdMap	نقشه آستانه هشدار
708	ThresholdWarnings	هشدارهای صادر شده
709	ThresholdSettings	تنظیمات آستانه هشدار
710	ThresholdAdd	ثبت آستانه هشدار
711	RegUniversity	تعریف دانشگاه جدید
712	RegNetwork	تعریف شبکه بهداشت جدید
713	RegCenter	تعریف بیمارستان / مرکز بهداشتی درمانی / مرکز تجمعی
714	RegSubCenter	تعریف پایگاه بهداشت / خانه بهداشت
715	ListCorporates	لیست خطی مراکز
716	MngUsers	مدیریت کاربران
       */



        /// <summary>ثبت مینیمم</summary>
        RegSyndrom,

        /// <summary>ثبت تعداد بیماران مراجعه کننده / بستری</summary>
        RegVisitCount,

        /// <summary>لیست خطی تعداد بیماران مراجعه کننده / بستری</summary>
        ListVisitCount,

        /// <summary>ثبت ماکزیمم</summary>
        RegMaximum,

        /// <summary>گزارش لیست خطی مینیمم</summary>
        ListMinimum,

        /// <summary>گزارش لیست خطی ماکزیمم</summary>
        ListMaximum,

        /// <summary>مشاهده Logها</summary>
        ListLog,

        /// <summary>موارد شدید تنفسی</summary>
        ReportMaxRespiratory,

        /// <summary>گزارش موارد سندروم از پایگاه ها</summary>
        ReportSentinel,

        /// <summary>گزارش روند سندروم</summary>
        ReportILIFlow,

        /// <summary>گزارش نقشه</summary>
        ReportMap,

        /// <summary>مشاهده پرونده بیمار (ثبت نمونه)</summary>
        RegSample,

        /// <summary>ثبت نتیجه آزمایش</summary>
        RegLabResult,

        /// <summary>گزارش آزمایشگاه</summary>
        ReportLab,

        /// <summary>لیست آزمایشگاه ها</summary>
        ListLabs,

        /// <summary>ثبت آزمایشگاه جدید</summary>
        RegLab,

        /// <summary>نقشه آستانه هشدار</summary>
        ThresholdMap,

        /// <summary>هشدارهای صادر شده</summary>
        ThresholdWarnings,

        /// <summary>تنظیمات آستانه هشدار</summary>
        ThresholdSettings,

        /// <summary>ثبت آستانه هشدار</summary>
        ThresholdAdd,

        /// <summary>تعریف دانشگاه جدید</summary>
        RegUniversity,

        /// <summary>تعریف شبکه بهداشت جدید</summary>
        RegNetwork,

        /// <summary>تعریف بیمارستان / مرکز بهداشتی درمانی / مرکز تجمعی</summary>
        RegCenter,

        /// <summary>تعریف پایگاه بهداشت / خانه بهداشت</summary>
        RegSubCenter,

        /// <summary>لیست خطی مراکز</summary>
        ListCorporates,

        /// <summary>مدیریت کاربران</summary>
        MngUsers,

        /// <summary>گزارش جامع اپیدمیک مینیمم</summary>
        ReportEpidemicMin,

        /// <summary>گزارش جامع اپیدمیک ماکزیمم</summary>
        ReportEpidemicMax,

        /// <summary>گزارش رتبه بندی آزمایشگاه ها</summary>
        LabGrading,

        /// <summary>دریافت پیامک آستانه هشدار</summary>
        ReceiveThresholdWarningSms

    }


    public enum LabBasicDataType
    {
        Virus = 1,
        SubVirusType = 2,
        Bacteria = 3,
        SubBacteriaType = 4,
        vp_4 = 5,
        vp_7 = 6,
        SerotypeVirus = 7,
        AniBodyInSerotypeing = 8,
        ResistanceToAntibioticsStatuses = 9,
        ResistanceToAntibioticsInBaceriaDiseases = 10,
        ResistanceToAntibioticsInVirusDiseases = 11,
        PoisionType = 12,
        XnoType = 13,
        BioType = 14,
        SeroType = 15,
        Chlora_Toxin = 16,
        Parazit = 18,
        Shiga_Toxin = 19,
        Toxin_Type = 20,
        CoInfection = 21,
        TwinVirus = 29,
        TwinSubVirusType = 30,
        DetectionMethod = 31,
        BordetellaType = 32
    }

    public enum SMSTemplate
    {
        CountVisit = 0,
        FormatNationalCode = 1,
        FormatFullFeature = 2,
        NotFormat = 3,
        NotFindNationalCode = 4,
        RegisterSyndromic = 5,
        AlertTheroshold = 6,
        InValidNationalCode = 7,
        DuplicateSyndrom = 8,
        WarningOtherUser = 9,
        WarningVisitCount = 10
    }

    public enum PreProcess
    {
        ThirdDays = 1,
        SevenDays = 2
    }
    public enum UserAccessDefualt
    {
        organization = 1,
        LabUser = 2,
        WarningThreshold = 45,
    }

    public enum TypeOfCenterType
    {
        Org = 0,
        Lab = 1,
    }

    public enum LogType
    {
        WindowsService = 1,
        SMS = 2,
        DataMart = 3,
        Web = 4,
        Theroshold = 5,
        WarningVisit = 6
    }

    public enum MaximumDataSetTypes
    {
        AdverseReaction = 1,
        DrugeHistory = 2,
        Diagnosis = 3,
        Complication = 4,
        DrugTretment = 5,
        ClinicalFindings = 6,
        PastMedicalHistory = 7,
        RequestLabs = 8,
        Country = 9,
        AreaLocatuion = 10,
        BirdHistory,
        deathhospitalward,
        deathtime,
        Complications,
        AdmissionType,
        DeathLocationName
    }


    public enum UserRole
    {
        Admin,
        Network,
        Center,
        University,
        Lab,
        /// <summary>کاربر ناظر: به جز تغییر داده ها بقیه دسترسی ها را دارد</summary>
        ReadOnly,

        /// <summary>دریافت کننده پیام آستانه هشدار</summary>
        ThresholdWarningReceiver
    }

    public enum BasicDataTypeCode
    {
        /// <summary></summary>
        PrimaryLabResult = 100,

        /// <summary></summary>
        Syndrom = 101,

        /// <summary></summary>
        LabSampleQuality = 102,

        /// <summary></summary>
        Virus = 103,

        /// <summary></summary>
        SubVirus = 104,

        /// <summary></summary>
        RegisterSyndromStep = 105,

        /// <summary>وضعیت </summary>
        Discharge = 106,

        /// <summary>روش آستانه هشدار</summary>
        ThresholdMethod = 107,

        /// <summary>روش پیش پردازش در روش CuSum آستانه هشدار</summary>
        CuSumPreProcessingMethod = 108,

        /// <summary>ویروس توام</summary>
        TwinVirus = 109,

        /// <summary>زیرگونه ویروس توام</summary>
        TwinSubVirusType = 110,

        /// <summary>متد شناسایی ویروس</summary>
        VirusDetectionMethod = 111,

        /// <summary>گونه Bordetella</summary>
        BordetellaType = 112,

        /// <summary>سطح آزمایشگاه</summary>
        LabLevel = 113,

        /// <summary>دسته بندی بیماری</summary>
        DiseaseCategory = 114,

        /// <summary>وضعیت اخطار آستانه هشدار</summary>
        ThresholdWarningStatus = 115,

        /// <summary>پارازیت (انگل)</summary>
        Parazit = 122,

        /// <summary>باکتری</summary>
        Bacteria = 123,

        /// <summary>زیرگونه باکتری</summary>
        SubBacteria = 127,

        /// <summary>مقاومت دارویی به آنتی بیوتیک بیماریهای باکتریایی</summary>
        ResistanceToAntibioticsInBaceriaDiseases = 124,

        /// <summary>وضعیت مقاومت دارویی - آنتی بیوتیک</summary>
        ResistanceToAntibioticsStatuses = 125,

        /// <summary>مقاومت دارویی به آنتی بیوتیک بیماریهای ویروسی</summary>
        ResistanceToAntibioticsInVirusDiseases = 126,

        /// <summary>آنتی ژن</summary>
        AntiGen = 127,

        /// <summary>سم</summary>
        Toxicity = 128,

        /// <summary>وضعیت ترخیص</summary>
        DischargeState = 129
    }

    /// <summary>کد وضعیت ترخیص</summary>
    public enum DischargeStateCode
    {
        /*
        بهبودي کامل
        بهبودي نسبي
        ترخيص با ميل شخصي
        پيگيري
        انتقال به مرکز ديگر
        فرار
        غيره
        */
        /// <summary>بهبودی کامل</summary>
        CompletelyImprove = 1,

        /// <summary>بهبودی نسبی</summary>
        PartialImprove = 2,

        /// <summary>ترخیص با میل شخصی</summary>
        PatientWantedToDischarge = 3,

        /// <summary>پیگیری</summary>
        Track = 5,

        /// <summary>انتقال به مرکز دیگر</summary>
        Moved = 6,

        /// <summary>فرار</summary>
        Escape = 7,

        /// <summary>غیره</summary>
        etc = 8
    }

    public enum LabLevelCode
    {
        L1 = 1,
        L2 = 2,
        L3 = 3,
        L3R2 = 4,
        /*R2 = 5,*/
        R1 = 6
    }

    public enum ThresholdWarningStatusCode
    {
        Thrown = 1,
        Seen = 2,
        Done = 3,
        Rejected = 4,
        InProgress = 5,
        RealWarning = 6
    }

    public enum PrimaryLabResultCode
    {
        Positive = 1,
        Negative = 2,
        Reject = 3
    }

    public enum LogKey
    {
        /// <summary>ثبت مینیمم</summary>
        RegisterMinimum = 1,
        /// <summary>ثبت ماکزیمم</summary>
        RegisterMaximum,
        /// <summary>ورود به صفحه ثبت ماکزیمم - شبه آنفولانزا</summary>
        ViewRegisterMaximumFlu,
        /// <summary>ورود به صفحه ثبت ماکزیمم - اسهال حاد</summary>
        ViewRegisterMaximumEshal,
        /// <summary>ورود به صفحه ثبت ماکزیمم - شدید تنفسی</summary>
        ViewRegisterMaximumTanafosi,
        /// <summary>ورود به صفحه ثبت مینیمم</summary>
        ViewMinimum,
        /// <summary>ثبت مراجعه روزانه</summary>
        RegisterDailyVisits,
        /// <summary>ثبت نمونه</summary>
        RegisterSample,
        /// <summary>ثبت نتیجه آزمایشگاه</summary>
        RegisterLabResult,
        /// <summary>گرفتن خروجی لیست خطی - مینیمم</summary>
        ExportMinimum,
        /// <summary>گرفتن خروجی لیست خطی - ماکزیمم</summary>
        ExportMaximum,
        /// <summary>تغییر کلمه عبور</summary>
        ChangePassword,
        /// <summary>دانلود فایل راهنما</summary>
        HelpFileDownload,
        /// <summary>مراجعه به صفحه سوالات متداول</summary>
        ViewFAQ,
        /// <summary>مراجعه به صفحه آزمایشگاه</summary>
        ViewLab,
        /// <summary>مراجعه به صفحه مشاهده عملیات کاربران</summary>
        ViewLogs,
        /// <summary>دانلود برنامه اندروید</summary>
        DownloadAndroidApp,
        /// <summary>دانلود فرم خام</summary>
        DownloadRawForm,


        /// <summary>حذف مینیمم</summary>
        DeleteMinimumSyndrom,

        /// <summary>بازیابی مینیمم</summary>
        RetrieveMinimumSyndrom,

        /// <summary>حذف ماکزیمم</summary>
        DeleteMaximumSyndrom,

        /// <summary>بازیابی ماکزیمم</summary>
        RetrieveMaximumSyndrom,

        /// <summary>تبدیل نوع سندرم - از شبه آنفولانزا به شدید تنفسی و بالعکس</summary>
        ChangeMaximumType,
        /// <summary>حذف نمونه آزمایشگاه</summary>
        DeleteSample,
        /// <summary>بازیابی نمونه آزمایشگاه</summary>
        RetrieveSample,
        /// <summary>حذف تعداد مراجعین</summary>
        DeleteVisit,
        /// <summary>
        /// "ثبت مراکز"
        /// </summary>
        RegisterCorporate,
        /// <summary>
        /// "ورود به صفحه لیست خطی مراکز"
        /// </summary>
        ViewCorporate,
        /// <summary>
        /// "ویرایش لیست خطی مراکز"
        /// </summary>
        EditCorporate,
        /// <summary>
        /// ثبت آزمایشگاه جدید
        /// </summary>
        RegisterLabCorp,
        /// <summary>
        /// حذف آزمایشگاه 
        /// </summary>
        DeleteLabCorp,
        /// <summary>
        /// ثبت آزمایش های قابل انجام توسط آزمایشگاه 
        /// </summary>
        RegisterAssignment,
        /// <summary>
        /// حذف آزمایش های قابل انجام توسط آزمایشگاه 
        /// </summary>
        DeleteAssignment,
        /// <summary>
        /// لیست خطی (مینیمم) 
        /// </summary>
        ViewReportMin,
        /// <summary>
        ///لیست اطلاعات پیشرفته سندروم (ماکزیمم)
        /// </summary>
        ViewReportPro,
        /// <summary>
        ///مراجعه به لیست خطی تنظیمات آستانه هشدار
        /// </summary>
        ViewTheroshold,
        /// <summary>
        ///تنظیم آستانه هشدار جدید
        /// </summary>
        RegisterTheroshold,
        /// <summary>
        ///اصلاح آستانه هشدار 
        /// </summary>
        ManipulateThreshold,
        /// <summary>
        ///ثبت کاربران 
        /// </summary>
        RegisterUser,
        /// <summary>
        ///اصلاح کاربران 
        /// </summary>
        ManipulateUser,


    }


    /// <summary>کد انواع سندرم</summary>
    public enum SyndromTypeCode
    {
        /// <summary>آنفولانزا</summary>
        Flu = 1,
        /// <summary>اسهال حاد</summary>
        Eshal_Had = 2,
        /// <summary>شدید تنفسی</summary>
        Shadid_Tanafosi = 3
    }

    public enum RegisterSyndromStepCode
    {
        /// <summary>اطلاعات فردی</summary>
        PrimaryInfo = 1,

        /// <summary>تاریخ های مهم</summary>
        ImportantDates = 2,

        /// <summary>منبع آب و غذا</summary>
        FoodSource = 3,

        /// <summary>علائم بدو ورود</summary>
        Symptoms = 4,

        /// <summary>تشخیص افتراقی</summary>
        Diagnosis = 5,

        /// <summary>سابقه بیماری</summary>
        MedicalHistory = 6,

        /// <summary>سابقه مصرف دارو</summary>
        DrugHistory = 7,

        /// <summary>سابقه درمانهای بیمارستانی</summary>
        Hospital = 8,

        /// <summary>عوارض</summary>
        Complication = 9,

        /// <summary>ترخیص / بستری / فوت</summary>
        DeathStayOrLeave = 10
    }

    public enum ChartGrouping
    {
        Day = 1,
        Week = 2,
        Month = 3,
        Year = 4
    }



    /// <summary>روش محاسبه آستانه هشدار</summary>
    public enum ThresholdMethod
    {
        /// <summary>تعداد مطلق</summary>
        AbsoluteValue = 1,

        /// <summary>نسبت افزایش</summary>
        RelativeIncrease = 2,

        /// <summary></summary>
        StatiscalCutOffPoints = 3,

        /// <summary></summary>
        CuSum = 4,

        // /// <summary></summary>
        // EWMA = 5,
        // 
        // /// <summary></summary>
        // BaseLineLimitedCusum = 6
    }

    /// <summary>مبنای محاسبه آستانه هشدار</summary>
    public enum ThresholdValueType
    {
        /// <summary>تعداد</summary>
        Count = 1,

        /// <summary>درصد</summary>
        Percent = 2

    }

    /// <summary>
    /// روش پیش پردازش داده ها رو آستانه هشدار CuSum
    /// </summary>
    public enum CuSumPreProcessingMethod
    {
        MovingAverage_3Days = 3,
        MovingAverage_7Days = 7,
        HoltWinters = 8
    }

    public enum DiseaseCode
    {
        SimpleVirus = 1, // ویروسی ساده
        WithSubVirus = 2, // ویروسی با زیرگونه
        Simple = 3, // بدون جزئیات
        Method = 4, // با متد
        Resistence = 5, // ویروسی با زیرگونه با مقاومت داروی
        Parazit = 6, // انگل
        BacteriaWithResistence = 7, // باکتری با مقاومت دارویی
        BacteriaWithResistenceAndToxin = 8, // باکتری / زیرباکتری با مقاومت دارویی و توکسین
        BacteriaWithToxinAndGrowth = 9,  // باکتری با توکسین و کشت
        VirusWithAntiGen = 10,  // ویروس با آنتی ژن
        Toxicity = 11,  // مسمومیت
    }

    public enum AreaLocationType
    {
        Province = 1,
        City = 2
    }

}
