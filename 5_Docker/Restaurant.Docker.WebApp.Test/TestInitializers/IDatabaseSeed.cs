using Restaurant.Docker.Infrasturcture;

namespace Restaurant.Docker.WebApp.Test.TestInitializers;

public interface IDatabaseSeed
{
    public void Seed(RestaurantContext restaurantContext);
}
