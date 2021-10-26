using System;
using Xunit;
using Product_Inventory_Manager;

namespace PIM_Tests
{
    public class ProductClassTests
    {
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

            //act
            product.UpdatePrice(100);

            //assert
            Assert.Equal(100, product.Price);
        }
    }
}
