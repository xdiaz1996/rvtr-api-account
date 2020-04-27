using Microsoft.EntityFrameworkCore;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext
{
  /// <summary>
  /// Represents the _Account_ context
  /// </summary>
  public class AccountContext : DbContext
  {
    public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AccountModel>().HasKey(k => k.Id);
      builder.Entity<AddressModel>().HasKey(k => k.Id);
      builder.Entity<BankCardModel>().HasKey(k => k.Id);
      builder.Entity<NameModel>().HasKey(k => k.Id);
      builder.Entity<PaymentModel>().HasKey(k => k.Id);
      builder.Entity<ProfileModel>().HasKey(k => k.Id);
    }
  }
}
