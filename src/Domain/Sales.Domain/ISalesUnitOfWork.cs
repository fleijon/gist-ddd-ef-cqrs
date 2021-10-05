using Sales.Domain.Carts;
using Sales.Domain.Customers;
using Sales.Domain.Products;
using System.Threading.Tasks;

namespace Sales.Domain
{
    public interface ISalesUnitOfWork
    {
        ICartRepository Carts { get; }
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }

        Task CommitAsync();
    }
}