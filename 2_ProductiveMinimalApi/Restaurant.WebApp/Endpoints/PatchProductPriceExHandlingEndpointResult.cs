namespace Restaurant.WebApp.Endpoints;

public class PatchProductPriceExHandlingEndpointResult
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}