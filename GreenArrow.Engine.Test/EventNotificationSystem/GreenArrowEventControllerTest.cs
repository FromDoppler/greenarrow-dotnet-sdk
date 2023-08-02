using GreenArrow.Engine.EventNotificationSystem;
using GreenArrow.Engine.Model.Events;
using Microsoft.Extensions.Logging;

namespace GreenArrow.Engine.Test.EventNotificationSystem
{
    public class GreenArrowEventControllerTest
    {
        private readonly Fixture _specimens = new();

        private static GreenArrowEventController CreateSut(
            IEventReceptor eventReceptor
            )
        {
            return new GreenArrowEventController(
                logger: Mock.Of<ILogger<GreenArrowEventController>>(),
                eventReceptor: eventReceptor ?? Mock.Of<IEventReceptor>()
                );
        }

        [Fact]
        public async Task Should_handler_bounce_all_event()
        {
            // Arrange
            var bounceAll = _specimens.Create<BounceAll>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostBounceAll(bounceAll);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(bounceAll), Times.Once());
        }

        [Fact]
        public async Task Should_handler_bounce_bad_address_event()
        {
            // Arrange
            var bounceBadAddress = _specimens.Create<BounceBadAddress>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostBounceBadAddress(bounceBadAddress);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(bounceBadAddress), Times.Once());
        }

        [Fact]
        public async Task Should_handler_click_tracking_event()
        {
            // Arrange
            var clickTracking = _specimens.Create<ClickTracking>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostClickTracking(clickTracking);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(clickTracking), Times.Once());
        }

        [Fact]
        public async Task Should_handler_delivery_attempt_event()
        {
            // Arrange
            var deliveryAttempt = _specimens.Create<DeliveryAttempt>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostDeliveryAttempt(deliveryAttempt);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(deliveryAttempt), Times.Once());
        }

        [Fact]
        public async Task Should_handler_open_tracking_event()
        {
            // Arrange
            var openTracking = _specimens.Create<OpenTracking>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostOpenTracking(openTracking);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(openTracking), Times.Once());
        }

        [Fact]
        public async Task Should_handler_spam_complaint_event()
        {
            // Arrange
            var spamComplaint = _specimens.Create<SpamComplaint>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostSpamComplaint(spamComplaint);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(spamComplaint), Times.Once());
        }

        [Fact]
        public async Task Should_handler_unsubscribe_event()
        {
            // Arrange
            var unsubscribe = _specimens.Create<Unsubscribe>();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostUnsubscribe(unsubscribe);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(unsubscribe), Times.Once());
        }
    }
}
