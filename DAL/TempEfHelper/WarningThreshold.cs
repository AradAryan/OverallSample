//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class WarningThreshold
    {
        public long WarningThresholdId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public int ThresholdValue { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public string PersianDate { get; set; }
        public int SyndromicId { get; set; }
        public int MethodId { get; set; }
        public Nullable<bool> IsView { get; set; }
        public Nullable<int> ViewerUserId { get; set; }
        public Nullable<System.DateTime> DateTimeView { get; set; }
        public string IpViewer { get; set; }
        public Nullable<bool> WarningThreshold1 { get; set; }
    }
}
