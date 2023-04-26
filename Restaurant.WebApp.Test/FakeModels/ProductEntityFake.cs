using Bogus;
using Restaurant.Infrasturcture.Entities;

namespace Restaurant.WebApp.Test.FakeModels;
internal class ProductEntityFake : Faker<ProductEntity>
{
    public ProductEntityFake()
    {
        //RuleFor(product => product.ProductName, value => value.Commerce.ProductName());
        //RuleFor(product => product.Category, value => value.Commerce.Categories(1).First());
        //RuleFor(product => product.Date, value => value.Date.Between(new DateTime(2022, 1, 1), new DateTime(2022, 10, 30)));
        //RuleFor(product => product.Name, value => value.Commerce.Product());
        //RuleFor(product => product.Description, value => value.Commerce.ProductDescription());
    }
}
