using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.MarketingSources
{
    /// <summary>
    /// Information about a marketing source.
    /// </summary>
    [JsonObject]
    public class MarketingSource
    {
        /// <summary>
        /// Marketing source ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
        /// </summary>
        [JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Marketing source name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// External system revision number.
        /// </summary>
        [JsonProperty(PropertyName = "externalRevision", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? ExternalRevision { get; set; }

        /// <summary>
        /// IsDeleted attribute of marketing source.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Attached marketing sources.
        /// </summary>
        [JsonProperty(PropertyName = "attachedSources", Required = Required.Always)]
        public IEnumerable<string> AttachedSources { get; set; } = default!;
    }
}
