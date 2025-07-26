using ApplicationCore.Entities.Collectes;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        
    }
}
