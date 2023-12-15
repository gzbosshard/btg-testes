using btg_testes_auto.Discount;
using btg_testes_auto.PlaylistSongs;
using Castle.Core.Resource;
using FluentAssertions;
using NSubstitute;
using static System.Net.WebRequestMethods;

namespace btg_test.ClientDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private DiscountService _service; // _sut system under test

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _service = new(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_CustomerTypeRegular_ReturnsDiscount5()
        {
            //Arrange
            var customerId = 1;
            var purchaseAmount = 100.0;

            _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Regular);

            //Act
            var discount = _service.GetDiscount(customerId, purchaseAmount);

            //Assert
            discount.Should().Be(5.0);
            _mockCustomerService.Received().GetCustomerType(1);

        }

        [Fact]
        public void GetDiscount_CustomerTypePremium_ReturnsDiscount10()
        {
            //Arrange
            var customerId = 2;
            var purchaseAmount = 100.0;

            _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Premium);


            //Act
            var discount = _service.GetDiscount(customerId, purchaseAmount);

            //Assert
            discount.Should().Be(10.0);
            _mockCustomerService.Received().GetCustomerType(2);
        }

        [Fact]
        public void GetDiscount_CustomerTypeDefault_ReturnsDiscountZero()
        {
            //Arrange
            var customerId = 3;
            var purchaseAmount = 100.0; 

            _mockCustomerService.GetCustomerType(customerId).Returns((CustomerType)3);

            //Act
            var discount = _service.GetDiscount(customerId, purchaseAmount);

            //Assert
            discount.Should().Be(0);
            _mockCustomerService.Received().GetCustomerType(3);
        }
    }
}