using Crud.Application.DbTransaction;
using Microsoft.EntityFrameworkCore.Storage;

namespace Crud.Infrastructure.EFCore;

public class RPouyaDb : IRPouyaDb
{
    private readonly RPouyaDbContext _dbContext;

    public RPouyaDb(RPouyaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TResult> Transaction<TResult>(Func<Task<TResult>> action)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            TResult result = await action.Invoke();

            await CommitTransactionAsync(transaction: transaction);
            return result;
        }
        catch
        {
            await RollbackTransactionAsync(transaction: transaction);
            throw;
        }
    }

    protected virtual async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    protected virtual async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }
}
