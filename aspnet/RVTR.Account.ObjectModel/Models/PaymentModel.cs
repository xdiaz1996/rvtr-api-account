using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Account.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Payment_ model
  /// </summary>
  public class PaymentModel : IValidatableObject
  {
    public int Id { get; set; }

    [Required]
    public BankCardModel BankCard { get; set; }

    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Represents the _Payment_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
  }
}
