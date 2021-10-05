using SharedKernel;
using System.Collections.Generic;

namespace Sales.Domain.Carts
{
    public interface ICartData : IAggregateRootData
    {
        public string CustomerId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}