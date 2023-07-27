using GreenArrow.Engine.Model.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GreenArrow.Engine.EventNotificationSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class GreenArrowEventController : ControllerBase
    {
        private readonly ILogger<GreenArrowEventController> _logger;
        private readonly IEventReceptor _eventReceptor;

        public GreenArrowEventController(
            ILogger<GreenArrowEventController> logger,
            IEventReceptor eventReceptor
            )
        {
            _logger = logger;
            _eventReceptor = eventReceptor;
        }

        [Route(nameof(EventType.BounceAll))]
        [HttpPost()]
        public async Task<IActionResult> PostBounceAll([FromBody] BounceAll bounceAll)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.BounceAll);

            await _eventReceptor.HandleAsync(bounceAll);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.BounceAll);

            return Ok();
        }

        [Route(nameof(EventType.BounceBadAddress))]
        [HttpPost()]
        public async Task<IActionResult> PostBounceBadAddress([FromBody] BounceBadAddress bounceBadAddress)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.BounceBadAddress);

            await _eventReceptor.HandleAsync(bounceBadAddress);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.BounceBadAddress);

            return Ok();
        }

        [Route(nameof(EventType.DeliveryAttempt))]
        [HttpPost()]
        public async Task<IActionResult> PostDeliveryAttempt([FromBody] DeliveryAttempt deliveryAttempt)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.DeliveryAttempt);

            await _eventReceptor.HandleAsync(deliveryAttempt);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.DeliveryAttempt);

            return Ok();
        }

        [Route(nameof(EventType.EngineClick))]
        [HttpPost()]
        public async Task<IActionResult> PostClickTracking([FromBody] ClickTracking clickTracking)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.EngineClick);

            await _eventReceptor.HandleAsync(clickTracking);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.EngineClick);

            return Ok();
        }

        [Route(nameof(EventType.EngineOpen))]
        [HttpPost()]
        public async Task<IActionResult> PostOpenTracking([FromBody] OpenTracking openTracking)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.EngineOpen);

            await _eventReceptor.HandleAsync(openTracking);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.EngineOpen);

            return Ok();
        }

        [Route(nameof(EventType.Scomp))]
        [HttpPost()]
        public async Task<IActionResult> PostSpamComplaint([FromBody] SpamComplaint spamComplaint)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.Scomp);

            await _eventReceptor.HandleAsync(spamComplaint);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.Scomp);

            return Ok();
        }

        [Route(nameof(EventType.EngineUnsub))]
        [HttpPost()]
        public async Task<IActionResult> PostUnsubscribe([FromBody] Unsubscribe unsubscribe)
        {
            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} received", EventType.EngineUnsub);

            await _eventReceptor.HandleAsync(unsubscribe);

            _logger.LogDebug("Green Arrow Event {GreenArrowEventType} handled", EventType.EngineUnsub);

            return Ok();
        }
    }
}
