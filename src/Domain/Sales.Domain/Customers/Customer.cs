using Sales.Domain.Customers.Orders;
using SharedKernel;
using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Domain.Customers
{
    public class Customer : AggregateRoot<CustomerId>
    {
        private readonly ICustomerData _customerData;
        private readonly ICustomerValidator _validator;

        public Customer(ICustomerData customerData, ICustomerValidator validator)
        {
            _customerData = customerData;
            _validator = validator;
        }

        public new CustomerId Id => new CustomerId(Guid.Parse(_customerData.CustomerId));
        public Name Name => new Name(_customerData.CustomerFirstName, _customerData.CustomerLastName);
        public Email Email => new Email(_customerData.Email);

        private void CreateId()
        {
            _customerData.CustomerId = Guid.NewGuid().ToString();
        }

        public Validation SetName(string firstName, string lastName)
        {
            var nameValidation = _validator.ValidateName(firstName, lastName);
            if (nameValidation.Success)
            {
                _customerData.CustomerFirstName = firstName;
                _customerData.CustomerLastName = lastName;
            }

            return nameValidation;
        }

        public Validation SetEmail(string email)
        {
            var emailValidation = _validator.ValidateEmail(email);
            if (emailValidation.Success)
            {
                _customerData.Email = email;
            }

            return emailValidation;
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _customerData.DomainEvents.Add(domainEvent);
        }

        public static IResult<Customer> Create(string firstName, string lastName, string email, ICustomerData customerData, ICustomerValidator validator)
        {
            var customer = new Customer(customerData, validator);
            customer.CreateId();
            var customerValidation = customer.SetName(firstName, lastName);
            if (!customerValidation.Success) return Result<Customer>.Fail(customerValidation.InvalidReasons.ToList());

            var emailValidation = customer.SetEmail(email);
            if (!emailValidation.Success) return Result<Customer>.Fail(emailValidation.InvalidReasons.ToList());

            customer.AddDomainEvent(new CustomerCreatedEvent(customer.Id.Value));

            return Result<Customer>.Success(customer);
        }

        public IResult<Order> PlaceOrder(IEnumerable<Carts.CartItem> items, Currency currency, ICurrencyConverter currencyConverter)
        {
            if (!items.Any())
            {
                return Result<Order>.Fail("An order must contain at least one item.");
            }
            if (currency == null)
            {
                return Result<Order>.Fail("A currency must be given to place an order.");
            }

            var order = Order.Create(
                Id,
                items,
                currency,
                currencyConverter);

            AddDomainEvent(new OrderPlacedEvent(Id.Value, order.Id.Value));

            return Result<Order>.Success(order);
        }
    }
}