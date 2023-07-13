using Bogus;
using Restaurant.Docker.Infrasturcture.Entities;

namespace Restaurant.Docker.WebApp.Test.FakeModels;
internal class ProductEntityFake : Faker<ProductEntity>
{
    private static int _idCounter = 1;

    public ProductEntityFake()
    {
        RuleFor(x => x.Id, f => _idCounter++);
        RuleFor(x => x.ProductName, f => f.Commerce.ProductName());
        RuleFor(x => x.SupplierID, f => f.Random.Int(1, 20));
        RuleFor(x => x.CategoryID, f => f.Random.Int(1, 20));
        RuleFor(x => x.QuantityPerUnit, f => f.Random.Int(1, 100) + " " + f.PickRandom("unit", "piece", "box"));
        RuleFor(x => x.UnitPrice, f => f.Random.Decimal(1, 60));
        RuleFor(x => x.UnitsInStock, f => f.Random.Short(1, 100));
        RuleFor(x => x.UnitsOnOrder, f => f.Random.Short(1, 100));
        RuleFor(x => x.ReorderLevel, f => f.Random.Short(1, 100));
        RuleFor(x => x.Discontinued, f => f.Random.Bool());
    }
}
