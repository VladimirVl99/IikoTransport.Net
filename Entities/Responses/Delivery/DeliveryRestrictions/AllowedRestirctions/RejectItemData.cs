using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions.AllowedRestirctions
{
    /// <summary>
    /// Reject additional information.
    /// </summary>
    [JsonObject]
    public class RejectItemData
    {
        /// <summary>
        /// Point work time start.
        /// </summary>
        [JsonProperty(PropertyName = "dateFrom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Point work time end.
        /// </summary>
        [JsonProperty(PropertyName = "dateTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Allowed week days.
        /// </summary>
        [JsonProperty(PropertyName = "allowedWeekDays", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<string>? AllowedWeekDays { get; set; }

        /// <summary>
        /// Order min sum.
        /// </summary>
        [JsonProperty(PropertyName = "minSum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? MinSum { get; set; }
    }
}
