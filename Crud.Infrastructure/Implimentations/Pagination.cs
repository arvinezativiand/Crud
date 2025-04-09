using Crud.Domain.DTOs;
using Crud.Domain.Services;

namespace Crud.Infrastructure.Implimentations;

public class Pagination<T> : IPagination<T> where T : class
{
    public Pagination()
    {
    }

    public int GetPageNumber(PaginationRequest request)
    {
        if (request.start <= 0)
            return 1;

        return request.start / request.length + 1;
    }

    public List<T> Paging(IEnumerable<T> values, PaginationRequest request)
    {
        return values.Skip(request.start).Take(request.length).ToList();
    }
}
