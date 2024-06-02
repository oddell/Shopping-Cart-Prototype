using System;

namespace ShoppingCart.Model.Objects
{
    /// <inheritdoc/>
    public class BasketItem : IBasketItem
    {
        /// <inheritdoc/>
        public Product Product { get; set; }

        /// <inheritdoc/>
        public int Quantity { get; set; }

        /// <inheritdoc/>
        public BasketItem(Product product, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            Product = product;
            Quantity = quantity;
        }

        /// <inheritdoc/>
        public decimal TotalPrice => Product.Price * Quantity;
    }
}

