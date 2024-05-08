namespace Application.IServices;

public interface IRequestService
{
    Task<Result<PaginatedData<RequestResponse>>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize,
        string? searchTerms);
    Task<Result<PaginatedData<RequestResponse>>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, 
        int pageNumber, int pageSize,
        string? searchTerms);
    Task<Result<RequestResponse>> GetByIdAsync(Guid requestId);

    Task<Result> CreateAsync(CreateRequestRequest request);
    Task<Result> UpdateAsync(Guid requestId, UpdateRequestRequest request);
    Task<Result> DeleteAsync(Guid requestId);
    Task<Result> ChangeStatusAsync(Guid requestId, ChangeStatusRequest request);
}