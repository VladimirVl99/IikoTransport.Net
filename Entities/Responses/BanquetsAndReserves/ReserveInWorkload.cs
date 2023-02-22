using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
	/// <summary>
	/// Information about banquet/reserve.
	/// </summary>
	[JsonObject]
	public class ReserveInWorkload
	{
		/// <summary>
		/// Banquet/reserve ID.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Reserved tables.
		/// </summary>
		[JsonProperty(PropertyName = "tableIds", Required = Required.Always)]
		public IEnumerable<Guid> TableIds { get; set; } = default!;

		/// <summary>
		/// Estimated time when reserve will be closed or banquet will be started (Local for the terminal).
		/// </summary>
		[JsonProperty(PropertyName = "estimatedStartTime", Required = Required.Always)]
		[JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
		public DateTime EstimatedStartedTime { get; set; }

		/// <summary>
		/// Estimated banquet duration.
		/// </summary>
		[JsonProperty(PropertyName = "durationInMinutes", Required = Required.Always)]
		public long DurationInMinutes { get; set; }

		/// <summary>
		/// Number of guests.
		/// </summary>
		[JsonProperty(PropertyName = "guestsCount", Required = Required.Always)]
		public int GuestCount { get; set; }
	}
}
