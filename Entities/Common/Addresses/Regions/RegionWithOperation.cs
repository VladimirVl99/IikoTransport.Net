using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Regions
{
	/// <summary>
	/// Regions by organizations.
	/// </summary>
	[JsonObject]
	public class RegionWithOperation : OperationInfo
	{
		/// <summary>
		/// List of districts.
		/// </summary>
		[JsonProperty(PropertyName = "regions", Required = Required.Always)]
		public IEnumerable<RegionsByOrganization> Regions { get; set; } = default!;
	}
}
