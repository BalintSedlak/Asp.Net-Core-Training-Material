using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using System.Text.Json;

namespace Publisher.Endpoints;

public class GetProductBasicEndpoint : EndpointBaseAsync
    .WithRequest<PostProductOrderRequest>
    .WithActionResult<OrderCreated>
{
    private readonly RabbitMqPublisher _rabbitMqPublisher;

    public GetProductBasicEndpoint(RabbitMqServiceFactory rabbitMqServiceFactory)
    {
        _rabbitMqPublisher = rabbitMqServiceFactory.GetPublisher("myQueue");
    }

    [HttpPost("/products/order")]
    public override async Task<ActionResult<OrderCreated>> HandleAsync(PostProductOrderRequest request, CancellationToken cancellationToken = default)
    {
        OrderCreated order = request.Adapt<OrderCreated>();

        _rabbitMqPublisher.Publish(JsonSerializer.Serialize(order));

        return Ok(order);
    }
}
