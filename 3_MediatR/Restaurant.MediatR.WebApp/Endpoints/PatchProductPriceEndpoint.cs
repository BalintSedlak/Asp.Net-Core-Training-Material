using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core;
using Restaurant.Infrasturcture.Entities;

namespace Restaurant.WebApp.Endpoints;

public class PatchProductPriceEndpoint : EndpointBaseAsync
    .WithRequest<PatchProductPriceEndpointRequest>
    .WithActionResult<PatchProductPriceEndpointResult>
{
    private readonly ProductService _productService;

    public PatchProductPriceEndpoint(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPatch("/Product/Modify")]
    public override async Task<ActionResult<PatchProductPriceEndpointResult>> HandleAsync([FromForm] PatchProductPriceEndpointRequest request, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _productService.IncreasePriceForProduct(request.Id, request.PriceIncreaseInPercent, cancellationToken);
        PatchProductPriceEndpointResult response = product.Adapt<PatchProductPriceEndpointResult>();
            
        return response;
    }
}