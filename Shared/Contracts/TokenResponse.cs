namespace Shared.Contracts;

public record TokenResponse(
    [Required] string AuthToken,
    [Required] string RefreshToken);