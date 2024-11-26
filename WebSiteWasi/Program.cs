using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebSiteWasi.Models;
using WebSiteWasi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Agregar servicios de identidad
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;  // Deshabilitar la confirmación de cuenta si no la necesitas
})
    .AddRoles<IdentityRole>()  // Añadir los roles
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Agregar controladores y vistas
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<GeminiRecommendationService>();  // Agregar GeminiRecommendationService al contenedor de DI

// Construcción de la aplicación
var app = builder.Build();

// Configuración del pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Crear los roles y usuarios al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Crear los roles si no existen
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

    // Crear el usuario Admin si no existe
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

        // Crear el usuario con una contraseña
        var userResult = await userManager.CreateAsync(adminUser, "Georg12345+");
        if (userResult.Succeeded)
        {
            // Asignar el rol "ADMIN" al usuario
            await userManager.AddToRoleAsync(adminUser, "ADMIN");
        }
    }

    
    
}

// Configuración de las rutas
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación
app.Run();
