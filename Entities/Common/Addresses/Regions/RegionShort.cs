using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Regions
{
	/// <summary>
	/// Region.
	/// </summary>
	[JsonObject]
	public class RegionShort
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
