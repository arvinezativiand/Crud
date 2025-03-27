using System.ComponentModel.DataAnnotations;

namespace Crud.Domain.Entities;

public class RPouyaUser : BaseEntity
{
    [Required]
    public string FullName { get; set; }
    [Required ,Length(10, 10, ErrorMessage = "ID number must be 10 digits")]
    public string IdNumber { get; set; }
    [Required, MinLength(4, ErrorMessage = "Username must be at least 4 digits")]
    public string UserName { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
}
