using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalSystem.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


builder.Services.AddDbContext<RentalDbContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:RentalConnection"]);
});

builder.Services.AddScoped<IRentalRepository, EFRentalRepository>();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:IdentityConnection"]));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts => {
    opts.Password.RequiredLength = 8;  
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true; 
    opts.Password.RequireDigit = true;     
    opts.User.RequireUniqueEmail = true;   
})
    .AddEntityFrameworkStores<AppIdentityDbContext>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RentalDbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Помилка при створенні БД.");
    }
}


app.UseStaticFiles();

app.UseSession();

app.UseAuthentication(); 
app.UseAuthorization();  
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();