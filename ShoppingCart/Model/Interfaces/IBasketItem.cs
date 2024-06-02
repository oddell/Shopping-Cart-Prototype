namespace ShoppingCart.Model.Objects
{
    /// <summary>
    /// Represents an item in a shopping basket.
    /// </summary>
    public interface IBasketItem
    {
        /// <summary>
        /// Gets or sets the product associated with the basket item.
        /// </summary>
        Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the basket item.
        /// </summary>
        int Quantity { get; set; }
    }
}