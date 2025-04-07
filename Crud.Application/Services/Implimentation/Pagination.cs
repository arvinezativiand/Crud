using Crud.Domain.DTOs;
using Crud.Domain.Services;

namespace Crud.Infrastructure.Implimentations;

public class Pagination<T> : IPagination<T> where T : class
{
    public Pagination()
    {
    }

    public List<T> Paging(IEnumerable<T> values, PaginationRequest request)
    {
        return values.Skip(request.start).Take(request.length).ToList();
    }
}
