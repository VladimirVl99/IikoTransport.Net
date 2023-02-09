using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryCreateAndUpdate
{
	/// <summary>
	/// ECS info.
	/// </summary>
	[JsonObject]
	public class ExternalCourierService
	{
		/// <summary>
		/// ECS setting record id. Unique through all organizations.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// ECS name.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;
	}
}
