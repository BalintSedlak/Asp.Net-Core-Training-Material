using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Docker.Infrasturcture.Entities;
using Restaurant.Docker.Infrasturcture.Repository;

namespace Restaurant.Docker.WebApp.Endpoints;

public class GetProductBasicEndpoint : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetProductBasicEndpointResult>
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public GetProductBasicEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Product/{request}/Basic")]
    public override async Task<ActionResult<GetProductBasicEndpointResult>> HandleAsync(int request, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repository.GetByIdAsync(request, cancellationToken);
        GetProductBasicEndpointResult response = product.Adapt<GetProductBasicEndpointResult>();

        return response;
    }
}
