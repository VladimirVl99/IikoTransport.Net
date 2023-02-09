using IikoTransport.Net.Entities.Common.Addresses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals
{
	/// <summary>
	/// Delivery point details.
	/// </summary>
	[JsonObject]
	public class DeliveryPoint
	{
		/// <summary>
		/// Delivery address coordinates.
		/// </summary>
		[JsonProperty(PropertyName = "coordinates", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Coordinate? Coordinates { get; set; }

		/// <summary>
		/// Delivery address details.
		/// </summary>
		[JsonProperty(PropertyName = "address", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public Address? Address { get; set; }

		/// <summary>
		/// Address ID in external mapping system.
		/// </summary>
		[JsonProperty(PropertyName = "externalCartographyId", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? ExternalCartographyId { get; set; }

		/// <summary>
		/// Comment.
		/// </summary>
		[JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Comment { get; set; }
	}
}
