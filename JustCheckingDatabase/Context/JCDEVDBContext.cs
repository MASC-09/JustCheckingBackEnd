using JustCheckingDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace JustCheckingDatabase.Context
{
    public class JCDEVDBContext : DbContext
    {
        public JCDEVDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
        }

        public DbSet<DayRecord> DayRecords { get; set; }
        public DbSet<Macrocard> Macrocards { get; set; }
        public DbSet<MacroDistribution> MacroDistributions { get; set; }
        public DbSet<MealRecord> MealRecords{ get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserHistory> UserHistory { get; set; }
        public DbSet<UserPlan> UsersPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the User-Macrocard relationship
            modelBuilder.Entity<Macrocard>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Specify DeleteBehavior.Restrict to avoid cascade paths

            base.OnModelCreating(modelBuilder);
        }

    }
}
