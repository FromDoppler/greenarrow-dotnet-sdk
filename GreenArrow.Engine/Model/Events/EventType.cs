namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// Types of event generate by Green Arrow event processor
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// This event is triggered for every bounce message processed by the bounce processor.
        /// This includes bounces where the address has not yet met the qualifying criteria for deactivation.
        /// bounce_all events do not require any action and should not be a reason to remove addresses from your database or stop sending to addresses.
        /// Use the bounce_bad_address event for subscriber deactivation instead.
        /// </summary>
        BounceAll,
        /// <summary>
        /// This event is triggered when the bounce processing system detects that an email address has met the configured removal threshold for either hard or soft bounces. 
        /// (This often requires more than one soft bounce, as we don’t want to remove addresses after a single soft bounce.)
        /// </summary>
        BounceBadAddress,
        /// <summary>
        /// When someone clicks on a “this is spam” link at an ISP that supports feedback loops, and a feedback loop notification is sent to GreenArrow, a spam complaint event is created.
        /// </summary>
        Scomp,
        /// <summary>
        /// Click Tracking event generate in Greeen Arrow Engine
        /// </summary>
        EngineClick,
        /// <summary>
        /// Open Tracking event generate in Greeen Arrow Engine
        /// </summary>
        EngineOpen,
        /// <summary>
        /// Unsubscription event generate in Greeen Arrow Engine
        /// </summary>
        EngineUnsub,
        /// <summary>
        /// Event generate after a delivery attempt
        /// </summary>
        DeliveryAttempt,
    }
}
