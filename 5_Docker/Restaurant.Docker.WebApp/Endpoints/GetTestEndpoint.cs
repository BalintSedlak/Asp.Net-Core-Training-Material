using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Docker.WebApp.Endpoints;

public class GetTestEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<string>
{
    [HttpGet("/Test")]
    public override async Task<ActionResult<string>> HandleAsync(CancellationToken cancellationToken = default)
    {
        return "Backend is working";
    }
}
