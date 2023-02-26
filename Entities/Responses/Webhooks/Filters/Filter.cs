using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Webhooks.Filters
{
    /// <summary>
    /// Webhooks filter.
    /// </summary>
    [JsonObject]
    public class Filter
    {
        /// <summary>
        /// Filter for delivery orders.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryOrderFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DeliveryOrderFilter? DeliveryOrderFilter { get; set; }

        /// <summary>
        /// Filter for table orders.
        /// </summary>
        [JsonProperty(PropertyName = "tableOrderFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public TableOrderFilter? TableOrderFilter { get; set; }

        /// <summary>
        /// Filter for banquets/reserves.
        /// </summary>
        [JsonProperty(PropertyName = "reserveFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ReserveFilter? ReserveFilter { get; set; }

        /// <summary>
        /// Filter for stop-lists changes.
        /// </summary>
        [JsonProperty(PropertyName = "stopListUpdateFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public StopListUpdateFilter? StopListUpdateFilter { get; set; }

        /// <summary>
        /// Filter for personal shift.
        /// </summary>
        [JsonProperty(PropertyName = "personalShiftFilter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public PersonalShiftFilter? PersonalShiftFilter { get; set; }
    }
}
