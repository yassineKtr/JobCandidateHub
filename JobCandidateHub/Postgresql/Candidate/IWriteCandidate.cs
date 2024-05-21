namespace Postgresql.Candidate;

public interface IWriteCandidate
{
    Task SetCandidate(Models.Candidate model);
}