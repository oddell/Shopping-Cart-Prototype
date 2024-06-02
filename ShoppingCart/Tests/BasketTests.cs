using ShoppingCart.Model.Objects;
using System;
using Xunit;

namespace ShoppingCartUnitTests
{
    /// <summary>
    /// Unit tests for the <see cref="Basket"/> class.
    /// </summary>
    public class BasketTests
    {
        private const string TestProductName = "Test Product";
        private const string DiscountCode = "288";
        private const string TestProduct1 = "Product 1";
        private const string TestProduct2 = "Product 2";

        [Fact]
        public void AddProduct_WhenProductIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var basket = new Basket();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => basket.AddProduct(null, 1));
        }

        [Fact]
        public void AddProduct_WhenQuantityIsLessThanOrEqualToZero_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var basket = new Basket();
            var product = new Product(Guid.NewGuid(), TestProductName, 10.0m);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => basket.AddProduct(product, 0));
        }

        [Fact]
        public void AddProduct_WhenProductIsValid_ShouldAddProductToBasket()
        {
            // Arrange
            var basket = new Basket();
            var product = new Product(Guid.NewGuid(), TestProductName, 10.0m);

            // Act
            basket.AddProduct(product, 1);
            var items = basket.GetItems();

            // Assert
            Assert.Single(items);
            Assert.Equal(product, items[0].Product);
            Assert.Equal(1, items[0].Quantity);
        }

        [Fact]
        public void AddProduct_WhenProductAlreadyExists_ShouldUpdateQuantity()
        {
            // Arrange
            var basket = new Basket();
            var product = new Product(Guid.NewGuid(), TestProductName, 10.0m);
            basket.AddProduct(product, 1);

            // Act
            basket.AddProduct(product, 2);
            var items = basket.GetItems();

            // Assert
            Assert.Single(items);
            Assert.Equal(product, items[0].Product);
            Assert.Equal(3, items[0].Quantity);
        }

        [Fact]
        public void GetTotalCost_ShouldReturnCorrectTotalCost()
        {
            // Arrange
            var basket = new Basket();
            var product1 = new Product(Guid.NewGuid(), TestProduct1, 10.0m);
            var product2 = new Product(Guid.NewGuid(), TestProduct2, 20.0m);
            basket.AddProduct(product1, 1);
            basket.AddProduct(product2, 2);

            // Act
            var totalCost = basket.GetTotalCost();

            // Assert
            Assert.Equal(50.0m, totalCost);
        }

        [Fact]
        public void ApplyDiscount_WhenCodeIsValid_ShouldApplyDiscount()
        {
            // Arrange
            var basket = new Basket();
            var product = new Product(Guid.NewGuid(), TestProduct1, 100.0m);
            basket.AddProduct(product, 1);

            // Act
            basket.ApplyDiscount(DiscountCode);
            var totalCost = basket.GetTotalCost();

            // Assert
            Assert.Equal(90.0m, totalCost);
        }

        [Fact]
        public void ApplyDiscount_WhenCodeIsInvalid_ShouldNotApplyDiscount()
        {
            // Arrange
            var basket = new Basket();
            var product = new Product(Guid.NewGuid(), TestProduct1, 100.0m);
            basket.AddProduct(product, 1);

            // Act
            basket.ApplyDiscount("INVALID");
            var totalCost = basket.GetTotalCost();

            // Assert
            Assert.Equal(100.0m, totalCost);
        }

        [Fact]
        public void GetTotalCostBeforeDiscount_ShouldReturnCorrectTotalCostBeforeDiscount()
        {
            // Arrange
            var basket = new Basket();
            var product1 = new Product(Guid.NewGuid(), TestProduct1, 10.0m);
            var product2 = new Product(Guid.NewGuid(), TestProduct2, 20.0m);
            basket.AddProduct(product1, 1);
            basket.AddProduct(product2, 2);

            // Act
            var totalCostBeforeDiscount = basket.GetTotalCostBeforeDiscount();

            // Assert
            Assert.Equal(50.0m, totalCostBeforeDiscount);
        }
    }
}
