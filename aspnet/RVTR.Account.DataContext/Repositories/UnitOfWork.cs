using System.Threading.Tasks;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext.Repositories
{
  /// <summary>
  /// Represents the _UnitOfWork_ repository
  /// </summary>
  public class UnitOfWork
  {
    private readonly AccountContext _context;

    public Repository<AccountModel> Account { get; }
    public Repository<ProfileModel> Profile { get; }

    public UnitOfWork(AccountContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Represents the _UnitOfWork_ `Commit` method
    /// </summary>
    /// <returns></returns>
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
  }
}
