namespace Crud.Domain.DTOs;

public class GeneralResponse<TData>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public TData? Data { get; set; }
}
