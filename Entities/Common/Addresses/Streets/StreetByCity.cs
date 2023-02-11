using IikoTransport.Net.Entities.Common.Addresses.Cities;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Streets
{
	public class StreetByCity : StreetShort
	{
		/// <summary>
		/// City.
		/// </summary>
		[JsonProperty(PropertyName = "city", Required = Required.Always)]
		public CityShort City { get; set; } = default!;
	}
}
