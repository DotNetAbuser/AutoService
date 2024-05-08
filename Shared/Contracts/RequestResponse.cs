namespace Shared.Contracts;

public record RequestResponse(
    Guid Id,
    string LastName,
    string FirstName,
    string Email,
    string PhoneNumber,
    string BrandName,
    string ModelName,
    int Year,
    string ServiceTypeName,
    decimal Price,
    DateTime Created);