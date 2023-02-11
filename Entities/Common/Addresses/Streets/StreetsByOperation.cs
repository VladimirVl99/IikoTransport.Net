using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Streets
{
	/// <summary>
	/// Streets by city.
	/// </summary>
	[JsonObject]
	public class StreetsByOperation : OperationInfo
	{
		/// <summary>
		/// List of streets.
		/// </summary>
		[JsonProperty(PropertyName = "streets", Required = Required.Always)]
		public IEnumerable<Street> Streets { get; set; } = default!;
	}
}
