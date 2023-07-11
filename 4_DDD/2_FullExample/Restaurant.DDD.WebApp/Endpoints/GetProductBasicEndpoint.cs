using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.WebApp.Endpoints;

public class GetProductBasicEndpoint : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<GetProductBasicEndpointResult>
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public GetProductBasicEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Product/{request}/Basic")]
    public override async Task<ActionResult<GetProductBasicEndpointResult>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repository.GetByIdAsync(request, cancellationToken);
        GetProductBasicEndpointResult response = product.Adapt<GetProductBasicEndpointResult>();

        return response;
    }
}
