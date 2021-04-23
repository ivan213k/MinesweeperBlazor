using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinesweeperServer.Configurations;
using MinesweeperServer.Models;

namespace MinesweeperServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<GameRecord> GameRecords { get; set; }

        public virtual DbSet<ComplexityLevel> ComplexityLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameRecordConfiguration());
            builder.ApplyConfiguration(new ComplexityLevelConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
