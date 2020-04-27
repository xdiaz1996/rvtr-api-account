using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.DataContext;
using RVTR.Account.DataContext.Repositories;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class UnitOfWorkTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("DataSource=:memory:");
    private static readonly DbContextOptions<AccountContext> _options = new DbContextOptionsBuilder<AccountContext>().UseSqlite(_connection).Options;
    private readonly AccountContext _context = new AccountContext(_options);

    [Fact]
    public void Test_UnitOfWork_CommitAsync()
    {
      var sut = new UnitOfWork(_context);

      Action actual = () => sut.CommitAsync();

      Assert.IsType<Action>(actual);
    }
  }
}
