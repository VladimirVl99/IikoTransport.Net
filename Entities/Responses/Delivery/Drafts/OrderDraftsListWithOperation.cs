using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Order drafts list by parameters.
    /// Source: https://api-ru.iiko.services/#tag/Drafts/paths/~1api~11~1deliveries~1drafts~1by_filter/post.
    /// </summary>
    [JsonObject]
    public class OrderDraftsListWithOperation : OperationInfo
    {
        /// <summary>
        /// Order drafts list.
        /// </summary>
        [JsonProperty(PropertyName = "drafts", Required = Required.Always)]
        public IEnumerable<OrderDraft> Drafts { get; set; } = default!;
    }
}
