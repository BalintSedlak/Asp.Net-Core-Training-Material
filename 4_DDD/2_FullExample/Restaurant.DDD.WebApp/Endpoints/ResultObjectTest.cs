using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DDD.Core.Customers.Entities;
using Restaurant.DDD.Infrasturcture.Entities;
using Restaurant.DDD.SharedKernel;
using Restaurant.WebApp.Endpoints;

namespace Restaurant.DDD.WebApp.Endpoints;

public class ResultObjectTest : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IAsyncRepository<ProductEntity> _repository;

    public ResultObjectTest(IAsyncRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet("/Test/ResultObject")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await Customer.Create();

        return result.Match<ActionResult>(
            onSuccess => Ok(onSuccess),
            onFailure => StatusCode(onFailure.StatusCode, onFailure.UserFriendlyMessage)
            );

    }
}
