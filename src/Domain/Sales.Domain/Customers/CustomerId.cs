using SharedKernel;
using System;

namespace Sales.Domain.Customers
{
    public class CustomerId : StronglyTypedId<Guid>
    {
        public CustomerId(Guid value) : base(value)
        {
        }

        public static CustomerId Of(string id)
        {
            return new CustomerId(Guid.Parse(id));
        }

        public static CustomerId Of(Guid id)
        {
            return new CustomerId(id);
        }
    }
}