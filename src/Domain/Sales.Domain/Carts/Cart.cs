using Sales.Domain.Customers;
using Sales.Domain.Products;
using SharedKernel;
using System;
using System.Collections.Generic;

namespace Sales.Domain.Carts
{
    public class Cart : AggregateRoot<CartId>
    {
        public Cart(ICartData cartData)
        {
            _cartData = cartData;
        }

        public CustomerId CustomerId => new CustomerId(Guid.Parse(_cartData.CustomerId));

        public IReadOnlyCollection<CartItem> CartItems => _cartData.CartItems.AsReadOnly();

        private Cart(CartId id, CustomerId customerId, IEnumerable<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;

            foreach (var item in cartItems)
            {
                _cartItems.Add(item.ProductId, item);
            }
        }

        public static Cart Create(CustomerId customerId)
        {
            if (customerId is null)
            {
                throw new BusinessRuleException("A cart must be assigned a customer.");
            }

            return new Cart(new CartId(Guid.NewGuid()), customerId);
        }

        private Dictionary<ProductId, CartItem> _cartItems = new Dictionary<ProductId, CartItem>();
        private readonly ICartData _cartData;

        public void AddItem(ProductId productId, Money productPrice, uint quantity)
        {
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