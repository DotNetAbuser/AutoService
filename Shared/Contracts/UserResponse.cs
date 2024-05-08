namespace Shared.Contracts;

public record UserResponse(
    Guid Id,
    string LastName,
    string FirstName,
    string Email,
    string PhoneNumber,
    bool IsBanned);