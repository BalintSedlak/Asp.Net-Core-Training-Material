using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Docker.Core;
using Restaurant.Docker.Core.Exceptions;
using Restaurant.Docker.Infrasturcture.Entities;

namespace Restaurant.Docker.WebApp.Endpoints;

public class PatchProductPriceExHandlingEndpoint : EndpointBaseAsync
    .WithRequest<PatchProductPriceEndpointRequest>
    .WithActionResult<PatchProductPriceEndpointResult>
{
    private readonly ILogger<PatchProductPriceEndpoint> _logger;
    private readonly ProductService _productService;

    public PatchProductPriceExHandlingEndpoint(ILogger<PatchProductPriceEndpoint> logger, ProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPatch("/Product/Modify2")]
    public override async Task<ActionResult<PatchProductPriceEndpointResult>> HandleAsync([FromForm] PatchProductPriceEndpointRequest request, CancellationToken cancellationToken = default)
    {
        ProductEntity product;

        try
        {
            product = await _productService.IncreasePriceForProduct(request.Id, request.PriceIncreaseInPercent, cancellationToken);

        }
        catch (ServiceException ex)
        {
            _logger.LogError(ex.LogMessage, ex);
            return StatusCode(ex.HttpStatusCode.ConvertToInt(), ex.UserFriendlyMessage);
        }

        PatchProductPriceEndpointResult response = product.Adapt<PatchProductPriceEndpointResult>();

        return response;
    }
}