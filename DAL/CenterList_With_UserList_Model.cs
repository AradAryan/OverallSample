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
    
    public partial class CenterList_With_UserList_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CenterTypeId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public Nullable<System.Guid> UniversityId { get; set; }
    }
}
