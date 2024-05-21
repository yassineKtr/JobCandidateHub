namespace Postgresql;

public class PostgreSqlConfiguration
{
    public required string Host { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Database { get; set; }
    public bool Pooling { get; set; }
    public int Port { get; set; }
    public int MinPoolSize { get; set; } = 5;
    public int MaxPoolSize { get; set; } = 30;
    public bool IncludeErrorDetail { get; set; } = true;
    public int CommandTimeout { get; set; } = 45;
    public int Timeout { get; set; } = 45;
    public int ConnectionPruningInterval { get; set; } = 10;
    public int ConnectionIdleLifetime { get; set; } = 200;
}