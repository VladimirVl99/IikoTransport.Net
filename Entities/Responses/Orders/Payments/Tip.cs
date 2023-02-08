using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Payments
{
    /// <summary>
    /// Information about a tip.
    /// </summary>
    [JsonObject]
    public class Tip : PaymentItem
    {
		/// <summary>
		/// Tips type.
		/// </summary>
		[JsonProperty(PropertyName = "tipsType", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public TipType? TipsType { get; set; }
    }
}
