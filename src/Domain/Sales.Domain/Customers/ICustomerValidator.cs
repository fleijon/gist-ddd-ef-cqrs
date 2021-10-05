using SharedKernel;

namespace Sales.Domain.Customers
{
    public interface ICustomerValidator
    {
        Validation ValidateEmail(string emailAddress);

        Validation ValidateName(string firstName, string lastName);
    }
}