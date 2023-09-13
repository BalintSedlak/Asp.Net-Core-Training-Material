using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using System.Text.Json;

namespace Publisher.Endpoints;

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
