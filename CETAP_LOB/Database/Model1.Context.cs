﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CETAP_LOB.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CETAPEntities : DbContext
    {
        public CETAPEntities()
            : base("name=CETAPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TestName> TestNames { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<EasyPayFile> EasyPayFiles { get; set; }
        public virtual DbSet<EasyPayRecord> EasyPayRecords { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<BenchmarkLevel> BenchmarkLevels { get; set; }
        public virtual DbSet<Composit> Composits { get; set; }
        public virtual DbSet<FirstName> FirstNames { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<InstitutionMatch> InstitutionMatches { get; set; }
        public virtual DbSet<IntakeYear> IntakeYears { get; set; }
        public virtual DbSet<NewNBTNumber> NewNBTNumbers { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<QA> QAs { get; set; }
        public virtual DbSet<RecordsInQueue> RecordsInQueues { get; set; }
        public virtual DbSet<ScannedFile> ScannedFiles { get; set; }
        public virtual DbSet<ScanTracker> ScanTrackers { get; set; }
        public virtual DbSet<Surname> Surnames { get; set; }
        public virtual DbSet<TestAllocation> TestAllocations { get; set; }
        public virtual DbSet<TestProfile> TestProfiles { get; set; }
        public virtual DbSet<TestVenue> TestVenues { get; set; }
        public virtual DbSet<WriterList> WriterLists { get; set; }
        public virtual DbSet<WritersPayment> WritersPayments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TestRoom> TestRooms { get; set; }
        public virtual DbSet<Vw_EasyPayRecords> Vw_EasyPayRecords { get; set; }
    }
}
