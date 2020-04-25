using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class AddressModelTest
  {
    private readonly AddressModel _sut = new AddressModel();

    public void Test_Create_AddressModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
