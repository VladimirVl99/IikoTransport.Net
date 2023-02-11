using Newtonsoft.Json;
using DeliveryOrder = IikoTransport.Net.Entities.Responses.Delivery.DeliveryCreateAndUpdate.OrderInfo;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve
{
	/// <summary>
	/// Orders of an organization.
	/// </summary>
	[JsonObject]
	public class OrdersByOrganization
	{
		/// <summary>
		/// Organization ID.
		/// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
		/// </summary>
		[JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
		public Guid OrganizationId { get; set; }

		/// <summary>
		/// List of orders by organization.
		/// </summary>
		[JsonProperty(PropertyName = "orders", Required = Required.Always)]
		public IEnumerable<DeliveryOrder> Orders { get; set; } = default!;
	}
}
