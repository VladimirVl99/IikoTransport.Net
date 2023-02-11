using IikoTransport.Net.Entities.Common.Addresses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions
{
	/// <summary>
	/// 
	/// </summary>
	[JsonObject]
	public class DeliveryZone
	{
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;

		[JsonProperty(PropertyName = "coordinates", Required = Required.Always)]
		public IEnumerable<Coordinate> Coordinates { get; set; } = default!;

		[JsonProperty(PropertyName = "addresses", Required = Required.Always)]
		public IEnumerable<DeliveryZoneAddressBinding> Addresses { get; set; } = default!;
	}
}
