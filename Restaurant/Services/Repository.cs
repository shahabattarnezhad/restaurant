using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Interfaces;

namespace Restaurant.Services;

public class Repository<T> : IRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    private DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
