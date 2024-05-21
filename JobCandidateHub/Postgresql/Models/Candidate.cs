namespace Postgresql.Models;

public class Candidate
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string LinkedinUrl { get; set; }
    public required string GithubUrl { get; set; }
    public required string CallTimeInterval { get; set; }
    public required string Comment { get; set; }

}