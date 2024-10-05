using System.ClientModel;
using Jobby.Domain.Repositories;
using JobGuard.Application.Abstractions.Services;
using JobGuard.Application.Verifications.Jobs;
using JobGuard.Domain.Repositories;
using JobGuard.Infrastructure.Postgres;
using JobGuard.Infrastructure.Postgres.Repositories;
using JobGuard.Infrastructure.Services.OpenAi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Chat;
using Quartz;

namespace JobGuard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddOpenAi(services, configuration);
        AddPersistence(services, configuration);
        AddQuartz(services);
        
        return services;
    }

    private static void AddOpenAi(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ChatClient>(_ => new ChatClient(
            "gpt-4o-mini", new ApiKeyCredential(configuration["OpenAi:ApiKey"]!)));
        services.AddScoped<IOpenAiService, OpenAiService>();
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PostgresAppDbContext>(
            (_, optionsBuilder) =>
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresDb"));
            });

        services.AddScoped<IVerificationRepository, VerificationsRepository>();
        services.AddScoped<IVacancyRepository, VacancyRepository>();
        services.AddScoped<IDataPieceRepository, DataPieceRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddQuartz(IServiceCollection services)
    {
        services.AddQuartz(opt =>
        {
            opt.InterruptJobsOnShutdown = true;

            opt.AddJob<ProcessVerificationBackgroundJob>(o =>
            {
                o.StoreDurably();
                o.WithIdentity(nameof(ProcessVerificationBackgroundJob));
            });
        });
        
        services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);
    }
}