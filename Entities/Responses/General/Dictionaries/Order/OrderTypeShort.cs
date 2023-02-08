using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Order
{
	/// <summary>
	/// Common information about an order type.
	/// </summary>
	[JsonObject]
	public class OrderTypeShort
	{
		/// <summary>
		/// Order type ID in RMS.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Order type name.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;

		/// <summary>
		/// Enum: "Common" "DeliveryByCourier" "DeliveryPickUp".
		/// Service type.
		/// </summary>
		[JsonProperty(PropertyName = "orderServiceType", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public OrderServiceType OrderServiceType { get; set; }
	}
}
