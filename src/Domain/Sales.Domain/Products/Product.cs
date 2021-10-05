using SharedKernel;
using System;

namespace Sales.Domain.Products
{
    public class Product : AggregateRoot<ProductId>
    {
        private Product(string name, ProductId id, Money price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public static Product Create(string name, Money price)
        {
            var prodId = new ProductId(Guid.NewGuid());
            return new Product(name, prodId, price);
        }

        public void AddDescription(string description)
        {
            Description = new Description(description);
        }

        public string Name { get; }

        public Description Description { get; private set; }

        public Money Price { get; private set; }
    }
}