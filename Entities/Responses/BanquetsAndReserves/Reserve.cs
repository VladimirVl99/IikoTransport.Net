using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.Customers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Banquet/reserve.
    /// </summary>
    [JsonObject]
	public class Reserve
	{
        /// <summary>
        /// Client that placed the reserve.
        /// </summary>
        [JsonProperty(PropertyName = "customer", Required = Required.Always)]
        public Customer Customer { get; set; } = default!;

        /// <summary>
        /// Estimated guests count.
        /// </summary>
        [JsonProperty(PropertyName = "guestsCount", Required = Required.Always)]
        public int GuestCount { get; set; }

        /// <summary>
        /// Optional comment for reserve or banquet.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Estimated banquet duration.
        /// </summary>
        [JsonProperty(PropertyName = "durationInMinutes", Required = Required.Always)]
        public long DurationInMinutes { get; set; }

        /// <summary>
        /// Whether to remind staff to prepare table beforehand.
        /// </summary>
        [JsonProperty(PropertyName = "shouldRemind", Required = Required.Always)]
        public bool ShouldRemind { get; set; }

        /// <summary>
        /// Status of the reserve or banquet.
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReserveStatus Status { get; set; }

        /// <summary>
        /// The reserve cancellation reason or null if the reserve hasn't been canceled.
        /// </summary>
        [JsonProperty(PropertyName = "cancelReason", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReserveCancellationReason? CancelReason { get; set; }

        /// <summary>
        /// Reserved table IDs.
        /// </summary>
        [JsonProperty(PropertyName = "tableIds", Required = Required.Always)]
        public IEnumerable<Guid> TableIds { get; set; } = default!;

        /// <summary>
        /// Estimated time when reserve will be closed or banquet will be started.
        /// </summary>
        [JsonProperty(PropertyName = "estimatedStartTime", Required = Required.Always)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime EstimatedStartTime { get; set; }

        /// <summary>
        /// Time when guests came and reserve was closed or banquet was started.
        /// </summary>
        [JsonProperty(PropertyName = "guestsComingTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? GuestsComingTime { get; set; }

        /// <summary>
        /// Order. Used only at a banquet.
        /// </summary>
        [JsonProperty(PropertyName = "order", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Order? Order { get; set; }
    }
}
