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
        .Property(e => e.Id)
        .HasConversion(
            v => (int)v, // تبدیل به int هنگام ذخیره
            v => (ulong)v // تبدیل به ulong هنگام خواندن
        );
        //builder.Entity<RPouyaFile>()
        //    .Property(x => x.Id)
        //    .HasConversion<long>();

        //builder.Entity<RPouyaUser>()
        //    .Property(x => x.Id)
        //    .HasConversion<long>();

        builder.Entity<RPouyaFile>()
            .OwnsOne(f => f.Data, builder => { builder.ToJson(); });

        base.OnModelCreating(builder);
    }
}
