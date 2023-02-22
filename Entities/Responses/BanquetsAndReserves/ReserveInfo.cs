using IikoTransport.Net.Entities.Responses.Orders;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
	/// <summary>
	/// Banquet/reserve.
	/// </summary>
	[JsonObject]
	public class ReserveInfo : OrderInfoShort
	{
		/// <summary>
		/// Banquet/reserve is deleted.
		/// </summary>
		[JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
		public bool IsDeleted { get; set; }

		/// <summary>
		/// Banquet/reserve.
		/// </summary>
		[JsonProperty(PropertyName = "reserve", Required = Required.Always)]
		public Reserve Reserve { get; set; } = default!;
	}
}
