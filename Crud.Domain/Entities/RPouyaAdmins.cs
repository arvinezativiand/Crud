using Microsoft.AspNetCore.Identity;

namespace Crud.Domain.Entities;

public class RPouyaAdmins : IdentityUser
{
    public string FullName { get; set; }
    public string AccessLevel { get; set; }
}
