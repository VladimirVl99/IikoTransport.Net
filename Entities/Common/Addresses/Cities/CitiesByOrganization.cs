using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Cities
{
	/// <summary>
	/// Cities by organization.
	/// </summary>
	[JsonObject]
	public class CitiesByOrganization
	{
		/// <summary>
		/// Organization ID.
		/// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
		/// </summary>
		[JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
		public Guid OrganizationId { get; set; }

		/// <summary>
		/// Items for organization.
		/// </summary>
		[JsonProperty(PropertyName = "items", Required = Required.Always)]
		public IEnumerable<City> Items { get; set; } = default!;
	}
}
