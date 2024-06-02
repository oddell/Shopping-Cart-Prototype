namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Represents an item in the shopping basket.
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// Gets or sets the product associated with the basket item.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the basket item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItem"/> class.
        /// </summary>
        /// <param name="product">The product associated with the basket item.</param>
        /// <param name="quantity">The quantity of the product in the basket item.</param>
        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}

