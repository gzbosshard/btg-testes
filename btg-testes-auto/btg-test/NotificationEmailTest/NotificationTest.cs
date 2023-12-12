using btg_testes_auto.Notification;
using btg_testes_auto.Order;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.NotificationEmailTest
{
    public class NotificationTest
    {
        private readonly IEmailService _mockEmailService;
        private NotificationService _service; // _sut system under test

        public NotificationTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _service = new(_mockEmailService);
        }

        [Fact]
        public void SendNotification_MessageNull_ReturnFalse()
        {
            //Arrange
            string recipient = "email@email.com";
            string message = null;

            //Act
            bool result = _service.SendNotification(recipient, message);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void SendNotification_MessageEmpty_ReturnFalse()
        {
            //Arrange
            string recipient = "email@email.com";
            string message = " ";

            //Act
            bool result = _service.SendNotification(recipient, message);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void SendNotification_SendEmail_EmailSent()
        {
            //Arrange
            string recipient = "email@email.com";
            string message = "message";

            _mockEmailService.SendEmail(recipient, "Notification", message)
                .Returns(true);

            //Act
            bool result = _service.SendNotification(recipient, message);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void SendNotification_SendEmail_ReturFalse()
        {
            //Arrange
            string recipient = "email@email.com";
            string message = "message";

            _mockEmailService.SendEmail(recipient, "Notification", message)
                .Returns(false);

            //Act
            bool result = _service.SendNotification(recipient, message);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void SendNotification_Esception_ReturnFalse()
        {
            //Arrange
            string recipient = "email@email.com";
            string message = "message";

            _mockEmailService.SendEmail(recipient, "Notification", message)
                .Throws(new Exception());

            //Act
            bool result = _service.SendNotification(recipient, message);

            //Assert
            result.Should().BeFalse();
        }
    }
}
