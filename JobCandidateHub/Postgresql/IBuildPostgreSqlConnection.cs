using Npgsql;

namespace Postgresql;

public interface IBuildPostgreSqlConnection
{
    NpgsqlConnection GetSqlConnection();
}