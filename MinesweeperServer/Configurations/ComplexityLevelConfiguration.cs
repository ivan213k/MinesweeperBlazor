using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinesweeperServer.Models;

namespace MinesweeperServer.Configurations
{
    public class ComplexityLevelConfiguration : IEntityTypeConfiguration<ComplexityLevel>
    {
        public void Configure(EntityTypeBuilder<ComplexityLevel> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Complexity).IsRequired();
            builder.HasData(new ComplexityLevel(-1,"Beginner"), new ComplexityLevel(-2,"Intermediate"), new ComplexityLevel(-3,"Advanced"));
        }
    }
}
