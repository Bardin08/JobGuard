using JobGuard.Domain.Entities;
using JobGuard.Infrastructure.Postgres.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobGuard.Infrastructure.Postgres.Configurations;

public class VacancyConfiguration : IEntityTypeConfiguration<VacancyDetails>
{
    public void Configure(EntityTypeBuilder<VacancyDetails> builder)
    {
        builder.ToTable("vacancy_details");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.JobTitle)
            .HasColumnName("job_title")
            .IsRequired();

        builder.Property(x => x.JobDescription)
            .HasColumnName("job_description")
            .IsRequired();

        builder.Property(x => x.JobLocation)
            .HasColumnName("job_location");

        builder.Property(x => x.SalaryRange)
            .HasColumnName("salary_range");

        builder.Property(x => x.EmploymentType)
            .HasColumnName("employment_type");

        builder.Property(x => x.PostedDate)
            .HasColumnName("posted_date")
            .IsRequired();

        builder.Property(x => x.ApplicationDeadline)
            .HasColumnName("application_deadline");

        builder.Property("_dataSources")
            .HasColumnName("data_sources");

        builder.Property("_responsibilities")
            .HasColumnName("responsibilities")
            .HasConversion(typeof(ListToStringConverter));

        builder.Property("_qualifications")
            .HasColumnName("qualifications")
            .HasConversion(typeof(ListToStringConverter));
    }
}