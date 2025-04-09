namespace Crud.Application.DTOs.ExternalDataDTOs;

public class ExternalUserDTO
{
    public int? Id { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public object? City { get; set; }
    public string? Status { get; set; }
}
