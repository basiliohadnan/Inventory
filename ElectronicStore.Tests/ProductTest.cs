using ElectronicStore.Models;
using Xunit;

namespace ElectronicStore.Tests
{
    public class ProductTest
    {
        [Theory]
        [InlineData("description1", 1.00)]
        public void Product_WhenProductIsCreated_IncrementsIdentifier(
            string description,
            double price)
        {
            //Arrange
            var idBeforeCreate = Product.Id;

            //Act
            var product = new Product(description, price);

            //Assert
            Assert.Equal(idBeforeCreate + 1, Product.Id);
        }

        [Theory]
        [InlineData("description1", 1.00)]
        public void Product_WhenProductIsCreated_ProductIsAddedToProductList(
            string description,
            double price)
        {
            //Arrange
            var productList = Product.GetProducts();

            //Act
            var product = new Product(description, price);

            //Assert
            Assert.Contains(product, productList);
        }

        [Theory]
        [InlineData("description1", 1.00)]
        public void Product_WhenProductIsCreated_InputIsCorrectlyPersisted(
        string description,
        double price)
        {
            //Act
            var product = new Product(description, price);

            //Assert
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
        }


        [Fact]
        public void Product_GetProducts_ReturnsProductList()
        {
            //Act
            var productList = Product.GetProducts();

            //Assert
            Assert.IsType<List<Product>>(productList);
        }

        [Fact]
        public void Product_GetProductsCount_ReturnsProductsQuantity()
        {
            //Act
            var productQty = Product.GetProductsCount();

            //Assert
            Assert.IsType<int>(productQty);
        }

        [Theory]
        [InlineData("description1", 1.00)]
        public void Product_CreateAProductWithValidInput_ProductIsCreated(
            string description,
            double price)
        {
            //Act
            var product = new Product(description, price);

            //Assert
            Assert.NotNull(Product.GetProduct(product.Code));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("", 1)]
        [InlineData("", -1)]
        [InlineData("", null)]
        [InlineData(null, 0)]
        [InlineData(null, 1)]
        [InlineData(null, -1)]
        [InlineData(null, null)]
        [InlineData("string", 0)]
        [InlineData("string", -1)]
        [InlineData("string", null)]
        public void Product_CreateAProductWithInvalidInput_ThrowsInvalidDataException(
            string description,
            double price)
        {
            //Assert
            Assert.Throws<InvalidDataException>(
                //Act
                () => new Product(description, price)
                );
        }

        [Theory]
        [InlineData("description1", 999.99)]
        public void Product_GetProductWithValidCode_ProductIsFound(
            string description,
            double price)
        {
            //Arrange
            var product = new Product(description, price);

            //Act
            var productFound = Product.GetProduct(product.Code);

            //Assert
            Assert.NotNull(productFound);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData('#')]
        public void Product_GetProductWithInvalidCode_ThrowsInvalidOperationException(int code)
        {
            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => Product.GetProduct(code)
                );
        }

        [Theory]
        [InlineData("description1", 100.00)]
        public void Product_DeleteProductWithValidCode_DeletesProductChosen(
            string description,
            double price)
        {
            //Arrange
            var product = new Product(description, price);

            //Act
            var productDeleted = Product.DeleteProduct(product.Code);

            //Assert
            Assert.True(productDeleted);
        }

        [Theory]
        [InlineData(-1, "description1", 100.00)]
        [InlineData(0, "description1", 100.00)]
        [InlineData('#', "description1", 100.00)]
        public void Product_DeleteProductWithInvalidCode_ThrowsInvalidOperationException(
            int code,
            string description,
            double price)
        {
            //Arrange
            var product = new Product(description, price);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => Product.DeleteProduct(code)
                );
        }

        [Theory]
        [InlineData("description1", 100.00, "description2", 200.00)]
        public void Product_UpdateProductWithValidCode_UpdatesProductChosen(
            string description,
            double price,
            string newDescription,
            double newPrice)
        {
            //Arrange
            var product = new Product(description, price);

            //Act
            var productUpdated = Product.UpdateProduct(product.Code, newDescription, newPrice);

            //Assert
            Assert.True(productUpdated);
            Assert.Equal(product.Description, newDescription);
            Assert.Equal(product.Price, newPrice);
        }

        [Theory]
        [InlineData("description1", 100.00, "", 0)]
        [InlineData("description1", 100.00, "", 1)]
        [InlineData("description1", 100.00, "", -1)]
        [InlineData("description1", 100.00, "", null)]
        [InlineData("description1", 100.00, null, 0)]
        [InlineData("description1", 100.00, null, 1)]
        [InlineData("description1", 100.00, null, -1)]
        [InlineData("description1", 100.00, null, null)]
        [InlineData("description1", 100.00, "string", 0)]
        [InlineData("description1", 100.00, "string", -1)]
        [InlineData("description1", 100.00, "string", null)]
        public void Product_UpdateProductWithInvalidInput_ThrowsInvalidDataException(
            string description,
            double price,
            string newDescription,
            double newPrice)
        {
            //Arrange
            var product = new Product(description, price);

            //Assert
            Assert.Throws<InvalidDataException>(
                //Act
                () => Product.UpdateProduct(product.Code, newDescription, newPrice)
                );
        }

        [Theory]
        [InlineData(-1, "description1", 100.00, "newDescription", 300.00)]
        [InlineData(0, "description1", 100.00, "newDescription", 300.00)]
        [InlineData('#', "description1", 100.00, "newDescription", 300.00)]
        public void Product_UpdateProductWithInvalidCode_ThrowsInvalidOperationException(
            int code,
            string description,
            double price,
            string newDescription,
            double newPrice)
        {
            //Arrange
            var product = new Product(description, price);

            //Assert
            Assert.Throws<InvalidOperationException>(
                //Act
                () => Product.UpdateProduct(code, newDescription, newPrice)
                );
        }
    }
}