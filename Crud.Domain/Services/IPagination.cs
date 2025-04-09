using Crud.Domain.DTOs;

namespace Crud.Domain.Services;

public interface IPagination<T> where T : class
{
    List<T> Paging(IEnumerable<T> values, PaginationRequest request);
    int GetPageNumber(PaginationRequest request);
}
