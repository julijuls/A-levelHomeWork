﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlatDiplom.Models.PlatModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class nemo_freshEntities : DbContext
    {
        public nemo_freshEntities()
            : base("name=nemo_freshEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About_banks> About_banks { get; set; }
        public virtual DbSet<AccessLogWeb> AccessLogWeb { get; set; }
        public virtual DbSet<AccessLogWebIpAddress> AccessLogWebIpAddress { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<DebitNotes> DebitNotes { get; set; }
        public virtual DbSet<PaymentsRU> PaymentsRU { get; set; }
        public virtual DbSet<PTariffsUA> PTariffsUA { get; set; }
        public virtual DbSet<PurofPayment> PurofPayment { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<PrePayment> PrePayment { get; set; }
    }
}
