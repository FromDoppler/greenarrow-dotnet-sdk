using GreenArrow.Engine.Model;
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

        /// <summary>
        /// Deserialize a JSON string into an specific type of object
        /// </summary>
        /// <typeparam name="T">Type of the expected object</typeparam>
        /// <param name="json">JSON string to deserialize</param>
        /// <returns>A object instance of the especified type </returns>
        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static string ToDkimHeaderValue(this IList<Dkim> dkims)
        {
            var value = JsonConvert.SerializeObject(dkims, settings);
            return value.Replace("\"", "\\\"");
        }
    }
}
