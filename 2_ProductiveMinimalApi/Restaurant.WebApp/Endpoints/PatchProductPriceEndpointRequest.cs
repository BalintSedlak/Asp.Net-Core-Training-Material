namespace Restaurant.WebApp.Endpoints;

public class PatchProductPriceEndpointRequest
{
    public int Id { get; set; }
    public decimal PriceIncreaseInPercent { get; set; }
}