using Sales.Domain.Customers;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Domain.Carts
{
    public interface ICartRepository
    {
        Task Add(Cart cart, CancellationToken cancellationToken = default);

        Task<Cart> GetById(CartId cartId, CancellationToken cancellationToken = default);

        Task<Cart> GetByCustomerId(CustomerId customerId, CancellationToken cancellationToken = default);
    }
}