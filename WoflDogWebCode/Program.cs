using Microsoft.EntityFrameworkCore;
using WoflDogWebCode.Models;
using WoflDogWebCode.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add SQLite database context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add MenuService
builder.Services.AddScoped<WoflDogWebCode.Services.IMenuService, WoflDogWebCode.Services.MenuService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();

    // Create recommendations.json if it doesn't exist
    var recommendationsJsonPath = Path.Combine(builder.Environment.ContentRootPath, "recommendations.json");
    // Load recommendations from JSON file (if it exists)
    if (File.Exists(recommendationsJsonPath) && !context.Recommendations.Any())
    {
        var recommendationsJsonText = File.ReadAllText(recommendationsJsonPath);
        var recommendations = JsonSerializer.Deserialize<List<Recommendation>>(recommendationsJsonText);

        if (recommendations != null)
        {
            context.Recommendations.AddRange(recommendations);
            context.SaveChanges();
        }
    }

    // Load menu items from JSON file
    var jsonPath = Path.Combine(builder.Environment.ContentRootPath, "menus.json");
    if (File.Exists(jsonPath) && !context.Menus.Any())
    {
        var jsonText = File.ReadAllText(jsonPath);
        var menus = JsonSerializer.Deserialize<List<Menu>>(jsonText);

        if (menus != null)
        {
            context.Menus.AddRange(menus);
            context.SaveChanges();
        }
    }

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error404");
    app.UseStatusCodePagesWithReExecute("/Home/Error404");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Error404",
    pattern: "{*url}",
    defaults: new { controller = "Home", action = "Error404" });

app.UseAuthorization();

app.Run();
