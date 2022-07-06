using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestMediatR;
using TestMediatR.Application;
using TestMediatR.Application.Behaviors;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Infrastructure;
using TestMediatR.Infrastructure.Context;
using TestMediatR.Infrastructure.Entities;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;
var connectionString = configuration.GetConnectionString("WebApiDatabase");
services.AddSingleton<IDbConnection>(db => new SqlConnection(connectionString));
services.AddDbContext<DataStoreContext>(options =>
{
    options.UseSqlServer(connectionString);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IDataStoreRepository, DataStoreRepository>();
services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Product, ProductEntity>();
    cfg.CreateMap<ProductEntity, Product>();
});
services.AddControllers();

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
