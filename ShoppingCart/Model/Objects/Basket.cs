using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Basket that contains a list of items.
    /// </summary>
    public class Basket
    {
        private const string DiscountCode = "288";
        private List<BasketItem> _items = new List<BasketItem>();
        private decimal _discountPercentage = 0;

        /// <summary>
        /// Adds a product to the basket with the specified quantity.
        /// If the product already exists in the basket, the quantity will be updated.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="quantity">The quantity of the product to add.</param>
        public void AddProduct(Product product, int quantity)
        {
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

        /// <summary>
        /// Calculates and returns the total cost of all items in the basket after applying the discount.
        /// </summary>
        /// <returns>The total cost of all items in the basket after applying the discount.</returns>
        public decimal GetTotalCost()
        {
            return _items.Sum(i => i.Product.Price * i.Quantity) * (1 - _discountPercentage / 100);
        }

        /// <summary>
        /// Applies a discount to the basket based on the provided code.
        /// For simplicity, let's assume a fixed discount percentage for any valid code.
        /// </summary>
        /// <param name="code">The discount code to apply.</param>
        public void ApplyDiscount(string code)
        {
            if (code == DiscountCode)
            {
                _discountPercentage = 10;
            }
        }

        /// <summary>
        /// Calculates and returns the total cost of all items in the basket before applying the discount.
        /// </summary>
        /// <returns>The total cost of all items in the basket before applying the discount.</returns>
        public decimal GetTotalCostBeforeDiscount()
        {
            return _items.Sum(i => i.Product.Price * i.Quantity);
        }

        /// <summary>
        /// Returns a list of all items in the basket.
        /// </summary>
        /// <returns>A list of all items in the basket.</returns>
        public List<BasketItem> GetItems()
        {
            return _items;
        }
    }
}
