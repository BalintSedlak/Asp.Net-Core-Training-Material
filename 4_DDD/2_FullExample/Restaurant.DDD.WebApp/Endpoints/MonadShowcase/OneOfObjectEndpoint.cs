using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DDD.Core.Orders.Entities;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.WebApp.Endpoints.MonadShowcase;

public class OneOfObjectEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public OneOfObjectEndpoint(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Monad/OneOfObject")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await Order.Create();

        return result.Match<ActionResult>(
            onSuccess => Ok(onSuccess),
            onFailure => StatusCode(onFailure.StatusCode, onFailure.UserFriendlyMessage)
            );

    }
}
