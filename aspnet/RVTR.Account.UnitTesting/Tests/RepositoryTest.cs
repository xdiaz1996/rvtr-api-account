using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.DataContext;
using RVTR.Account.DataContext.Repositories;
using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class RepositoryTest
  {
    private static readonly SqliteConnection _connection = new SqliteConnection("Data Source=:memory:");
    private static readonly DbContextOptions<AccountContext> _options = new DbContextOptionsBuilder<AccountContext>().UseSqlite(_connection).Options;
    private static readonly AccountContext _context = new AccountContext(_options);
    private readonly Repository<AccountModel> _repository = new Repository<AccountModel>(_context);

    public static readonly IEnumerable<object[]> _repositoryWithKeys = new List<object[]>
    {
      new object[] { new Repository<AccountModel>(_context), 1 },
      new object[] { new Repository<ProfileModel>(_context), 1 }
    };

    public static readonly IEnumerable<object[]> _repositoryWithEntities = new List<object[]>
    {
      new object[] { new Repository<AccountModel>(_context), new AccountModel() { Id = 1 } },
      new object[] { new Repository<ProfileModel>(_context), new ProfileModel() { Id = 1 } }
    };

    [Theory]
    [MemberData(nameof(_repositoryWithKeys))]
    public async void Test_Repository_Delete<T>(Repository<T> repository, int id) where T : class
    {
      var actual = await _context.Accounts.ToListAsync();

      await repository.DeleteAsync(id);

      Assert.Empty(actual);
    }

    [Theory]
    [MemberData(nameof(_repositoryWithEntities))]
    public async void Test_Repository_Insert<T>(Repository<T> repository, T entity) where T : class
    {
      var actual = await _context.Accounts.ToListAsync();

      await repository.InsertAsync(entity);

      Assert.Empty(actual);
    }

    [Fact]
    public async void Test_Repository_SelectAsync()
    {
      _connection.Open();
      _context.Database.EnsureCreated();

      var actual = await _repository.SelectAsync();

      Assert.Empty(actual);
    }

    [Theory]
    [MemberData(nameof(_repositoryWithKeys))]
    public async void Test_Repository_SelectById<T>(Repository<T> repository, int id) where T : class
    {
      _connection.Open();
      _context.Database.EnsureCreated();

      var actual = await repository.SelectAsync(id);

      Assert.Null(actual);
    }

    [Theory]
    [MemberData(nameof(_repositoryWithEntities))]
    public void Test_Update<T>(Repository<T> repository, T entity) where T : class
    {
      var actual = repository.Update(entity);

      Assert.Equal(actual, entity);
    }
  }
}
