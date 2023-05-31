using Bogus;
using Restaurant.DDD.Infrasturcture;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.WebApp.Test.FakeModels;

namespace Restaurant.WebApp.Test.TestInitializers;

internal class DefaultDatabaseSeed : IDatabaseSeed
{
    public void Seed(RestaurantContext restaurantContext)
    {
        for (int i = 1; i <= 10; i++)
        {
            var categoryFaker = new Faker<CategoryEntity>()
            .RuleFor(x => x.Id, f => i)
            .RuleFor(x => x.CategoryName, f => f.Commerce.Categories(1)[0])
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph(1))
            .RuleFor(x => x.Picture, f => f.Random.Bytes(20));
            

            var fakeCategory = categoryFaker.Generate();

            restaurantContext.Categories.Add(fakeCategory);
            restaurantContext.SaveChanges();
        }

        ProductEntityFake productEntityFake = new();

        var products = productEntityFake.Generate(100);
        restaurantContext.Products.AddRange(products);

        restaurantContext.SaveChanges();

    }
}