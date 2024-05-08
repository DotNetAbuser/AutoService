namespace Application.IServices;

public interface IUserService
{
    Task<Result<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<Result<UserResponse>> GetByIdAsync(Guid userId);
    Task<Result> CreateAsync(SignUpRequest request);
}