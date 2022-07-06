using MediatR;
using Microsoft.EntityFrameworkCore;
using TestMediatR;
using TestMediatR.Application;
using TestMediatR.Application.Behaviors;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Infrastructure;
using TestMediatR.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;
services.AddDbContext<DataStoreContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
services.AddSingleton<IFakeDataStore, FakeDataStore>();
services.AddScoped<IProductService, ProductService>();
services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Product, ProductContract>();
    cfg.CreateMap<ProductContract, Product>();
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
