using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Subscriber.Endpoints;

public class GetTest : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    [HttpGet("/Test")]
    public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        return Ok("Test");
    }
}
