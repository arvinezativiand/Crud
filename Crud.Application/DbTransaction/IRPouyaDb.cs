namespace Crud.Application.DbTransaction;

public interface IRPouyaDb
{
    Task<TResult> Transaction<TResult>(Func<Task<TResult>> action);
}
