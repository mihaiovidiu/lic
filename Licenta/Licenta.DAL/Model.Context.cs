﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licenta.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LicentaEntities : DbContext
    {
        public LicentaEntities()
            : base("name=LicentaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<pacient_simptome> pacient_simptome { get; set; }
        public virtual DbSet<Pacient> Pacients { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<simptome_boli> simptome_boli { get; set; }
    }
}
