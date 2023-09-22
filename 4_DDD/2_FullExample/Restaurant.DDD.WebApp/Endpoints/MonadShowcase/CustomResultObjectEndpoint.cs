using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DDD.Core.Customers.Entities;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.WebApp.Endpoints.MonadShowcase;

public class CustomResultObjectEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public CustomResultObjectEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Monad/ResultObject")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await Customer.Create();

        return result.Match<ActionResult>(
            onSuccess => Ok(onSuccess),
            onFailure => StatusCode(onFailure.StatusCode, onFailure.UserFriendlyMessage)
            );

    }
}
