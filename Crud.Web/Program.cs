using Crud.Application.DbTransaction;
using Crud.Application.Services.Implimentation;
using Crud.Application.Services.Implimentations;
using Crud.Application.Services.Interfaces;
using Crud.Domain.Entities;
using Crud.Domain.Services;
using Crud.Infrastructure.EFCore;
using Crud.Infrastructure.Services;
using Ganss.Xss;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RPouyaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<RPouyaAdmin, IdentityRole>()
    .AddEntityFrameworkStores<RPouyaDbContext>().AddDefaultTokenProviders();

//Services & Repositories
builder.Services.AddTransient<IRPouyaUserService, RPouyaUserService>();
builder.Services.AddTransient<IRPouyaFileService, RPouyaFileService>();
builder.Services.AddTransient<IGetExternalData, GetExternalData>();
builder.Services.AddScoped<IHtmlSanitizer, HtmlSanitizer>();
builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    //client.BaseAddress = new Uri("https://pm2.rahkarpouya.ir/api/1.0/users?order_by=Id&order_direction=asc&per_page=10");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
})
.SetHandlerLifetime(TimeSpan.FromMinutes(5));
builder.Services.AddTransient<IApiService, ApiService>();
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
