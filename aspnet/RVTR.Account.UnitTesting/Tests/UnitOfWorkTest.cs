using System;
using RVTR.Account.DataContext.Repositories;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class UnitOfWork_Test
  {
    [Fact]
    public void Test_CommitMethod()
    {
      var sut = new UnitOfWork();

      Action actual = () => sut.Commit();

      Assert.IsType<Action>(actual);
    }
  }
}
