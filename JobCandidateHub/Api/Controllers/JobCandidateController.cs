using Microsoft.AspNetCore.Mvc;
using Postgresql.Candidate;
using Postgresql.Models;

namespace Api.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class JobCandidateController : ControllerBase
{
    private readonly IWriteCandidate _writeCandidate;

    public JobCandidateController(IWriteCandidate writeCandidate)
    {
        _writeCandidate = writeCandidate;
    }

    [HttpPost("SetCandidate")]
    public Task SetCandidateInfos([FromBody] Candidate dto) 
        => _writeCandidate.SetCandidate(dto);
}