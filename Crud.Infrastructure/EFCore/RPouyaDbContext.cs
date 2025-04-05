using Crud.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.EFCore;

public class RPouyaDbContext : IdentityDbContext<RPouyaAdmin>
{
    public RPouyaDbContext(DbContextOptions<RPouyaDbContext> options) : base(options)
    {
        
    }
    public DbSet<RPouyaUser> RPouyaUsers { get; set; }
    public DbSet<RPouyaFile> RPouyaFiles { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RPouyaFile>()
            .OwnsOne(f => f.Data, builder => { builder.ToJson(); });

        base.OnModelCreating(builder);
    }
}
