using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Crud.Domain.Entities;

public class RPouyaAdmin : IdentityUser
{
    [Required, MaxLength(40)]
    public string FullName { get; set; }
}
