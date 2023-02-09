using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryCreateAndUpdate
{
	/// <summary>
	/// Delivery cancellation reason.
	/// </summary>
	[JsonObject]
	public class CancellationReason
	{
		/// <summary>
		/// ID.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Description.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Description { get; set; } = default!;
	}
}
