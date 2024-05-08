namespace Application.IRepositories;

public interface IUserRepository
{
    Task<PaginatedData<UserEntity>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<UserEntity?> GetByEmailWithRoleAsync(string email);
    Task<UserEntity?> GetByIdWithRoleAsync(Guid userId);
    Task<UserEntity?> GetByIdAsync(Guid userId);
    
    Task CreateAsync(UserEntity userEntity);
    
    Task<bool> IsExistByEmailAsync(string email);
    Task<bool> IsExistByPhoneNumberAsync(string phoneNumber);
}