using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restaurant.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.WebApp.Test.TestInitializers;
internal class TestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private readonly IDatabaseSeed _databaseSeed;
    private readonly string _databaseName;

    public TestApplicationFactory(string databaseName, IDatabaseSeed databaseSeed)
    {
        _databaseSeed = databaseSeed;
        _databaseName = databaseName;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            RemoveRegisteredDbContext(services);
            RegisterInMemoryDbContext(services, _databaseName);
            SeedDatabase(services);
        });
    }

    private void SeedDatabase(IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();

        using (var scope = sp.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<RestaurantContext>();
            var logger = scopedServices
                    .GetRequiredService<ILogger<TestApplicationFactory<TStartup>>>();

            db.Database.EnsureCreated();

            try
            {
                _databaseSeed.Seed(db);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the " +
                        "database with test messages. Error: {Message}", ex.Message);
            }
        }
    }

    private void RegisterInMemoryDbContext(IServiceCollection services, string databaseName)
    {
        services.AddDbContext<RestaurantContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName);
        });
    }

    private void RemoveRegisteredDbContext(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<RestaurantContext>));

        services.Remove(descriptor);
    }
}