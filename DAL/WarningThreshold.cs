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
    
    public partial class WarningThreshold
    {
        public WarningThreshold()
        {
            this.ThresholdWarningReceivers = new HashSet<ThresholdWarningReceiver>();
            this.ThresholdWarningStatus = new HashSet<ThresholdWarningStatu>();
            this.ThresholdWarningMetaDatas = new HashSet<ThresholdWarningMetaData>();
        }
    
        public int WarningThresholdId { get; set; }
        public int ThresholdId { get; set; }
        public decimal ThresholdValue { get; set; }
        public decimal CurrentValue { get; set; }
        public System.DateTime RegisterDateTime { get; set; }
        public string PersianDate { get; set; }
        public bool ApprovedWarningIsSentToManagers { get; set; }
    
        public virtual Theroshold TblTheroshold { get; set; }
        public virtual ICollection<ThresholdWarningReceiver> ThresholdWarningReceivers { get; set; }
        public virtual ICollection<ThresholdWarningStatu> ThresholdWarningStatus { get; set; }
        public virtual ICollection<ThresholdWarningMetaData> ThresholdWarningMetaDatas { get; set; }
    }
}
