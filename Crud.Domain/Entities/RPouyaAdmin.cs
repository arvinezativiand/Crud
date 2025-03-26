using Microsoft.AspNetCore.Identity;

namespace Crud.Domain.Entities;

public class RPouyaAdmin : IdentityUser
{
    public string FullName { get; set; }
}
