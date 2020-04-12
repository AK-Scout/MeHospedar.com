using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MeHospedar.Models;
using System.Linq;
using System.Web;
using MeHospedar.Migrations;

namespace MeHospedar.Contexts
{
    public class EFContext :DbContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public EFContext() : base("Oficial")
        {
            //Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>()); // este comando DROPA o database e recria as tabelas com base no EFCOntext 
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }
        public DbSet<Viajante>Viajantes{ get; set; }
        

    }
}