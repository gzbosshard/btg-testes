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
        public void CalculateTotalWithDiscount_NonEmptyItemList_ReturnTotalAmountLessDiscount()
        {
            // Arrange
            var items = new List<CartItem>
                {
                    new CartItem { Price = 10, ProductId = "1" },
                    new CartItem { Price = 20, ProductId = "2" }
                };

            // Act
            double totalAmount = 0;

            foreach(CartItem item in items)
            {
                totalAmount += item.Price;
            }

            var discount = _service.CalculateTotalWithDiscount(items);
            var result = totalAmount - discount;

            // Assert
            result.Should().BeLessThan(totalAmount);
        }

        [Fact]
        public void CalculateTotalWithDiscount_EmptyItemList_ReturnTotalAmountWithoutDiscount()
        {
            // Arrange
            var items = new List<CartItem>();

            // Act
            double totalAmount = 0;

            var discount = _service.CalculateTotalWithDiscount(items);
            var result = totalAmount - discount;

            // Assert
            result.Should().Be(totalAmount);
            discount.Should().Be(0);
        }

        [Fact]
        public void CalculateTotalWithDiscount_NonEmptyItemList_FreeProducts()
        {
            // Arrange
            var items = new List<CartItem>
                {
                    new CartItem { Price = 0, ProductId = "1" },
                    new CartItem { Price = 0, ProductId = "2" }
                };

            // Act
            double totalAmount = 0;

            foreach (CartItem item in items)
            {
                totalAmount += item.Price;
            }

            var discount = _service.CalculateTotalWithDiscount(items);
            var result = totalAmount - discount;

            // Assert
            result.Should().Be(totalAmount);
            discount.Should().Be(0);
        }
    }
}
