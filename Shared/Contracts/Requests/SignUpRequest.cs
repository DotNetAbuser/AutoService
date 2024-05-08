namespace Shared.Contracts.Requests;

public class SignUpRequest
{
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}