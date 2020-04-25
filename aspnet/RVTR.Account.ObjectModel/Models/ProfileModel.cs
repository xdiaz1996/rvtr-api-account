using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Account.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Profile_ model
  /// </summary>
  public class ProfileModel : IValidatableObject
  {
    public int Id { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }

    [Required]
    public NameModel Name { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Required]
    public string Phone { get; set; }

    /// <summary>
    /// Represents the _Profile_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
  }
}
