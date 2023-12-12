using btg_testes_auto.CartDiscount;
using btg_testes_auto.Order;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.CartDiscountTest
{
    public class CartServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private readonly CartService _service;

        public CartServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _service = new(_mockDiscountService);
        }

        [Fact]
        public void CalculateTotalWithDiscount_EmptyItemList_ReturnsZero()
        {
            //Arrange
            var items = new List<CartItem>();
            

            //Act
            var result = _service.CalculateTotalWithDiscount(items);

            //Assert
            result.Should().Be(0);

        }

        [Fact]
        public void CalculateTotalWithDiscount_NonEmptyItemList_ReturnsBiggerThanZero()
        {
            // Arrange
            var items = new List<CartItem>
                {
                    new CartItem { Price = 10, ProductId = "1" },
                    new CartItem { Price = 20, ProductId = "2" }
                };

            // Act
            var result = _service.CalculateTotalWithDiscount(items);

            // Assert
            result.Should().BeGreaterThan(0);
        }

    }
}
