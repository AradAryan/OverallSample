﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class FAQDBEntities : DbContext
    {
        public FAQDBEntities()
            : base("name=FAQDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TableFAQ> TableFAQs { get; set; }
    
        public virtual ObjectResult<SP_GetActiveUsers_Result> SP_GetActiveUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetActiveUsers_Result>("SP_GetActiveUsers");
        }
    
        public virtual ObjectResult<SP_GetAllUsers_Result> SP_GetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllUsers_Result>("SP_GetAllUsers");
        }
    
        public virtual ObjectResult<SP_GetActiveFields_Result> SP_GetActiveFields()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetActiveFields_Result>("SP_GetActiveFields");
        }
    
        public virtual ObjectResult<SP_GetAllFields_Result> SP_GetAllFields()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllFields_Result>("SP_GetAllFields");
        }
    }
}
