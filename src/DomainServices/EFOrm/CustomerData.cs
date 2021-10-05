using Sales.Domain.Customers;
using SharedKernel.Events;
using System.Collections.Generic;

namespace EFOrm
{
    public class CustomerData : ICustomerData
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Email { get; set; }
        public List<IDomainEvent> DomainEvents { get; }
    }
}