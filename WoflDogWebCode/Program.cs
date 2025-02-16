using Microsoft.EntityFrameworkCore; 
using WoflDogWebCode.Models; 
using System.Text.Json;
using WoflDogWebCode.Services;

var builder = WebApplication.CreateBuilder(args); // 创建 WebApplicationBuilder 实例，用于配置应用程序

// Add services to the container.
builder.Services.AddControllersWithViews(); // 添加 Controllers 和 Views 的支持，用于构建 MVC 应用程序

builder.Services.AddScoped<IResourceNetworkInfoService, ResourceNetworkInfoService>(); // 注册 IResourceNetworkInfoService 服务，使用 scoped 生命周期
builder.Services.AddScoped<IResourceClassService, ResourceClassService>(); // 注册 IResourceClassService 服务，使用 scoped 生命周期
builder.Services.AddScoped<IMenuService, MenuService>(); // 注册 IMenuService 服务，使用 scoped 生命周期

// Add SQLite database context
builder.Services.AddDbContext<WoflDogWebCode.Models.ApplicationDbContext>(options => // 添加 DbContext，用于与 SQLite 数据库交互
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // 配置 DbContext 使用 SQLite 数据库，连接字符串从配置中获取


var app = builder.Build(); // 构建 WebApplication 实例

using (var scope = app.Services.CreateScope()) // 创建一个 scope，用于解析服务
{
var services = scope.ServiceProvider; // 获取 IServiceProvider 实例
    var context = services.GetRequiredService<WoflDogWebCode.Models.ApplicationDbContext>(); // 获取 AppContext 实例
    context.Database.EnsureCreated(); // 确保数据库已创建

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // 如果不是开发环境
{
    app.UseExceptionHandler("/Home/Error404"); // 使用异常处理中间件，将异常重定向到 /Home/Error404 页面
    app.UseStatusCodePagesWithReExecute("/Home/Error404"); // 使用状态码处理中间件，将状态码重定向到 /Home/Error404 页面
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // 使用 HSTS 中间件，强制使用 HTTPS
}

app.UseHttpsRedirection(); // 使用 HTTPS 重定向中间件，将 HTTP 请求重定向到 HTTPS
app.UseStaticFiles(); // 使用静态文件中间件，用于提供静态文件

app.UseRouting(); // 使用路由中间件，用于匹配请求到控制器和 action

app.MapControllerRoute( // 映射控制器路由
    name: "default", // 路由名称
    pattern: "{controller=Home}/{action=Index}/{id?}"); // 路由模式，默认控制器为 Home，action 为 Index，id 为可选参数

app.MapControllerRoute( // 映射控制器路由
    name: "Error404", // 路由名称
    pattern: "{*url}", // 路由模式，匹配所有 URL
    defaults: new { controller = "Home", action = "Error404" }); // 默认控制器为 Home，action 为 Error404

app.UseAuthorization(); // 使用授权中间件，用于验证用户权限

app.Run(); // 运行应用程序
