using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.MarketingSources
{
    /// <summary>
    /// Marketing sources.
    /// Source: https://api-ru.iiko.services/#tag/Marketing-sources/paths/~1api~11~1marketing_sources/post.
    /// Allowed from version 7.2.5.
    /// </summary>
    [JsonObject]
    public class MarketingSourceWithOperation : OperationInfo
    {
        /// <summary>
        /// List of marketing sources.
        /// </summary>
        [JsonProperty(PropertyName = "marketingSources", Required = Required.Always)]
        public IEnumerable<MarketingSource> MarketingSources { get; set; } = default!;
    }
}
