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
    
    public partial class TblSmsLog
    {
        public long SMSID { get; set; }
        public string SmsContent { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public string MobileNumber { get; set; }
        public string PersianDate { get; set; }
        public Nullable<bool> IsSend { get; set; }
    }
}
