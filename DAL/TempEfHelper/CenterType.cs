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
    
    public partial class CenterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string CenterTypeUniqId { get; set; }
        public Nullable<int> FieldOfView { get; set; }
        public Nullable<int> Special { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> StructureOrder { get; set; }
        public Nullable<int> SpecialReportTo { get; set; }
        public Nullable<bool> SpecialCenterType { get; set; }
    }
}
