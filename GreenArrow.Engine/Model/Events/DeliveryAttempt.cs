using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// Event generate after a delivery attempt
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DeliveryAttempt : Event
    {
        /// <summary>
        /// Channel that generate the event
        /// </summary>
        public enum ChannelEnum
        {
            /// <summary>
            /// A remote channel
            /// </summary>
            Remote,
            /// <summary>
            /// A local channel
            /// </summary>
            Local,
        }

        /// <summary>
        /// Delivery status type
        /// </summary>
        public enum StatusEnum
        {
            /// <summary>
            /// Delivery Success
            /// </summary>
            Success,
            /// <summary>
            /// Delivery Failure
            /// </summary>
            Failure,
            /// <summary>
            /// Delivery permanent failure
            /// </summary>
            FailureToolong,
            /// <summary>
            /// Delivery deffered
            /// </summary>
            Deferral,
            /// <summary>
            /// Connection max out
            /// </summary>
            Connmaxout,
        }

        // TODO: verify type
        /// <summary>
        /// The time that the bounce happened, in seconds past the Unix epoch.
        /// </summary>
        public long Timestamp { get; init; }

        /// <summary>
        /// local if the delivery attempt is to a local mailbox or remote if the delivery attempt is to a remote mail server.
        /// </summary>
        public ChannelEnum Channel { get; init; }

        /// <summary>
        /// Result of this delivery attempt.
        /// </summary>
        public StatusEnum Status { get; init; }

        /// <summary>
        /// 0 if this is the first delivery attempt and 1 otherwise.
        /// </summary>
        public bool IsRetry { get; init; }

        // TODO: verify type
        /// <summary>
        /// Internal unique ID of the message. IDs are not repeated unless the system clock goes backward. This is not the same as the Message-ID.
        /// </summary>
        public string Msguid { get; init; }

        /// <summary>
        /// The Return-Path of the message. This is also called the envelope sender, MFROM address or bounce address.
        /// </summary>
        public string Sender { get; init; }

        /// <summary>
        /// Primary key of the VirtualMTA that the message is assigned to.
        /// </summary>
        public int Mtaid { get; init; }

        /// <summary>
        /// The time that the message was injected into GreenArrow’s queue, in seconds past the Unix epoch.
        /// </summary>
        public string InjectedTime { get; init; }

        /// <summary>
        /// The success, failure, or deferral message for this delivery attempt.	
        /// </summary>
        public string Message { get; init; }

        /// <summary>
        /// Primary key of the VirtualMTA that the delivery attempt took place with.
        /// This can be, but isn’t always the same as the mtaid.
        /// For example, if mtaid is a Routing Rule, then outmtaid will be the VirtualMTA within that Routing Rule that was actually used for the delivery attempt.	
        /// </summary>
        public int Outmtaid { get; init; }

        /// <summary>
        /// The outgoing IP address used for this delivery attempt (see note below).
        /// </summary>
        public string OutmtaidIp { get; init; }

        /// <summary>
        /// The hostname used for this delivery attempt’s SMTP conversation (see note below).
        /// </summary>
        public string OutmtaidHostname { get; init; }

        /// <summary>
        /// Internal use Studio feature that’s not yet documented.
        /// </summary>
        public int Sendsliceid { get; init; }

        /// <summary>
        /// Blank if the delivery attempt took place using an SMTP Relay Server or the default Throttling Rule.
        /// Otherwise, it contains the ID of the Throttling Rule that was used when making the delivery attempt.
        /// </summary>
        public int Throttleid { get; init; }

        /// <summary>
        /// The hostname to which this delivery attempt occurred (whether or not it came from an actual MX record).
        /// </summary>
        public string MxHostname { get; init; }

        /// <summary>
        /// The IP address to which this delivery attempt occurred (whether or not it came from an actual MX record).
        /// </summary>
        public string MxIp { get; init; }

        /// <summary>
        /// The first email address in the From header as it was originally injected into GreenArrow.
        /// </summary>
        public string FromAddress { get; init; }

        // TODO: Verify type
        /// <summary>
        /// A JSON object containing the values of the headers as configured in the log_header configuration directive.
        /// Folded headers will simply contain the folding newlines/whitespace.
        /// As a header may be included in an email multiple times, the value of the JSON object is an array of strings.
        /// </summary>
        public ICollection<string> Headers { get; init; }

        /// <summary>
        /// The size of the message (in bytes), if loaded from storage.
        /// </summary>
        public int MessageSize { get; init; }

        /// <summary>
        /// CSV list of SMTP timings of the delivery attempt. See the log_smtp_timings configuration directive for more information.
        /// </summary>
        public string SmtpTiming { get; init; }
    }
}
