using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.DataContext.Repositories
{
  public class AccountRepository : Repository<AccountModel>
  {
    public readonly AccountContext db;
    public AccountRepository(AccountContext context):base(context)
    {
      db = context;
    }

    public async Task<AccountModel[]> getAllAccounts()
    {
      var accounts = await db.Accounts.Include(x => x.Address).Include(x => x.Payments)
        .Include(x => x.Profiles).ThenInclude(x => x.Name).ToArrayAsync();
      return accounts;
    }
    public async Task<AccountModel[]> getAccount(int accountId)
    {
      var accounts = await db.Accounts.Include(x => x.Address).Include(x => x.Payments)
        .Include(x => x.Profiles).ThenInclude(x => x.Name).Where(x => x.Id == accountId).ToArrayAsync();

      return accounts;
    }
  }
}
