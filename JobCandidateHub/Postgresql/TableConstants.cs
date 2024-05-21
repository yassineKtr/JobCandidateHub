namespace Postgresql;

public static class TableConstants
{
    #region Candidate

    public static readonly string CandidateTableName = "Candidates";
    public static IEnumerable<string> CandidatesTableColumns = new[]
    {
        "first_name", "last_name", "email", "call_time_interval", "linkedin_url", "github_url", "comment"
    };
    public static readonly string CandidateConstraint = "candidates_pkey";

    #endregion
}