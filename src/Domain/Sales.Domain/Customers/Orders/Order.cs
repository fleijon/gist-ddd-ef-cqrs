using Sales.Domain.Carts;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Domain.Customers.Orders
{
    public class Order
    {
        private Order()
        {
        }

        private Order(OrderId id, CustomerId customerId, OrderLine[] orderLines, Currency curreny)
        {
            Id = id;
            CustomerId = customerId;
            Currency = curreny;
            OrderLines = orderLines;
            Placed = DateTime.Now;
            Status = OrderStatus.Placed;
        }

        public OrderId Id { get; }
        public CustomerId CustomerId { get; }
        public OrderLine[] OrderLines { get; }
        public Currency Currency { get; }
        public DateTime Placed { get; }
        public OrderStatus Status { get; private set; }

        public static Order Create(CustomerId customerId, IEnumerable<CartItem> items, Currency currency, ICurrencyConverter currencyConverter)
        {
            var orderLines = items.Select((i) => OrderLine.Create(i.ProductId, i.ProductPrice, i.Quantity, currency, currencyConverter)).ToArray();
            return new Order(new OrderId(Guid.NewGuid()), customerId, orderLines, currency);
        }

        public Money GetTotalPrice()
        {
            var total = OrderLines.Sum(ol => ol.Quantity * ol.ProductPrice.Value);
            return Money.Of(total, Currency.Code);
        }
    }
}