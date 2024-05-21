using Postgresql.Core;

namespace Postgresql.Candidate;

public class CandidateWriter : IWriteCandidate
{
    private readonly IPostgreSqlDriver _postgreSqlDriver;

    public CandidateWriter(IPostgreSqlDriver postgreSqlDriver, IBuildPostgreSqlConnection buildPostgreSqlConnection)
    {
        _postgreSqlDriver = postgreSqlDriver;
    }

    public Task SetCandidate(Models.Candidate model)
        => _postgreSqlDriver.Upsert(TableConstants.CandidateTableName, TableConstants.CandidatesTableColumns, model, TableConstants.CandidateConstraint);
}