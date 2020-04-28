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
    private static readonly AccountContext _ctx = new AccountContext(_options);

    public static readonly IEnumerable<object[]> _repositories = new List<object[]>()
    {
      new object[] { new Repository<AccountModel>(_ctx) },
      new object[] { new Repository<ProfileModel>(_ctx) }
    };

    public static readonly IEnumerable<object[]> _repositoriesWithKeys = new List<object[]>()
    {
      new object[] { new Repository<AccountModel>(_ctx), 1 },
      new object[] { new Repository<ProfileModel>(_ctx), 1 }
    };

    public static readonly IEnumerable<object[]> _repositoriesWithValues = new List<object[]>()
    {
      new object[]
      {
        new Repository<AccountModel>(_ctx),
        new AccountModel() { Id = 1 }
      },
      new object[]
      {
        new Repository<ProfileModel>(_ctx),
        new ProfileModel() { Id = 1 }
      }
    };

    [Theory]
    [MemberData(nameof(_repositoriesWithValues))]
    public async void Test_Repository_DeleteAsync<T>(Repository<T> repository, T entry) where T : class
    {
      _connection.Open();
      _ctx.Database.EnsureCreated();

      try
      {
        var actual = _ctx.Set<T>();

        await repository.InsertAsync(entry);
        await _ctx.SaveChangesAsync();

        await repository.DeleteAsync(1);
        await _ctx.SaveChangesAsync();

        Assert.Empty(await actual.ToListAsync());
      }
      finally
      {
        _connection.Close();
      }
    }

    [Theory]
    [MemberData(nameof(_repositoriesWithValues))]
    public async void Test_Repository_InsertAsync<T>(Repository<T> repository, T entry) where T : class
    {
      _connection.Open();
      _ctx.Database.EnsureCreated();

      try
      {
        var actual = _ctx.Set<T>();

        await repository.InsertAsync(entry);
        await _ctx.SaveChangesAsync();

        Assert.NotEmpty(await actual.ToListAsync());
      }
      finally
      {
        _connection.Close();
      }
    }

    [Theory]
    [MemberData(nameof(_repositories))]
    public async void Test_Repository_SelectAsync<T>(Repository<T> repository) where T : class
    {
      _connection.Open();
      _ctx.Database.EnsureCreated();

      try
      {
        var actual = await repository.SelectAsync();

        Assert.Empty(actual);
      }
      finally
      {
        _connection.Close();
      }
    }

    [Theory]
    [MemberData(nameof(_repositories))]
    public async void Test_Repository_SelectAsync_ById<T>(Repository<T> repository) where T : class
    {
      _connection.Open();
      _ctx.Database.EnsureCreated();

      try
      {
        var actual = await repository.SelectAsync(1);

        Assert.Null(actual);
      }
      finally
      {
        _connection.Close();
      }
    }

    [Theory]
    [MemberData(nameof(_repositoriesWithValues))]
    public async void Test_Repository_UpdateAsync<T>(Repository<T> repository, T entry) where T : class
    {
      _connection.Open();
      _ctx.Database.EnsureCreated();

      try
      {
        await repository.InsertAsync(entry);
        await _ctx.SaveChangesAsync();

        var expected = (await _ctx.Set<T>().ToListAsync())[0];

        repository.Update(entry);
        await _ctx.SaveChangesAsync();

        var actual = (await _ctx.Set<T>().ToListAsync())[0];

        Assert.Equal(expected, actual);
      }
      finally
      {
        _connection.Close();
      }
    }
  }
}
