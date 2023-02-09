using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
	/// <summary>
	/// Common information about a employee.
	/// </summary>
	[JsonObject]
	public class SimpleEmployeeShort
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

		/// <summary>
		/// Phone.
		/// </summary>
		[JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Phone { get; set; }
	}
}
