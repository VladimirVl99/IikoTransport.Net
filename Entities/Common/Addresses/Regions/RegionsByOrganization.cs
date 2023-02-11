using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Common.Addresses.Regions
{
	/// <summary>
	/// Regions by organizations.
	/// </summary>
	[JsonObject]
	public class RegionsByOrganization
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
		public IEnumerable<Region> Items { get; set; } = default!;
	}
}
