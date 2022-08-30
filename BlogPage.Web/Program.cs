using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogPage.Core.Repositories;
using BlogPage.Core.Services;
using BlogPage.Core.UnitofWorks;
using BlogPage.Repository;
using BlogPage.Repository.Repositories;
using BlogPage.Repository.UnitofWork;
using BlogPage.Service.Mapping;
using BlogPage.Service.Services;
using BlogPage.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NLayer.Web.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseSqlCon"), option => {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


builder.Services.AddHttpClient<BlogAPIService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<CategoryAPIService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<CommentAPIService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<TagAPIService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Directory.GetCurrentDirectory()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
