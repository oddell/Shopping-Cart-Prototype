using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Model.Objects
{
    /// <inheritdoc/>
    public class Basket : IBasket
    {
        private const string DiscountCode = "288";
        private const int Discount = 10;
        private readonly List<BasketItem> _items = new List<BasketItem>();
        private decimal _discountPercentage = 0;

        public Basket()
        {
            // Unity CTOR
        }

        /// <summary>
        /// Adds a product to the basket with the specified quantity.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="quantity">The quantity of the product to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when the product is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the quantity is less than or equal to zero.</exception>
        public void AddProduct(Product product, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new BasketItem(product, quantity));
            }
        }

        /// <inheritdoc/>
        public decimal GetTotalCost()
        {
            return _items.Sum(i => i.Product.Price * i.Quantity) * (1 - _discountPercentage / 100);
        }

        /// <inheritdoc/>
        public void ApplyDiscount(string code)
        {
            if (code == DiscountCode)
            {
                _discountPercentage = Discount;
            }
        }

        /// <inheritdoc/>
        public decimal GetTotalCostBeforeDiscount()
        {
            return _items.Sum(i => i.Product.Price * i.Quantity);
        }

        /// <inheritdoc/>
        public List<BasketItem> GetItems()
        {
            return _items;
        }
    }
}
