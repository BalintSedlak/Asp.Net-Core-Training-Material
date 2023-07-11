using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.WebApp.Endpoints;

namespace Restaurant.WebApp.Endpoints;

public class GetProductDetailedEndpoint : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<GetProductDetailedEndpointResult>
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public GetProductDetailedEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Product/{request}/Detailed")]
    public override async Task<ActionResult<GetProductDetailedEndpointResult>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repository.GetByIdAsync(request, cancellationToken);
        GetProductDetailedEndpointResult response = product.Adapt<GetProductDetailedEndpointResult>();
            
        return response;
    }
}