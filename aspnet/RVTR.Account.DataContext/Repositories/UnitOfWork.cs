using System;

namespace RVTR.Account.DataContext.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    public void Commit() => throw new NotImplementedException();
  }
}
