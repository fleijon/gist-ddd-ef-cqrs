using SharedKernel.Events;
using System;

namespace Sales.Domain.Customers
{
    public class CustomerCreatedEvent : DomainEvent
    {
        public CustomerCreatedEvent(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}