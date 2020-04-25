using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class ProfileModelTest
  {
    private readonly ProfileModel _sut = new ProfileModel();

    public void Test_Create_ProfileModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
