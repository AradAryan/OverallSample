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
    
    public partial class GetSMSLogs_Result
    {
        public Nullable<long> Row { get; set; }
        public long SMSID { get; set; }
        public string SmsContent { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public string MobileNumber { get; set; }
        public string PersianDate { get; set; }
        public Nullable<bool> IsSend { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string RegisterTime { get; set; }
    }
}
