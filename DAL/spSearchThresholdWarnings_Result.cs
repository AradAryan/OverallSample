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
    
    public partial class spSearchThresholdWarnings_Result
    {
        public Nullable<long> Row { get; set; }
        public int WarningThresholdId { get; set; }
        public int TherosholdID { get; set; }
        public long MethodID { get; set; }
        public Nullable<decimal> FixNumber { get; set; }
        public int SyndromicId { get; set; }
        public string SyndromicName { get; set; }
        public string MethodName { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceEnglishName { get; set; }
        public Nullable<long> PreProcessMethod { get; set; }
        public string PreProcessMethodTitle { get; set; }
        public Nullable<double> Factor { get; set; }
        public long UniversityId { get; set; }
        public string UniversityName { get; set; }
        public long NetworkId { get; set; }
        public string NetworkName { get; set; }
        public bool PercentBased { get; set; }
        public Nullable<int> TotalCount { get; set; }
        public bool Deleted { get; set; }
        public string PersianDate { get; set; }
        public decimal ThresholdValue { get; set; }
        public decimal CurrentValue { get; set; }
        public Nullable<long> LastStatusId { get; set; }
        public string LastStatusTitle { get; set; }
        public Nullable<bool> Unverified { get; set; }
        public string NetworkGuid { get; set; }
        public Nullable<decimal> MinAbsoluteLimit { get; set; }
    }
}
