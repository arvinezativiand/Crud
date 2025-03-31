using System.ComponentModel.DataAnnotations;

namespace Crud.Domain.Entities;

public class RPouyaFile : BaseEntity
{
    [Required]
    public JsonFile Data { get; set; }
}

public class JsonFile
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}
