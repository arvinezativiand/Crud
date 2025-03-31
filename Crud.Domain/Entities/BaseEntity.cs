using System.ComponentModel.DataAnnotations;

namespace Crud.Domain.Entities;

public class BaseEntity
{
    [Key]
    public ulong Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
