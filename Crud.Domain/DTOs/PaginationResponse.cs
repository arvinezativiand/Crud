namespace Crud.Domain.DTOs;

public class PaginationResponse<T>
{
    public int RecordsTotal { get; set; }
    public int RecordsFiltered { get; set; }
    public T Data { get; set; }
}
