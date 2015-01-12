using Microsoft.AspNet.Identity.EntityFramework;
using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data
{
    public class PsydptContext : IdentityDbContext<AppUser>
    {
        public PsydptContext()
            : base("PsydptConnection")
        {
            //AutomaticMigrationsEnabled = false;
            //Configuration.LazyLoadingEnabled = true;
        }


        public DbSet<PatientInfo> PatientInfos { get; set; }
        public DbSet<PatientSigeCaps> PatientSigeCaps { get; set; }
        public DbSet<Disorder> Disorders { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<PredictionPuntuation> PredictionPuntuations { get; set; }
        public DbSet<PredictionSetting> PredictionSettings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<PatientInfo>()
                .HasRequired(s => s.UserPatient)
                .WithOptional(s => s.PatientInfo)
                .Map(m => m.MapKey(new string[] { "PatientInfoId" }))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PatientSigeCaps>()
                .HasRequired(s => s.UserPatient)
                .WithOptional(s => s.PatientSigeCaps)
                .Map(m => m.MapKey(new string[] { "PatientSigeCapId" }))
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }


    
    }
}
