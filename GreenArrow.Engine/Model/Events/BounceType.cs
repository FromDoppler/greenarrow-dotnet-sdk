namespace GreenArrow.Engine.Model.Events
{
    /// <summary>
    /// The type of bounce. h for hard, s for soft, and o for other.
    /// </summary>
    public enum BounceType
    {
        /// <summary>
        /// Bounce for message that not be retried
        /// </summary>
        Hard = 'h',
        /// <summary>
        /// Bounce for message that can be retried
        /// </summary>
        Soft = 's',
        /// <summary>
        /// Other type of bounce
        /// </summary>
        Other = 'o',
    }
}
