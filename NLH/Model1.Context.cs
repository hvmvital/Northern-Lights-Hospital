﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NLH
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NLHEntities2 : DbContext
    {
        public NLHEntities2()
            : base("name=NLHEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assurance> Assurances { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<dossierAdmission> dossierAdmissions { get; set; }
        public virtual DbSet<Lit> Lits { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<TypeLit> TypeLits { get; set; }
    }
}