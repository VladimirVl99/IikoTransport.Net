using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// An active courier location.
    /// </summary>
    [JsonObject]
    public class ActiveCourierLocation
    {
        /// <summary>
        /// Employee ID.
        /// </summary>
        [JsonProperty(PropertyName = "courierId", Required = Required.Always)]
        public Guid CourierId { get; set; }

        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonProperty(PropertyName = "lastActiveLatitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? LastActiveLatitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        [JsonProperty(PropertyName = "lastActiveLongitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? LastActiveLongitude { get; set; }

        /// <summary>
        /// Client date and time.
        /// </summary>
        [JsonProperty(PropertyName = "lastActiveClientDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? LastActiveClientDate { get; set; }
    }
}
