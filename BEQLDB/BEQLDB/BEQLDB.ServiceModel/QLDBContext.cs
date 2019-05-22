using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceModel
{
    public class QLDBContext : DbContext
    {
        public QLDBContext(DbContextOptions<QLDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Network>()
                .HasMany(c => c.Contacts)
                .WithOne(n => n.Network);

            
        }

        public DbSet<Network> Networks { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
