namespace Sales.Domain.Customers
{
    public class Email
    {
        private Email()
        {
        }

        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; }

        public static Email CreateNew(string emailAddress)
        {
            return new Email(emailAddress);
        }
    }
}