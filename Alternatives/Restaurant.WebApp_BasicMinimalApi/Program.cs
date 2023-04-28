using Microsoft.EntityFrameworkCore;
using Restaurant.Infrasturcture;
using Restaurant.Infrasturcture.Entities;
using Restaurant.WebApp_BasicMinimalApi;
using Restaurant.WebApp_Controller.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ControllerAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

//Transient - Transient objects are always different; a new instance is provided to every controller and every service.
//Scoped - Scoped objects are the same within a request, but different across different requests.
//Singleton - Singleton objects are the same for every object and every request.
builder.Services.AddTransient<Service_Transient>();
builder.Services.AddScoped<Service_Scoped>();
builder.Services.AddSingleton<Service_Singleton>();

builder.Services.AddTransient<ServiceResolver>(serviceProvider => key =>
{
    switch (key)
    {
        case "Transient":
            return serviceProvider.GetService<Service_Transient>();
        case "Scoped":
            return serviceProvider.GetService<Service_Scoped>();
        case "Singleton":
            return serviceProvider.GetService<Service_Singleton>();
        default:
            throw new KeyNotFoundException(); // or maybe return null, up to you
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/IsItWorking", () =>
{
    return "Working..."; ;
});

app.MapGet("/product", (ControllerAppContext repository) =>
{
    var product = repository.Products.Where(x => x.Id == 1);

    return product;
});

app.MapGet("/IsItDog/Singleton", (ServiceResolver serviceAccessor) =>
{
    IService service = serviceAccessor("Singleton");

    return service.IsItDog();
});

app.MapGet("/IsItDog/Transient", (ServiceResolver serviceAccessor) =>
{
    IService service = serviceAccessor("Transient");

    return service.IsItDog();
});

app.MapGet("/IsItDog/Scoped", (ServiceResolver serviceAccessor) =>
{
    IService service = serviceAccessor("Scoped");

    return service.IsItDog();
});

app.Run();







public delegate IService ServiceResolver(string key);