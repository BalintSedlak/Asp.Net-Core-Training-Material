namespace Restaurant.WebApp.Endpoints;

public class PatchProductPriceEndpointResult
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}