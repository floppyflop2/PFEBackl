﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PFEDatabaseEntities : DbContext
    {
        public PFEDatabaseEntities()
            : base("name=PFEDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Machines> Machines { get; set; }
        public virtual DbSet<Problems> Problems { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    }
}
