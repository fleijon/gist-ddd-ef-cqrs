using Sales.Domain.Products;
using SharedKernel;

namespace Sales.Domain.Carts
{
    public class CartItem
    {
        private CartItem()
        {
        }

        public CartItem(ProductId productId, uint quantity, Money productPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            ProductPrice = productPrice;
        }

        public void ChangeQuantityTo(uint newQuantity)
        {
            Quantity = newQuantity;
        }

        public ProductId ProductId { get; }
        public uint Quantity { get; private set; }
        public Money ProductPrice { get; }
    }
}