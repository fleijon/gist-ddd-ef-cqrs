using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> Create(string name, string email, Func<string, bool> emailValidator, CancellationToken cancellationToken);

        Task<Customer> GetById(CustomerId customerId, CancellationToken cancellationToken);
    }
}