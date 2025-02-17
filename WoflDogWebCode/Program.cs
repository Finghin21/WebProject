using Microsoft.EntityFrameworkCore;
using WoflDogWebCode.Models;
using WoflDogWebCode.Services;

var builder = WebApplication.CreateBuilder(args);

// 添加 MVC 服务
builder.Services.AddControllersWithViews();

// 注册服务
builder.Services.AddScoped<IResourceNetworkInfoService, ResourceNetworkInfoService>();
builder.Services.AddScoped<IResourceClassService, ResourceClassService>();
builder.Services.AddScoped<IMenuService, MenuService>();

// 配置 SQLite 数据库
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 配置中间件
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error404");
    app.UseStatusCodePagesWithReExecute("/Home/Error404");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 配置默认路由
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 404 处理
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Error404";
        await next();
    }
});

app.Run();
