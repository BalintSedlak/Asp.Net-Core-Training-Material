using Restaurant.Infrasturcture;

namespace Restaurant.WebApp.Test.TestInitializers;

internal class DefaultDatabaseSeed : IDatabaseSeed
{
    public void Seed(RestaurantContext restaurantContext)
    {
        string script = File.ReadAllText(@"../");
    }
}