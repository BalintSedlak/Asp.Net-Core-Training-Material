using Restaurant.Infrasturcture;

namespace Restaurant.WebApp.Test.TestInitializers;

public interface IDatabaseSeed
{
    public void Seed(RestaurantContext restaurantContext);
}
