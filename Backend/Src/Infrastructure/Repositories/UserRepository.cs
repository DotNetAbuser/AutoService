namespace Infrastructure.Repositories;

public class UserRepository(
    ApplicationDbContext _dbContext)
    : IUserRepository
{
    public async Task<PaginatedData<UserEntity>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var query = _dbContext.Users
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            query = query.Where(r =>
                r.LastName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.FirstName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.Email.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
        }
        
        var list = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalCount = await query
            .CountAsync();
        return new PaginatedData<UserEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<UserEntity?> GetByEmailWithRoleAsync(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Email == email);
    }

    public async Task<UserEntity?> GetByIdWithRoleAsync(Guid userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<UserEntity?> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == userId);
    }

    public async Task CreateAsync(UserEntity userEntity)
    {
        await _dbContext.Users.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByEmailAsync(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsExistByPhoneNumberAsync(string phoneNumber)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.PhoneNumber == phoneNumber);
    }
}