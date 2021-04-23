using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinesweeperServer.Models;

namespace MinesweeperServer.Configurations
{
    public class GameRecordConfiguration : IEntityTypeConfiguration<GameRecord>
    {
        public void Configure(EntityTypeBuilder<GameRecord> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Player).WithMany().HasForeignKey(g => g.PlayerId);
            builder.HasOne(g => g.ComplexityLevel).WithMany().HasForeignKey(g => g.ComplexityLevelId);
        }
    }
}
