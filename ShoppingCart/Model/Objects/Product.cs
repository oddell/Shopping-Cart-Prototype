using System;

namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Represents a product in the shopping cart
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The quantity of the product
        /// </summary>
        public int Quantity { get; set; }
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
