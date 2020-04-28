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
      var entity = await SelectAsync(id);

      if (entity != null)
      {
        _db.Remove(entity);
      }
    }

    public async Task InsertAsync(TEntity entry) => await _db.AddAsync(entry);

    public async Task<IEnumerable<TEntity>> SelectAsync() => await _db.ToListAsync();

    public async Task<TEntity> SelectAsync(int id) => await _db.FindAsync(id);

    public TEntity Update(TEntity entry) => _db.Update(entry).Entity;
  }
}
