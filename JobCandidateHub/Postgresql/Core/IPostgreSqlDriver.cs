namespace Postgresql.Core;

public interface IPostgreSqlDriver
{
    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null);

    Task<int> Upsert(string tableName, IEnumerable<string> tableColumns, object values,
        string tableConstraint);

    Task<int> ExecuteAsync(string sql, object parameters = null);
}