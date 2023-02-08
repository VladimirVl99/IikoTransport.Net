using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Payments
{
	/// <summary>
	/// Information about tip type.
	/// </summary>
	[JsonObject]
	public class TipType
	{
		/// <summary>
		/// Tips type ID.
		/// Can be obtained by https://api-ru.iiko.services/api/1/tips_types operation.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Tips type name.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;
	}
}
