using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;

namespace Publisher.Endpoints;

public class GetProductBasicEndpoint : EndpointBaseAsync
    .WithRequest<PostProductOrderRequest>
    .WithActionResult<OrderCreated>
{
    private readonly IEventBus _eventBus;

    public GetProductBasicEndpoint(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpPost("/products/order")]
    public override async Task<ActionResult<OrderCreated>> HandleAsync(PostProductOrderRequest request, CancellationToken cancellationToken = default)
    {
        OrderCreated order = request.Adapt<OrderCreated>();

        await _eventBus.PublishAsync(order, nameof(OrderCreated), cancellationToken);

        return Ok(order);
    }
}
