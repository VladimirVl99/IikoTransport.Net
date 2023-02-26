using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using DeliveryOrder = IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate.OrderInfo;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve
{
    /// <summary>
    /// Common information about orders.
    /// </summary>
    [JsonObject]
	public class OrderInfoWithOperation : OperationInfo
	{
		/// <summary>
		/// Orders.
		/// </summary>
		[JsonProperty(PropertyName = "orders", Required = Required.Always)]
		public IEnumerable<DeliveryOrder> Orders { get; set; } = default!;
	}
}
