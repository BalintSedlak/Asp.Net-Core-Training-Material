using Microsoft.EntityFrameworkCore;
using RestaurantDemo.DDD.SpecificationPattern.DB;
using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using RestaurantDemo.DDD.SpecificationPattern.DB.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.UseNamespaceRouteToken());

// Add services to the container.
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IAsyncRepository<CategoryEntity>, EfRepository<CategoryEntity>>();
builder.Services.AddScoped<IAsyncRepository<CustomerDemographicEntity>, EfRepository<CustomerDemographicEntity>>();
builder.Services.AddScoped<IAsyncRepository<CustomerEntity>, EfRepository<CustomerEntity>>();
builder.Services.AddScoped<IAsyncRepository<DemographicEntity>, EfRepository<DemographicEntity>>();
builder.Services.AddScoped<IAsyncRepository<EmployeeEntity>, EfRepository<EmployeeEntity>>();
builder.Services.AddScoped<IAsyncRepository<EmployeeTerritoryEntity>, EfRepository<EmployeeTerritoryEntity>>();
builder.Services.AddScoped<IAsyncRepository<OrderDetailEntity>, EfRepository<OrderDetailEntity>>();
builder.Services.AddScoped<IAsyncRepository<OrderEntity>, EfRepository<OrderEntity>>();
builder.Services.AddScoped<IAsyncRepository<ProductEntity>, EfRepository<ProductEntity>>();
builder.Services.AddScoped<IAsyncRepository<RegionEntity>, EfRepository<RegionEntity>>();
builder.Services.AddScoped<IAsyncRepository<ShipperEntity>, EfRepository<ShipperEntity>>();
builder.Services.AddScoped<IAsyncRepository<SupplierEntity>, EfRepository<SupplierEntity>>();
builder.Services.AddScoped<IAsyncRepository<TerritoryEntity>, EfRepository<TerritoryEntity>>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }