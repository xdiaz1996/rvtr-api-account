using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class BankCardModelTest
  {
    private readonly BankCardModel _sut = new BankCardModel();

    public void Test_Create_BankCardModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
