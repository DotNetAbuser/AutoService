namespace Infrastructure.Repositories;

public class RequestRepository(
    ApplicationDbContext _dbContext)
    : IRequestRepository
{
    public async Task<PaginatedData<RequestEntity>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var query = _dbContext.Requests
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            query = query.Where(r =>
                r.User.LastName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.FirstName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.Email.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.Brand.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.Model.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.ServiceType.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
        }
        
        var list = await query
            .OrderByDescending(x => x.Created)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.User)
            .Include(x => x.Brand)
            .Include(x => x.Model)
            .Include(x => x.ServiceType)
            .Include(x => x.Status)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
        var totalCount = await query
            .CountAsync();
        return new PaginatedData<RequestEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<RequestEntity>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms)
    {
        var query = _dbContext.Requests
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            query = query.Where(r =>
                r.User.LastName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.FirstName.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.Email.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.User.PhoneNumber.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.Brand.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.Model.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase) ||
                r.ServiceType.Name.Contains(searchTerms, StringComparison.CurrentCultureIgnoreCase));
        }
        
        var list = await query
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Created)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.User)
            .Include(x => x.Brand)
            .Include(x => x.Model)
            .Include(x => x.ServiceType)
            .Include(x => x.Status)
            .ToListAsync();
        var totalCount = await query
            .Where(x => x.UserId == userId)
            .CountAsync();
        return new PaginatedData<RequestEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<RequestEntity?> GetByIdAsync(Guid requestId)
    {
        return await _dbContext.Requests
            .AsNoTracking()
            .Include(x => x.User)
            .Include(x => x.Brand)
            .Include(x => x.Model)
            .Include(x => x.ServiceType)
            .Include(x => x.Status)
            .SingleOrDefaultAsync(x => x.Id == requestId);
    }

    public async Task UpdateAsync(RequestEntity entity)
    {
        _dbContext.Requests.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateAsync(RequestEntity entity)
    {
        await _dbContext.Requests.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(RequestEntity entity)
    {
        _dbContext.Requests.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}