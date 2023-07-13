using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Docker.Infrasturcture.Entities;
using Restaurant.Docker.Infrasturcture.Repository;

namespace Restaurant.Docker.WebApp.Endpoints;

public class GetProductDetailedEndpoint : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetProductDetailedEndpointResult>
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public GetProductDetailedEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Product/{request}/Detailed")]
    public override async Task<ActionResult<GetProductDetailedEndpointResult>> HandleAsync(int request, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repository.GetByIdAsync(request, cancellationToken);
        GetProductDetailedEndpointResult response = product.Adapt<GetProductDetailedEndpointResult>();

        return response;
    }
}