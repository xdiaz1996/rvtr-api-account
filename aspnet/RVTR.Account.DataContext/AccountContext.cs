using Microsoft.EntityFrameworkCore;

namespace RVTR.Account.DataContext
{
  /// <summary>
  /// Represents the _Account_ context
  /// </summary>
  public class AccountContext : DbContext
  {
    public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }
  }
}
