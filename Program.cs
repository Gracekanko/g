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

    //var user = Activator.CreateInstance<Personne>();
    //user.Nom = "adminNom";
    //user.Prenom = "adminPrenom";

    //await _userStore.SetUserNameAsync(user, "admin@yahoo.com", CancellationToken.None);
    //await _emailStore.SetEmailAsync(user, "admin@yahoo.com", CancellationToken.None);
    //var result = await _userManager.CreateAsync(user, "Password123*");

    //var defaultrole = _roleManager.FindByNameAsync("Chauffeur").Result;

    //if (defaultrole != null)
    //{
    //    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
    //}
}

app.Run();
