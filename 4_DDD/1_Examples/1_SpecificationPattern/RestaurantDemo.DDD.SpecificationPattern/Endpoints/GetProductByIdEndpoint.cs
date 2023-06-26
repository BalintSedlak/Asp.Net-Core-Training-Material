using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using RestaurantDemo.DDD.SpecificationPattern.DB.Repository;
using RestaurantDemo.DDD.SpecificationPattern.Specifications;

namespace RestaurantDemo.DDD.SpecificationPattern.Endpoints;

public class GetProductByIdEndpoint : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<ProductEntity>
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public GetProductByIdEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Product/{request}")]
    public override async Task<ActionResult<ProductEntity>> HandleAsync(int request, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetBySpecificationAsync(new ProductByIdSpecification(request), cancellationToken);
        return result.FirstOrDefault();
    }
}
