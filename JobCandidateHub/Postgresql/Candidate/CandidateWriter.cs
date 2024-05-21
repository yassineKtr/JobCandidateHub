using Postgresql.Core;

namespace Postgresql.Candidate;

public class CandidateWriter
{
    private readonly IPostgreSqlDriver _postgreSqlDriver;
    private readonly IBuildPostgreSqlConnection _buildPostgreSqlConnection;

    public CandidateWriter(IPostgreSqlDriver postgreSqlDriver, IBuildPostgreSqlConnection buildPostgreSqlConnection)
    {
        _postgreSqlDriver = postgreSqlDriver;
        _buildPostgreSqlConnection = buildPostgreSqlConnection;
    }
}