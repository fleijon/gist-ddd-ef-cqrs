using SharedKernel;

namespace Sales.Domain.Customers
{
    public class Name
    {
        private Name()
        {
        }

        public string Firstname { get; }
        public string Lastname { get; }

        internal Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        internal static Name Create(string firstname, string lastname)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                throw new BusinessRuleException("Firstname cannot be empty.");
            }
            if (string.IsNullOrEmpty(lastname))
            {
                throw new BusinessRuleException("Lastname cannot be empty.");
            }

            return new Name(firstname, lastname);
        }
    }
}