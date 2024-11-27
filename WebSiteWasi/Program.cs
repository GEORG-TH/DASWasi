using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;
using WebSiteWasi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
})
    .AddRoles<IdentityRole>()  
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<GeminiRecommendationService>();  

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var context = services.GetRequiredService<ApplicationDbContext>();

    string[] roleNames = { "ADMIN", "CLIENT" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            var role = new IdentityRole(roleName);
            await roleManager.CreateAsync(role);
        }
    }

    var adminUser = await userManager.FindByEmailAsync("georg.delacruzacho@gmail.com");
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = "georg.delacruzacho@gmail.com",
            Email = "georg.delacruzacho@gmail.com",
            Nombre = "Georg Thierry",
            Apellido = "De La Cruz Acho",
            Direccion = "Av. Peru",
            FechaCreacion = DateTime.Now
        };

        var userResult = await userManager.CreateAsync(adminUser, "Georg12345+");
        if (userResult.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "ADMIN");
        }
    }

    
    
}

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
