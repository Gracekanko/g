using GogoDriverWeb.Data;
using GogoDriverWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
string role = "Passager";
    if (!(await roleManager.RoleExistsAsync(role)))
    {
        await roleManager.CreateAsync(new IdentityRole(role));
    }
    string role1 = "Chauffeur";
    if (!(await roleManager.RoleExistsAsync(role1)))
    {
        await roleManager.CreateAsync(new IdentityRole(role1));
    }
    string role2 = "Admin";
    if (!(await roleManager.RoleExistsAsync(role2)))
    {
        await roleManager.CreateAsync(new IdentityRole(role2));
    }

    //var user = activator.createinstance<personne>();
    //user.nom = "adminnom";
    //user.prenom = "adminprenom";

    //await _userstore.setusernameasync(user, "admin@yahoo.com", cancellationtoken.none);
    //await _emailstore.setemailasync(user, "admin@yahoo.com", cancellationtoken.none);
    //var result = await _usermanager.createasync(user, "password123*");

    //var defaultrole = _rolemanager.findbynameasync("admin").result;

    //if (defaultrole != null)
    //{
    //    identityresult roleresult = await _usermanager.addtoroleasync(user, defaultrole.name);
    //}
}

app.Run();
