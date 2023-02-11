using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Cities
{
	/// <summary>
	/// Cities by organizations.
	/// </summary>
	[JsonObject]
	public class CitiesWithOperation : OperationInfo
	{
		/// <summary>
		/// List of cities.
		/// </summary>
		[JsonProperty(PropertyName = "cities", Required = Required.Always)]
		public IEnumerable<CitiesByOrganization> Cities { get; set; } = default!;
	}
}
