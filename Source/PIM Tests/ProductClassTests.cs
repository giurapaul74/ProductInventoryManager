using System;
using Xunit;
using Product_Inventory_Manager;
using Xunit.Abstractions;

namespace PIM_Tests
{
    public class ProductClassTests
    {
        private readonly ITestOutputHelper _output;

        public ProductClassTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void UpdatePriceMethodCanChangeProductPrice()
        {
            //arrange
            var product = new Product("Item", 15, 1, 2);

            //act
            product.UpdatePrice(20);

            //assert
            Assert.Equal(20, product.Price);
        }

        [Fact]
        public void UpdatePriceDoesNotSetNegativeValuesToProductPrice()
        {
            //arrange
            var product = new Product("Item", 50, 1, 1);
            var expected = product.Price;

            //act
            var exception = Assert.Throws<ArgumentException>(() => product.UpdatePrice(-10));

            //assert
            _output.Equals(exception);
        }
    }
}
