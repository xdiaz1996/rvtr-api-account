using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class PaymentModelTest
  {
    private readonly PaymentModel _sut = new PaymentModel();

    public void Test_Create_PaymentModel()
    {
      Assert.NotNull(_sut);
    }
  }
}
