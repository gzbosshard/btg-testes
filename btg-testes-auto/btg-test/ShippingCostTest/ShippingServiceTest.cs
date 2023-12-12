using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
        private readonly ShippingService _service;

        public ShippingServiceTest()
        {
            _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _service = new(_mockDeliveryCostCalculator);
        }

        [Fact]
        public void CalculateShippingCost_ApplyDiscount_DiscountApplied()
        {
            //Arrange
            double distance = 250;
            DeliveryType deliveryType = DeliveryType.Express;
            var cost = _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType);

            //Act
            double result = _service.CalculateShippingCost(distance, deliveryType);

            //Assert
            result.Should().Be(cost * 0.5);
        }

        [Theory]
        [InlineData(200, DeliveryType.Express)]
        [InlineData(100, DeliveryType.Express)]
        [InlineData(250, DeliveryType.Ordinary)]
        [InlineData(100, DeliveryType.Ordinary)]
        [InlineData(200, DeliveryType.Ordinary)]
        public void CalculateShippingCost_ApplyDiscount_DiscountNotApplied(double distance, DeliveryType deliveryType)
        {
            //Arrange
            var cost = _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType);

            //Act
            double result = _service.CalculateShippingCost(distance, deliveryType);

            //Assert
            result.Should().Be(cost);
        }

    }
}
