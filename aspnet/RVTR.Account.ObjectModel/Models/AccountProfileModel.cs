namespace RVTR.Account.ObjectModel.Models
{
  public class AccountProfileModel
  {
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ProfileId { get; set; }
    public AccountModel Account { get; set; }
    public ProfileModel Profile { get; set; }
  }
}
