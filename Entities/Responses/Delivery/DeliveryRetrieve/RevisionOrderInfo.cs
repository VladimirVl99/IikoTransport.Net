using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve
{
	/// <summary>
	/// Orders by organizations.
	/// </summary>
	[JsonObject]
	public class RevisionOrderInfo : OperationInfo
	{
		/// <summary>
		/// Maximum revision value per all orders.
		/// </summary>
		[JsonProperty(PropertyName = "maxRevision", Required = Required.Always)]
		public long MaxRevision { get; set; }

		/// <summary>
		/// Orders.
		/// </summary>
		[JsonProperty(PropertyName = "ordersByOrganizations", Required = Required.Always)]
		public IEnumerable<OrdersByOrganization> OrdersByOrganizations { get; set; } = default!;
	}
}
