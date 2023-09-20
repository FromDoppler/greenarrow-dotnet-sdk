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
        public async Task Should_handler_bounce_all_events()
        {
            // Arrange
            var events = _specimens.CreateMany<BounceAll>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostBounceAll(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<BounceAll>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_bounce_bad_address_events()
        {
            // Arrange
            var events = _specimens.CreateMany<BounceBadAddress>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostBounceBadAddress(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<BounceBadAddress>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_click_tracking_events()
        {
            // Arrange
            var events = _specimens.CreateMany<ClickTracking>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostClickTracking(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<ClickTracking>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_delivery_attempt_events()
        {
            // Arrange
            var events = _specimens.CreateMany<DeliveryAttempt>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostDeliveryAttempt(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<DeliveryAttempt>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_open_tracking_events()
        {
            // Arrange
            var events = _specimens.CreateMany<OpenTracking>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostOpenTracking(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<OpenTracking>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_spam_complaint_events()
        {
            // Arrange
            var events = _specimens.CreateMany<SpamComplaint>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostSpamComplaint(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<SpamComplaint>()), Times.Exactly(events.Count));
        }

        [Fact]
        public async Task Should_handler_unsubscribe_events()
        {
            // Arrange
            var events = _specimens.CreateMany<Unsubscribe>().ToList();
            var eventReceptoMock = new Mock<IEventReceptor>();
            var sut = CreateSut(eventReceptoMock.Object);

            // Act
            await sut.PostUnsubscribe(events);

            // Assert
            eventReceptoMock.Verify(x => x.HandleAsync(It.IsAny<Unsubscribe>()), Times.Exactly(events.Count));
        }
    }
}
