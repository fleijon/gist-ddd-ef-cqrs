using SharedKernel.Events;
using System;

namespace Sales.Domain.Customers
{
    public class OrderPlacedEvent : DomainEvent
    {
        public OrderPlacedEvent(Guid customerId, Guid orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }

        public Guid CustomerId { get; }
        public Guid OrderId { get; }
    }
}