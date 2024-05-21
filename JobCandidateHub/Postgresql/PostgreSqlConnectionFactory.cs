using Npgsql;
using System.Reflection;

namespace Postgresql;

public class PostgreSqlConnectionFactory : IBuildPostgreSqlConnection
{
    private readonly NpgsqlConnectionStringBuilder _connectionStringBuilder;
    public PostgreSqlConnectionFactory(PostgreSqlConfiguration configOptions)
    {
        var configuration = configOptions;
        _connectionStringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = configuration.Host,
            Username = configuration.Username,
            Password = configuration.Password,
            Database = configuration.Database,
            Pooling = configuration.Pooling,
            Port = configuration.Port,
            CommandTimeout = configOptions.CommandTimeout,
            Timeout = configOptions.Timeout,
            MinPoolSize = configOptions.MinPoolSize,
            MaxPoolSize = configOptions.MaxPoolSize,
            ConnectionIdleLifetime = configOptions.ConnectionIdleLifetime,
            ConnectionPruningInterval = configOptions.ConnectionPruningInterval,
            ClientEncoding = "UTF8",
            Encoding = "UTF8",
            IncludeErrorDetail = configOptions.IncludeErrorDetail,
            ApplicationName = Assembly.GetEntryAssembly()?.GetName().Name ?? "JobCandidateHub",
            NoResetOnClose = true,
            Enlist = false
        };
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.EnableLegacyCaseInsensitiveDbParameters", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    public NpgsqlConnection GetSqlConnection() => new(_connectionStringBuilder.ConnectionString);

}