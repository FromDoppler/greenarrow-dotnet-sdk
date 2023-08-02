﻿using GreenArrow.Engine.Model.Events;

namespace GreenArrow.Engine.EventNotificationSystem
{
    /// <summary>
    /// Contract to handle Green Arrow Event Notifications
    /// </summary>
    public interface IEventReceptor
    {
        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(BounceAll bounceAll);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(BounceBadAddress bounceBadAddress);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(DeliveryAttempt deliveryAttempt);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(ClickTracking clickTracking);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(OpenTracking openTracking);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(SpamComplaint spamComplaint);

        /// <summary>
        /// Handle Green Arrow Event Notification
        /// </summary>
        Task HandleAsync(Unsubscribe unsubscribe);
    }
}