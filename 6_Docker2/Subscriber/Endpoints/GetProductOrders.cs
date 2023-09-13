using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using Subscriber.Messaging;
using Subscriber.Repository;

namespace Subscriber.Endpoints;

public class GetProductOrders : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IReadOnlyCollection<GetProductOrdersResult>>
{
    private readonly IRepository<OrderCreated> _repository;
    private readonly OrderConsumer _orderConsumer;

    public GetProductOrders(IRepository<OrderCreated> repository, OrderConsumer orderConsumer)
    {
        _repository = repository;
        _orderConsumer = orderConsumer;
    }

    [HttpGet("/Items/Orders")]
    public override async Task<IReadOnlyCollection<GetProductOrdersResult>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = new List<GetProductOrdersResult>();

        foreach (OrderCreated item in _repository.GetAll())
        {
            result.Add(item.Adapt<GetProductOrdersResult>());
        }

        return result.AsReadOnly();
    }
}
