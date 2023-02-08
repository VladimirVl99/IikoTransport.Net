using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders
{
	/// <summary>
	/// Order type.
	/// </summary>
	[JsonObject]
    public class OrderType
    {

		public Guid Id { get; set; }

		public string Name { get; set; } = default!;

		public 
    }
}
