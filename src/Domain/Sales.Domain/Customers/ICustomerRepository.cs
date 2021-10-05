using SharedKernel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<IResult<Customer>> Create(string firstName, string lastName, string email, Func<string, bool> emailValidator, CancellationToken cancellationToken);

        Task<IResult<Customer>> GetById(CustomerId customerId, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}