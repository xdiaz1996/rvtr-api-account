using System.Collections.Generic;

namespace RVTR.Account.DataContext.Repositories
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}
