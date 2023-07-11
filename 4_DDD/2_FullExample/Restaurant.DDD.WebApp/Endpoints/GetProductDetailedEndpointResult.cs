namespace Restaurant.DDD.WebApp.Endpoints;

public class GetProductDetailedEndpointResult
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public bool Discontinued { get; set; }

    public string Category { get; set; }

    public string Supplier { get; set; }
}