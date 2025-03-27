using Crud.Application.DbTransaction;
using Crud.Application.Services.Implimentations;
using Crud.Application.Services.Interfaces;
using Crud.Domain.Entities;
using Crud.Domain.Repository;
using Crud.Infrastructure.EFCore;
using Crud.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RPouyaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<RPouyaAdmin, IdentityRole>()
    .AddEntityFrameworkStores<RPouyaDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<IBaseRepository<RPouyaUser>, BaseRepository<RPouyaUser>>();
builder.Services.AddTransient<IRPouyaUserService, RPouyaUserService>(); 
builder.Services.AddTransient<IRPouyaDb, RPouyaDb>();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Auth/Login";
//    options.AccessDeniedPath = "/Auth/AccessDenied";
//    options.Cookie.Name = "AuthCookie";
//    options.ExpireTimeSpan = TimeSpan.FromDays(7);
//    options.SlidingExpiration = true;
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
    options.Cookie.Name = "AuthCookie";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminBasic", policy =>
    {
        policy.RequireClaim("AccessLevel", "AdminBasic");
    });

    options.AddPolicy("AdminIntermediate", policy =>
    {
        policy.RequireClaim("AccessLevel", "AdminIntermediate", "AdminBasic");
    });

    options.AddPolicy("AdminAdvanced", policy =>
    {
        policy.RequireClaim("AccessLevel", "AdminAdvanced", "AdminIntermediate", "AdminBasic");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
