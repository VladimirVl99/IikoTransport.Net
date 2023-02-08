using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Discounts
{
	/// <summary>
	/// Discount type.
	/// </summary>
	[JsonObject]
	public class DiscountType
	{
		/// <summary>
		/// ID.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Name.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;
	}
}
