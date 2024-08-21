using DiaryPetProject.Domain.Interfaces.Repositories;

namespace DiaryPetProject.DAL.Repositories;

public class BaseRepository<TEntity>(ApplicationDbContext dbContext) 
    : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}
