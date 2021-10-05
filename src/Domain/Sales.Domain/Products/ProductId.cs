using SharedKernel;
using System;

namespace Sales.Domain.Products
{
    public class ProductId : StronglyTypedId<Guid>
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}