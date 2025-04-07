namespace Crud.Domain.DTOs;

public class PaginationRequest
{
    public int start { get; set; }
    public int length { get; set; }
    public int draw { get; set; }
}