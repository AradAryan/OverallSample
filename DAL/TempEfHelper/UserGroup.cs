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
    
    public partial class UserGroup
    {
        public UserGroup()
        {
            this.GroupsPermissions = new HashSet<GroupsPermission>();
            this.Rules = new HashSet<Rule>();
            this.RuleExtensions = new HashSet<RuleExtension>();
            this.UsersUserGroups = new HashSet<UsersUserGroup>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int SubSystemId { get; set; }
        public decimal FirstUserReg { get; set; }
        public string FirstDateReg { get; set; }
        public string IP { get; set; }
        public string ClientName { get; set; }
        public Nullable<bool> fullAdmin2 { get; set; }
        public Nullable<bool> partialAdmin1 { get; set; }
        public Nullable<bool> partialAdmin2 { get; set; }
    
        public virtual ICollection<GroupsPermission> GroupsPermissions { get; set; }
        public virtual ICollection<Rule> Rules { get; set; }
        public virtual ICollection<RuleExtension> RuleExtensions { get; set; }
        public virtual Subsystem Subsystem { get; set; }
        public virtual ICollection<UsersUserGroup> UsersUserGroups { get; set; }
    }
}
