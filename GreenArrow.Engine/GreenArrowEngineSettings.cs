namespace GreenArrow.Engine
{
    /// <summary>
    /// Green Arrow Engine Settings
    /// </summary>
    public class GreenArrowEngineSettings
    {
        /// <summary>
        /// The base Uri of the server that host the Green Arrow Engine APIs
        /// </summary>
        public string ServerUri { get; set; }

        /// <summary>
        /// The HTTP Submission API Endpoint
        /// </summary>
        public string HTTPSubmissionAPIEndpoint { get; set; } = "/api/v1/send.json";
    }
}
