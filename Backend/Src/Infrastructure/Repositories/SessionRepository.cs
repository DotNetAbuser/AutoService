namespace Infrastructure.Repositories;

public class SessionRepository(
    ApplicationDbContext _dbContext)
    : ISessionRepository
{
    public async Task<SessionEntity?> GetByRefreshTokenAsync(string token)
    {
        return await _dbContext.Sessions
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Token == token);
    }

    public async Task CreateAsync(SessionEntity entity)
    {
        await _dbContext.Sessions.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(SessionEntity entity)
    {
        _dbContext.Sessions.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}