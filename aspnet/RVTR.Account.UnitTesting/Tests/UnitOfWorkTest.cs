using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.DataContext;
using RVTR.Account.DataContext.Repositories;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class UnitOfWorkTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<AccountContext> _options = new DbContextOptionsBuilder<AccountContext>().UseSqlite(_connection).Options;
    private static readonly AccountContext _context = new AccountContext(_options);
    public static readonly IEnumerable<object[]> _unitOfWorks = new List<object[]>
    {
      new object[] { new UnitOfWork(_context) }
    };

    [Theory]
    [MemberData(nameof(_unitOfWorks))]
    public async void Test_UnitOfWork_CommitAsync(UnitOfWork unitOfWork)
    {
      var actual = await unitOfWork.CommitAsync();

      Assert.True(actual >= 0);
    }
  }
}
