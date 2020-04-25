using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.Account.UnitTesting.Tests
{
  public class BankCardModelTest
  {
    public static readonly IEnumerable<Object[]> _bankCards = new List<Object[]>
    {
      new object[]
      {
        new BankCardModel()
        {
          Id = 0,
          Expiry = DateTime.Now,
          Number = "378282246310005"
        }
      },
      new object[]
      {
        new BankCardModel()
        {
          Id = 0,
          Expiry = DateTime.Now,
          Number = "6011111111111117"
        }
      },
      new object[]
      {
        new BankCardModel()
        {
          Id = 0,
          Expiry = DateTime.Now,
          Number = "5555555555554444"
        }
      },
      new object[]
      {
        new BankCardModel()
        {
          Id = 0,
          Expiry = DateTime.Now,
          Number = "4111111111111111"
        }
      }
    };

    [Theory]
    [MemberData(nameof(_bankCards))]
    public void Test_Create_BankCardModel(BankCardModel bankCard)
    {
      var validationContext = new ValidationContext(bankCard);
      var actual = Validator.TryValidateObject(bankCard, validationContext, null, true);

      Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(_bankCards))]
    public void Test_Validate_BankCardModel(BankCardModel bankCard)
    {
      var validationContext = new ValidationContext(bankCard);

      Assert.Empty(bankCard.Validate(validationContext));
    }
  }
}
