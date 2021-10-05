using Microsoft.EntityFrameworkCore;
using Sales.Domain.Customers;
using SharedKernel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EFOrm
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ICustomerValidator validator)
        {
            _validator = validator;
        }

        private SalesDbContext _dbContext;
        private readonly ICustomerValidator _validator;

        public async Task<IResult<Customer>> Create(string firstName, string lastName, string email, Func<string, bool> emailValidator, CancellationToken cancellationToken)
        {
            var data = new CustomerData();
            await _dbContext.Customers.AddAsync(data);

            return Customer.Create(firstName, lastName, email, data, _validator);
        }

        public async Task<IResult<Customer>> GetById(CustomerId customerId, CancellationToken cancellationToken)
        {
            var customerData = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId.Value.ToString());
            if (customerData is null)
            {
                return Result<Customer>.Fail($"Customer with id '{customerId.Value.ToString()}' does not exist.");
            }

            return Result<Customer>.Success(new Customer(customerData, _validator));
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}