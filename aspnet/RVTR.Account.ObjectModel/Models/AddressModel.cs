using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Account.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Address_ model
  /// </summary>
  public class AddressModel : IValidatableObject
  {
    public int Id { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string StateProvince { get; set; }

    [Required]
    public string Street { get; set; }

    /// <summary>
    /// Represents the _Address_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
  }
}
