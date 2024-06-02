using System.Collections.Generic;

namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Represents a shopping basket.
    /// </summary>
    public interface IBasket
    {
        /// <summary>
        /// Adds a product to the basket with the specified quantity.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="quantity">The quantity of the product to add.</param>
        void AddProduct(Product product, int quantity);

        /// <summary>
        /// Applies a discount to the basket using the specified code.
        /// </summary>
        /// <param name="code">The discount code to apply.</param>
        void ApplyDiscount(string code);

        /// <summary>
        /// Gets the list of items in the basket.
        /// </summary>
        /// <returns>The list of basket items.</returns>
        List<BasketItem> GetItems();

        /// <summary>
        /// Gets the total cost of the basket after applying discounts.
        /// </summary>
        /// <returns>The total cost of the basket.</returns>
        decimal GetTotalCost();

        /// <summary>
        /// Gets the total cost of the basket before applying discounts.
        /// </summary>
        /// <returns>The total cost of the basket before discounts.</returns>
        decimal GetTotalCostBeforeDiscount();
    }
}