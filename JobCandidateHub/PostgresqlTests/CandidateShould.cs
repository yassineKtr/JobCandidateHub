using FluentAssertions;
using Postgresql.Candidate;
using Postgresql.Models;

namespace PostgresqlTests;
[Collection("PostgresqlTests")]
public class CandidateShould
{
    private readonly IWriteCandidate _writeCandidate;
    private readonly ICandidateReader _candidateReader;

    public CandidateShould()
    {
        _writeCandidate = Helper.GetInstance<IWriteCandidate>();
        _candidateReader = Helper.GetInstance<ICandidateReader>();
    }

    [Fact]
    public async Task CreateCandidate()
    {
        var data = new Candidate
        {
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            PhoneNumber = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            LinkedinUrl = Guid.NewGuid().ToString(),
            GithubUrl = Guid.NewGuid().ToString(),
            CallTimeInterval = Guid.NewGuid().ToString(),
            Comment = Guid.NewGuid().ToString()
        };

        await _writeCandidate.SetCandidate(data);

        var result = await _candidateReader.GetCandidate(data.Email);
        result.FirstName.Should().Be(data.FirstName);
        result.LastName.Should().Be(data.LastName);
        result.PhoneNumber.Should().Be(data.PhoneNumber);
        result.Email.Should().Be(data.Email);
        result.LinkedinUrl.Should().Be(data.LinkedinUrl);
        result.GithubUrl.Should().Be(data.GithubUrl);
        result.CallTimeInterval.Should().Be(data.CallTimeInterval);
        result.Comment.Should().Be(data.Comment);
    }

    [Fact]
    public async Task UpdateCandidate()
    {
        var data = new Candidate
        {
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            PhoneNumber = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            LinkedinUrl = Guid.NewGuid().ToString(),
            GithubUrl = Guid.NewGuid().ToString(),
            CallTimeInterval = Guid.NewGuid().ToString(),
            Comment = Guid.NewGuid().ToString()
        };

        await _writeCandidate.SetCandidate(data);

        var newData = new Candidate
        {
            FirstName = Guid.NewGuid() + "updated",
            LastName = Guid.NewGuid() + "updated",
            PhoneNumber = Guid.NewGuid() + "updated",
            Email = data.Email,
            LinkedinUrl = Guid.NewGuid() + "updated",
            GithubUrl = Guid.NewGuid() + "updated",
            CallTimeInterval = Guid.NewGuid() + "updated",
            Comment = Guid.NewGuid() + "updated"

        };
        await _writeCandidate.SetCandidate(newData);
        var result = await _candidateReader.GetCandidate(data.Email);
        result.FirstName.Should().Be(newData.FirstName);
        result.LastName.Should().Be(newData.LastName);
        result.PhoneNumber.Should().Be(newData.PhoneNumber);
        result.Email.Should().Be(newData.Email);
        result.LinkedinUrl.Should().Be(newData.LinkedinUrl);
        result.GithubUrl.Should().Be(newData.GithubUrl);
        result.CallTimeInterval.Should().Be(newData.CallTimeInterval);
        result.Comment.Should().Be(newData.Comment);
    }
}