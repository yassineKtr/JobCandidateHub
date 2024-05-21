using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Postgresql.Candidate;
using Postgresql.Core;

namespace Postgresql;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UsePostgreSql(this IServiceCollection services,
        IConfigurationSection configuration) =>
        services
            .Configure<PostgreSqlConfiguration>(configuration)
            .AddTransient<IBuildPostgreSqlConnection, PostgreSqlConnectionFactory>()
            .AddTransient(x => x.GetService<IOptions<PostgreSqlConfiguration>>().Value)
            .AddTransient<IWriteCandidate,CandidateWriter>()
            .AddTransient<ICandidateReader,CandidateReader>()
            .AddTransient<IPostgreSqlDriver,PostgreSqlDriver>();
}