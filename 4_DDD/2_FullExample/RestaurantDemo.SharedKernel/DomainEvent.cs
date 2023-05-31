using MediatR;

namespace Restaurant.DDD.SharedKernel;

public abstract record DomainEvent : INotification;