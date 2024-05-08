namespace Shared.Contracts;

public record ServiceTypeResponse(
    int Id,
    string Name,
    string Description,
    decimal Price);