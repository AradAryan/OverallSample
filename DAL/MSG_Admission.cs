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
    
    public partial class MSG_Admission
    {
        public long ID { get; set; }
        public long AdmissionID { get; set; }
        public long MsgID { get; set; }
    
        public virtual MSG TblMSG { get; set; }
        public virtual Admission TblAdmission { get; set; }
    }
}