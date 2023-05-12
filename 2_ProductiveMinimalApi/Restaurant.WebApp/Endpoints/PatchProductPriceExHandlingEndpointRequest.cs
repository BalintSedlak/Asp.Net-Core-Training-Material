namespace Restaurant.WebApp.Endpoints;

public class PatchProductPriceExHandlingEndpointRequest
{
    public int Id { get; set; }
    public decimal PriceIncreaseInPercent { get; set; }
}