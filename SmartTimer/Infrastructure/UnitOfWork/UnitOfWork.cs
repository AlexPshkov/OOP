using Domain.UnitOfWork;
using Infrastructure.Context;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _dataBaseContext;

    public UnitOfWork( DataBaseContext dataBaseContext )
    {
        _dataBaseContext = dataBaseContext;
    }

    public void Dispose()
    {
        _dataBaseContext.Dispose();
    }

    public int CommitChanges()
    {
        return _dataBaseContext.CommitChanges();
    }

    public Task<int> CommitChangesAsync()
    {
        return _dataBaseContext.CommitChangesAsync();
    }
}