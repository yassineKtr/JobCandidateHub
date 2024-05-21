using Dapper;
using Postgresql.Extensions;

namespace Postgresql.Core;

public class PostgreSqlDriver : IPostgreSqlDriver
{
    private readonly IBuildPostgreSqlConnection _buildPostgreSqlConnection;
    public PostgreSqlDriver(IBuildPostgreSqlConnection buildPostgreSqlConnection)
    {
        _buildPostgreSqlConnection = buildPostgreSqlConnection;
    }
    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null)
    {
        await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
        await connection.OpenAsync();
        return await connection.QueryFirstOrDefaultAsync<T>(sql.AddMetaDataToSqlRequest(), parameters);
    }
    public Task<int> Upsert(string tableName, IEnumerable<string> tableColumns, object values,
        string tableConstraint)
    {
        var sql = GenerateUpsertSql(tableName, tableColumns, tableConstraint);
        return ExecuteAsync(sql, values);
    }

    private static string GenerateUpsertSql(string tableName, IEnumerable<string> tableColumns, string tableConstraint)
    {
        var sql = $@"INSERT INTO {tableName}({tableColumns.ToPostgreColumns()}) 
                    VALUES ({tableColumns.ToPostgresParameters().ToPostgreColumns()}) 
                    ON CONFLICT ON CONSTRAINT {tableConstraint} 
                    DO UPDATE SET {tableColumns.ToPostgresUpdateStatement(tableColumns).ToPostgreColumns()}";
        return sql;
    }

    public async Task<int> ExecuteAsync(string sql, object parameters = null)
    {
        await using var connection = _buildPostgreSqlConnection.GetSqlConnection();
        await connection.OpenAsync();
        return await connection.ExecuteAsync(sql.AddMetaDataToSqlRequest(), parameters);
    }
}