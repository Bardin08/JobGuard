using JobGuard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobGuard.Infrastructure.Postgres.Configurations;

public class DataPieceConfiguration : IEntityTypeConfiguration<DataPiece>
{
    public void Configure(EntityTypeBuilder<DataPiece> builder)
    {
        builder.ToTable("data_pieces");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.ExternalId)
            .HasColumnName("external_id")
            .IsRequired();

        builder.Property(x => x.VerificationId)
            .HasColumnName("verification_id");
    }
}