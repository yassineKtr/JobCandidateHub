namespace Postgresql.Candidate;

public interface ICandidateReader
{
    Task<Models.Candidate> GetCandidate(string email);
}