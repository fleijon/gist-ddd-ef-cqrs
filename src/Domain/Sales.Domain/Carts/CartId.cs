using SharedKernel;
using System;

namespace Sales.Domain.Carts
{
    public class CartId : StronglyTypedId<Guid>
    {
        public CartId(Guid value) : base(value)
        {
        }
    }
}