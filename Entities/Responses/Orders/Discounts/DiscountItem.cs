using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Discounts
{
	/// <summary>
	/// Discount.
	/// </summary>
	[JsonObject]
    public class DiscountItem
    {
		/// <summary>
		/// Discount type.
		/// Can be obtained by https://api-ru.iiko.services/api/1/discounts operation.
		/// </summary>
		[JsonProperty(PropertyName = "discountType", Required = Required.Always)]
		public DiscountType DiscountType { get; set; } = default!;

		/// <summary>
		/// Total.
		/// </summary>
		[JsonProperty(PropertyName = "sum", Required = Required.Always)]
		public double Sum { get; set; }

		/// <summary>
		/// Order item positions.
		/// </summary>
		[JsonProperty(PropertyName = "selectivePositions", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public IEnumerable<Guid>? SelectivePositions { get; set; }
    }
}
