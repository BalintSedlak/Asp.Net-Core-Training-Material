using Autofac;
using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac.Features.AttributeFilters;

namespace Publisher.Endpoints;

public class GetProductBasicEndpoint : EndpointBaseAsync
    .WithRequest<PostProductOrderRequest>
    .WithActionResult<OrderCreated>
{
    private readonly RabbitMqPublisher _rabbitMqPublisher;

    public GetProductBasicEndpoint([KeyFilter("myQueue")] RabbitMqPublisher rabbitMqPublisher)
    {
        _rabbitMqPublisher = rabbitMqPublisher;
    }

    [HttpPost("/products/order")]
    public override async Task<ActionResult<OrderCreated>> HandleAsync(PostProductOrderRequest request, CancellationToken cancellationToken = default)
    {
        OrderCreated order = request.Adapt<OrderCreated>();

        _rabbitMqPublisher.Publish(JsonSerializer.Serialize(order));

        return Ok(order);
    }
}
