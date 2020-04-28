using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.DataContext;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class AccountContextTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<AccountContext> _options = new DbContextOptionsBuilder<AccountContext>().UseSqlite(_connection).Options;
    private static readonly AccountContext _context = new AccountContext(_options);

    public AccountContextTest()
    {
      _connection.Open();
      _context.Database.EnsureCreated();
    }

    ~AccountContextTest()
    {
      _connection.Close();
    }

    [Fact]
    public async void Test_Create_AccountContext()
    {
      Assert.Empty(await _context.Accounts.ToListAsync());
      Assert.Empty(await _context.Profiles.ToListAsync());
    }
  }
}
