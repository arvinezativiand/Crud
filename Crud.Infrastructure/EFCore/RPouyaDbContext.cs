using Crud.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.EFCore;

public class RPouyaDbContext : IdentityDbContext<RPouyaAdmin>
{
    public RPouyaDbContext(DbContextOptions<RPouyaDbContext> options) : base(options)
    {
                
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
