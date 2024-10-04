using JobGuard.Domain.Entities;
using JobGuard.Infrastructure.Postgres.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobGuard.Infrastructure.Postgres.Configurations;

public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.ToTable("verifications");

        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Id).IsUnique();
        builder.HasIndex(x => x.ShortId).IsUnique();
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.ShortId)
            .HasColumnName("short_id")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.ModifiedAt)
            .HasColumnName("modified_at");

        builder.Property(x => x.ProvidedDetails)
            .HasColumnName("provided_details")
            .IsRequired();

        builder.Property("_providedLinks")
            .HasColumnName("provided_links")
            .HasConversion(typeof(ListToStringConverter));

        builder.HasMany(x => x.DataPieces)
            .WithOne()
            .HasForeignKey(x => x.VerificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}