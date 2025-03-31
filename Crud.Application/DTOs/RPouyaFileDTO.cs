using Crud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud.Application.DTOs;

public class RPouyaFileDTO
{
    [Required]
    public JsonFile Data { get; set; }
}
