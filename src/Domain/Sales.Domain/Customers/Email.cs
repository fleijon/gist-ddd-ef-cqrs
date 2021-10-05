namespace Sales.Domain.Customers
{
    public class Email
    {
        internal Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; }
    }
}