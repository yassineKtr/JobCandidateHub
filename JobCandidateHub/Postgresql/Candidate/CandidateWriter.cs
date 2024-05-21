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

    public Task SetCandidate(Models.Candidate model)
        => _postgreSqlDriver.Upsert(TableConstants.CandidateTableName, TableConstants.CandidatesTableColumns, model, TableConstants.CandidateConstraint);
}