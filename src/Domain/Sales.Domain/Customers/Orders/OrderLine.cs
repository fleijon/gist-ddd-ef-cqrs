using Sales.Domain.Products;
using SharedKernel;

namespace Sales.Domain.Customers.Orders
{
    public class OrderLine
    {
        private OrderLine()
        {
        }

        private OrderLine(
            ProductId productId,
            uint quantity,
            Money productPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            ProductPrice = productPrice;
        }

        public ProductId ProductId { get; }
        public uint Quantity { get; }
        public Money ProductPrice { get; }

        internal static OrderLine Create(
            ProductId productId,
            Money productBasePrice,
            uint quantity,
            Currency currency,
            ICurrencyConverter currencyConverter)
        {
            var productPrice = currencyConverter.Convert(currency, productBasePrice);
            return new OrderLine(productId, quantity, productPrice);
        }
    }
}