using SharedKernel;

namespace Sales.Domain.Customers
{
    public interface ICustomerData : IAggregateRootData
    {
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Email { get; set; }
    }
}