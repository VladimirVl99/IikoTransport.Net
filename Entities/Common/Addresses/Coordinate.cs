using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses
{
	/// <summary>
	/// Delivery address coordinates.
	/// </summary>
	[JsonObject]
	public class Coordinate
	{
		/// <summary>
		/// Latitude.
		/// </summary>
		[JsonProperty(PropertyName = "latitude", Required = Required.Always)]
		public double Latitude { get; set; }

		/// <summary>
		/// Longitude.
		/// </summary>
		[JsonProperty(PropertyName = "longitude", Required = Required.Always)]
		public double Longitude { get; set; }
	}
}
