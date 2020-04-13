using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MeHospedar.Models;
using System.Linq;
using System.Web;
using MeHospedar.Migrations;
using MeHospedar.Areas.Usuarios.Models;
using MeHospedar.Areas.Hoteis.Models;

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
        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estrutura> Estruturas { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<CafeDaManha> CafesDaManha { get; set; }
        public DbSet<Internet> Internetes { get; set; }
    }
}