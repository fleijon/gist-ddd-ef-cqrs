using SharedKernel;

namespace Sales.Domain.Customers
{
    public interface ICurrencyConverter
    {
        public Money Convert(Currency currency, Money price);
    }
}