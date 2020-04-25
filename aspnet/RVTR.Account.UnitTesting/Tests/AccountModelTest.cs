using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class AccountModelTest
  {
    private readonly AccountModel _sut = new AccountModel();

    public void Test_Create_AccountModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
