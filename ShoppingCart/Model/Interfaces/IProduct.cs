using System;

namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Represents a product in the shopping cart.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        int Quantity { get; set; }
    }
}