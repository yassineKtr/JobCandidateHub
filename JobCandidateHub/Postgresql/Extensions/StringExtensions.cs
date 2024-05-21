namespace Postgresql.Extensions;

public static class StringExtensions
{
    public static string ToPostgreColumns(this IEnumerable<string> that) =>
        string.Join(", ", that);

    public static IEnumerable<string> ToPostgresParameters(this IEnumerable<string> that)
    {
        var str = new List<string>();
        foreach (var value in that)
        {
            str.Add($"@{value.Trim('"')}");
        }

        return str.AsEnumerable();
    }

    public static IEnumerable<string> ToPostgresUpdateStatement(this IEnumerable<string> that, IEnumerable<string> values)
    {
        var str = new List<string>();
        var columnsValues = that.Zip(values.ToPostgresParameters());
        foreach (var value in columnsValues)
        {
            str.Add($"{value.First}={value.Second}");
        }

        return str.AsEnumerable();
    }

    public static string AddMetaDataToSqlRequest(this string sql) =>
        sql.Trim().StartsWith("SELECT") ? sql : sql.Insert(0, "/*REPLICATION*/ ");
}
