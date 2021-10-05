using Ardalis.GuardClauses;
using Sales.Domain.Customers;
using Sales.Domain.Products;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Domain.Carts
{
    public class Cart : AggregateRoot<CartId>
    {
        private Cart()
        {
        }

        public CustomerId CustomerId { get; private set; }

        public IReadOnlyCollection<CartItem> CartItems => _cartItems.Select((kv) => kv.Value).ToList().AsReadOnly();

        private Cart(CartId id, CustomerId customerId, IEnumerable<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;

            foreach (var item in cartItems)
            {
                _cartItems.Add(item.ProductId, item);
            }
        }

        public static Cart Of(
            CartId cartId,
            CustomerId customerId,
            IEnumerable<CartItem> cartItems)
        {
            return new Cart(cartId, customerId, cartItems);
        }

        public static Cart CreateNew(CustomerId customerId)
        {
            if (customerId is null)
            {
                throw new BusinessRuleException("A cart must be assigned a customer.");
            }

            return new Cart(new CartId(Guid.NewGuid()), customerId, new CartItem[] { });
        }

        private Dictionary<ProductId, CartItem> _cartItems = new Dictionary<ProductId, CartItem>();

        public void AddItem(ProductId productId, Money productPrice, uint quantity)
        {
            Guard.Against.Null(productId, nameof(productId));
            Guard.Against.Null(productPrice, nameof(productPrice));

            if (_cartItems.ContainsKey(productId))
            {
                var item = _cartItems[productId];
                item.ChangeQuantityTo(item.Quantity + quantity);
            }
            else
            {
                _cartItems.Add(productId, new CartItem(productId, quantity, productPrice));
            }
        }

        public void RemoveItem(ProductId productId, uint quantity)
        {
            Guard.Against.Null(productId, nameof(productId));

            if (!_cartItems.ContainsKey(productId)) return;

            var cartItem = _cartItems[productId];

            if (cartItem.Quantity <= quantity)
            {
                _cartItems.Remove(productId);
            }
            else
            {
                var newQuantity = cartItem.Quantity - quantity;
                cartItem.ChangeQuantityTo(newQuantity);
            }
        }

        public void ClearAllCartItems()
        {
            _cartItems.Clear();
        }
    }
}