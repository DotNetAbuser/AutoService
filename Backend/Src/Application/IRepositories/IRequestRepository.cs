namespace Application.IRepositories;

public interface IRequestRepository
{
    Task<PaginatedData<RequestEntity>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<PaginatedData<RequestEntity>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms);
    Task<RequestEntity?> GetByIdAsync(Guid requestId);
    
    Task UpdateAsync(RequestEntity entity);
    Task CreateAsync(RequestEntity entity);
    Task DeleteAsync(RequestEntity entity);
}