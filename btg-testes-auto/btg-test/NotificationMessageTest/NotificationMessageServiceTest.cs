using btg_testes_auto.NotificationMessage;
using NSubstitute;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.ExceptionExtensions;

namespace btg_test.NotificationMessageTest
{
    public class NotificationMessageTest
    {
        private readonly IMessageService _mockMessageService;
        private readonly NotificationMessageService _service;

        public NotificationMessageTest()
        {
            _mockMessageService = Substitute.For<IMessageService>();
            _service = new(_mockMessageService);
        }

        [Fact]
        public void NotifyUsers_VerificarMensagensEnviadas_RetornaFalse()
        {

            //Arrange
            List<Notification> notifications = new List<Notification>();

            Notification notification1 = new()
            {
                UserId = "usuario1",
                Message = "mensagem de notificação 1"
            };

            Notification notification2 = new()
            {
                UserId = "usuario2",
                Message = "mensagem de notificação 2"
            };

            notifications.Add(notification1);
            notifications.Add(notification2);


            _mockMessageService.SendMessage(notification1.UserId, notification1.Message).Returns(true);
            _mockMessageService.SendMessage(notification2.UserId, notification2.Message).Returns(false);

            //Act

            bool result = _service.NotifyUsers(notifications);

            //Assert
            result.Should().BeFalse();
            _mockMessageService.Received().SendMessage("usuario1", "mensagem de notificação 1");
            _mockMessageService.Received().SendMessage("usuario2", "mensagem de notificação 2");

        }

        [Fact]
        public void NotifyUsers_VerificarMensagensEnviadas_RetornaTrue()
        {

            //Arrange
            List<Notification> notifications = new List<Notification>();

            Notification notification1 = new()
            {
                UserId = "usuario1",
                Message = "mensagem de notificação 1"
            };

            Notification notification2 = new()
            {
                UserId = "usuario2",
                Message = "mensagem de notificação 2"
            };

            notifications.Add(notification1);
            notifications.Add(notification2);


            _mockMessageService.SendMessage(notification1.UserId, notification1.Message).Returns(true);
            _mockMessageService.SendMessage(notification2.UserId, notification2.Message).Returns(true);

            //Act

            bool result = _service.NotifyUsers(notifications);

            //Assert
            result.Should().BeTrue();
            _mockMessageService.Received().SendMessage("usuario1", "mensagem de notificação 1");
            _mockMessageService.Received().SendMessage("usuario2", "mensagem de notificação 2");

        }

        [Fact]
        public void NotifyUsers_InterrupcaoAposFalha_NenhumaMensagemSubsequenteEnviada()
        {
            // Arrange
            List<Notification> notifications = new List<Notification>();

            Notification notification1 = new()
            {
                UserId = "usuario1",
                Message = "mensagem de notificação 1"
            };

            Notification notification2 = new()
            {
                UserId = "usuario2",
                Message = "mensagem de notificação 2"
            };

            notifications.Add(notification1);
            notifications.Add(notification2);

            _mockMessageService.SendMessage(notification1.UserId, notification1.Message).Returns(false); 
            _mockMessageService.SendMessage(notification2.UserId, notification2.Message).Returns(true); 

            // Act
            bool result = _service.NotifyUsers(notifications);

            // Assert
            result.Should().BeFalse();
            _mockMessageService.Received().SendMessage("usuario1", "mensagem de notificação 1"); 
            _mockMessageService.DidNotReceive().SendMessage("usuario2", "mensagem de notificação 2"); 
        }


    }


}
