using BlogPage.Core.Repositories;
using BlogPage.Core.UnitofWorks;
using BlogPage.Core.Services;
using BlogPage.Repository;
using BlogPage.Repository.Repositories;
using BlogPage.Repository.UnitofWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BlogPage.Service.Services;
using BlogPage.Service.Validations;
using BlogPage.Service.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.FileProviders;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using NLayer.Web.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<BlogDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
