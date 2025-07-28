using ApplicationCore.Entities.Collectes;
using ApplicationCore.Entities.Location;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        
    }
}
