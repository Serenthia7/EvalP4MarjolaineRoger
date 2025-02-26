using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Repositories
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// List of Passwords
        /// </summary>
        public DbSet<Password> Passwords { get; set; }

        /// <summary>
        /// List of Applications
        /// </summary>
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                     .HasMany(a => a.Passwords)
                     .WithOne(p => p.Application)
                     .HasForeignKey(p => p.IdApplication)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}
