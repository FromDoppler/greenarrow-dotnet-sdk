using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenArrow.Engine.Extensions
{
    /// <summary>
    /// Extensions methods for JSON serialization and deserialization
    /// </summary>
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings settings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
            NullValueHandling = NullValueHandling.Ignore,
        };

        /// <summary>
        /// Serialize object to a json string in format expected by Green Arrow APIs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented, settings);
        }
    }
}
