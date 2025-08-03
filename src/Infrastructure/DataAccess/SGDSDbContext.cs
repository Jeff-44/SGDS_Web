using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
using ApplicationCore.Entities.Reference;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class SGDSDbContext : IdentityDbContext<ApplicationUser>
    {
        public SGDSDbContext(DbContextOptions<SGDSDbContext> options)
            : base(options)
        {
        }
        public DbSet<Donneur> Donneurs { get; set; }
        public DbSet<Don> Dons { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Collecte> Collectes { get; set; }
        public DbSet<Centre> Centres { get; set; }

        //Reference data
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Arrondissement> Arrondissements { get; set; }
        public DbSet<Commune> Communes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Define the one-to-one relationship between Donneur and Dossier
            // And Limit the queries to only one Dossier per Donneur
            builder.Entity<Dossier>()
                   .HasOne(dossier => dossier.Donneur)
                   .WithOne(donneur => donneur.Dossier)
                   .HasForeignKey<Dossier>(dossier => dossier.DonneurId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Define Indexes for unique constraints
            builder.Entity<Dossier>()
                   .HasIndex(dossier => dossier.DonneurId)
                   .IsUnique();

            builder.Entity<Collecte>()
                     .HasIndex(collecte => collecte.Code)
                     .IsUnique();

            //Reference data relationships
            builder.Entity<Departement>()
                   .HasMany(departement => departement.Arrondissements)
                   .WithOne(arrondissement => arrondissement.Departement)
                   .HasForeignKey(arrondissement => arrondissement.DepartementId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Arrondissement>()
                   .HasMany(arrondissement => arrondissement.Communes)
                   .WithOne(commune => commune.Arrondissement)
                   .HasForeignKey(commune => commune.ArrondissementId)
                   .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
