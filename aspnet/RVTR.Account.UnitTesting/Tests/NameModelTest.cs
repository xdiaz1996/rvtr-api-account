using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Account.ObjectModel.Models;
using Xunit;

namespace RVTR.name.UnitTesting.Tests
{
  public class NameModelTest
  {
    public static readonly IEnumerable<Object[]> _names = new List<Object[]>
    {
      new object[]
      {
        new NameModel()
        {
          Id = 0,
          Family = "family",
          Given = "given"
        }
      }
    };

    [Theory]
    [MemberData(nameof(_names))]
    public void Test_Create_NameModel(NameModel name)
    {
      var validationContext = new ValidationContext(name);
      var actual = Validator.TryValidateObject(name, validationContext, null, true);

      Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(_names))]
    public void Test_Validate_NameModel(NameModel name)
    {
      var validationContext = new ValidationContext(name);

      Assert.Empty(name.Validate(validationContext));
    }
  }
}
