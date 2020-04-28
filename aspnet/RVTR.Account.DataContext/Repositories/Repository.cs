using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RVTR.Account.DataContext.Repositories
{
  /// <summary>
  /// Represents the _Repository_ generic
  /// </summary>
  /// <typeparam name="TEntity"></typeparam>
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly DbSet<TEntity> _db;

    public Repository(AccountContext context)
    {
      _db = context.Set<TEntity>();
    }

    public async Task DeleteAsync(int id)
    {
      var entry = await SelectAsync(id);

      if (entry != null)
      {
        _db.Remove(entry);
      }
    }

    public async Task InsertAsync(TEntity entry)
    {
      if (entry != null)
      {
        await _db.AddAsync(entry);
      }
    }

    public async Task<IEnumerable<TEntity>> SelectAsync() => await _db.ToListAsync();

    public async Task<TEntity> SelectAsync(int id) => id > 0 ? await _db.FindAsync(id) : null;

    public TEntity Update(TEntity entry) => _db.Update(entry).Entity;
  }
}
