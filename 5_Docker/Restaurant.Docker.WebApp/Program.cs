using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Docker.Core;
using Restaurant.Docker.Infrasturcture;
using Restaurant.Docker.Infrasturcture.Entities;
using Restaurant.Docker.Infrasturcture.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.UseNamespaceRouteToken());
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestaurantApp", Version = "v1" });
    c.EnableAnnotations();
    c.UseApiEndpoints();
});

string connectionString = CreateConnectionString(builder);

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("ConnectionString");
}

// Add services to the container.
builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(connectionString));

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

builder.Services.AddScoped<ProductService>();

//Scoped-
//Transient-
//Singleton-

var app = builder.Build();

MigrationInitialisation(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantApp V1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();




static string CreateConnectionString(WebApplicationBuilder builder)
{
    var server = builder.Configuration["DatabaseServer"];
    var port = builder.Configuration["DatabasePort"];
    var user = builder.Configuration["DatabaseUser"];
    var password = builder.Configuration["DatabasePassword"];
    var databaseName = builder.Configuration["DatabaseName"];

    var connectionString = $"Server={server},{port};Initial Catalog={databaseName};User ID={user};Password={password};TrustServerCertificate=true";
    
    return connectionString;
}

static void MigrationInitialisation(IApplicationBuilder application)
{
    using (var serviceScope = application.ApplicationServices.CreateScope())
    {
        serviceScope.ServiceProvider.GetService<RestaurantContext>().Database.Migrate();
    }
}

// Make the implicit Program class public so test projects can access it
public partial class Program { }