using Microsoft.AspNetCore.Identity;

namespace Crud.Web.Models.Login;

public class RPouyaAdmins : IdentityUser
{
    public string FullName { get; set; }
    public string AccessLevel { get; set; }
}
