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

    public static readonly IEnumerable<object[]> _repositories = new List<object[]>
    {
      new object[] { new Repository<AccountModel>(_context) },
      new object[] { new Repository<ProfileModel>(_context) }
    };

    public static readonly IEnumerable<object[]> _repositoriesWithKey = new List<object[]>
    {
      new object[] { new Repository<AccountModel>(_context), 1 },
      new object[] { new Repository<ProfileModel>(_context), 1 }
    };

    public static readonly IEnumerable<object[]> _repositoriesWithValue = new List<object[]>
    {
      new object[] { new Repository<AccountModel>(_context), new AccountModel() { Id = 1 } },
      new object[] { new Repository<ProfileModel>(_context), new ProfileModel() { Id = 1 } }
    };

    public RepositoryTest()
    {
      _connection.Open();
      _context.Database.EnsureCreated();
    }

    ~RepositoryTest()
    {
      _connection.Close();
    }

    [Theory]
    [MemberData(nameof(_repositoriesWithKey))]
    public async void Test_Repository_Delete<T>(Repository<T> repository, int id) where T : class
    {
      var actual = await _context.Set<T>().ToListAsync();

      await repository.DeleteAsync(id);

      Assert.Empty(actual);

    }

    [Theory]
    [MemberData(nameof(_repositoriesWithValue))]
    public async void Test_Repository_InsertAsync_Valid<T>(Repository<T> repository, T entity) where T : class
    {
      var actual = await _context.Set<T>().ToListAsync();

      await repository.InsertAsync(entity);

      Assert.Empty(actual);
    }

    [Theory]
    [MemberData(nameof(_repositories))]
    public async void Test_Repository_InsertAsync_Invalid<T>(Repository<T> repository) where T : class
    {
      var actual = await _context.Set<T>().ToListAsync();

      await repository.InsertAsync(null);

      Assert.Empty(actual);
    }

    [Theory]
    [MemberData(nameof(_repositories))]
    public async void Test_Repository_SelectAsync<T>(Repository<T> repository) where T : class
    {
      var actual = await repository.SelectAsync();

      Assert.Empty(actual);
    }

    [Theory]
    [MemberData(nameof(_repositoriesWithKey))]
    public async void Test_Repository_SelectAsync_Id_Valid<T>(Repository<T> repository, int id) where T : class
    {
      var actual = await repository.SelectAsync(id);

      Assert.Null(actual);
    }

    [Theory]
    [MemberData(nameof(_repositories))]
    public async void Test_Repository_SelectAsync_Id_Invalid<T>(Repository<T> repository) where T : class
    {
      var actual = await repository.SelectAsync(0);

      Assert.Null(actual);
    }

    [Theory]
    [MemberData(nameof(_repositoriesWithValue))]
    public void Test_Update<T>(Repository<T> repository, T entity) where T : class
    {
      var actual = repository.Update(entity);

      Assert.Equal(actual, entity);
    }
  }
}
