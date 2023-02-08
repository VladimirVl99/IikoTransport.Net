using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    /// <summary>
    /// Information about order guests.
    /// </summary>
    [JsonObject]
    public class GuestInfo
    {
        /// <summary>
        /// Number of persons.
        /// </summary>
        [JsonProperty(PropertyName = "count", Required = Required.Always)]
        public int Count { get; set; }

        /// <summary>
        /// Attribute that shows whether order must be split among guests.
        /// </summary>
        [JsonProperty(PropertyName = "splitBetweenPersons", Required = Required.Always)]
        public bool SplitBetweenPersons { get; set; }
    }
}
