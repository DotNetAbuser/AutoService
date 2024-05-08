namespace Shared;

public record PaginatedData<TItem>(
    IEnumerable<TItem> List,
    int TotalCount);