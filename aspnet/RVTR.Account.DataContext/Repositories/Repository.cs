using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.ObjectModel.Models;

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
      try
      {
        _db.Remove(await SelectAsync(id));
      }
      catch
      {
        return;
      }
    }

    public async Task InsertAsync(TEntity entity) => await _db.AddAsync(entity);

    public async Task<IEnumerable<TEntity>> SelectAsync() => await _db.ToListAsync();

    public async Task<TEntity> SelectAsync(int id) => await _db.FindAsync(id);

    public TEntity Update(TEntity entity) => _db.Update(entity).Entity;
  }
}
