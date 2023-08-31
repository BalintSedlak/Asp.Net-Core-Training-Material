using Ardalis.ApiEndpoints;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Messaging;
using Subscriber.Repository;

namespace Subscriber.Endpoints;

public class GetProductOrders : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IReadOnlyCollection<GetProductOrdersResult>>
{
    private readonly IRepository<OrderCreated> _repository;

    public GetProductOrders(IRepository<OrderCreated> repository)
    {
        _repository = repository;
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
