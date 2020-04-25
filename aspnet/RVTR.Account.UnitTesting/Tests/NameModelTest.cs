using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class NameModelTest
  {
    private readonly NameModel _sut = new NameModel();

    public void Test_Create_NameModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
