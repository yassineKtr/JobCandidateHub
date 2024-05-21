namespace Postgresql;

public static class TableConstants
{
    #region Candidate

    public static readonly string CandidateTableName = "Public.Candidates";
    public static IEnumerable<string> CandidatesTableColumns = new[]
    {
        "FirstName", "LastName", "Email", "CallTimeInterval", "LinkedinUrl", "GithubUrl", "Comment"
    };
    public static readonly string CandidateConstraint = "candidates_pkey";

    #endregion
}