using Postgresql.Core;

namespace Postgresql.Candidate;

public class CandidateReader : ICandidateReader
{
    private readonly IPostgreSqlDriver _postgreSqlDriver;

    public CandidateReader(IPostgreSqlDriver postgreSqlDriver)
    {
        _postgreSqlDriver = postgreSqlDriver;
    }

    public async Task<Models.Candidate> GetCandidate(string email)
    {
        var sql = $@"
            SELECT * 
            FROM {TableConstants.CandidateTableName}
            WHERE Email = '{email}'
            ";
        return await _postgreSqlDriver.QueryFirstOrDefaultAsync<Models.Candidate>(sql, email);
    }
}