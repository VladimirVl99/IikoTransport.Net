using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Information about a created delivery order with an operation status.
    /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1create/post.
    /// </summary>
    [JsonObject]
    public class OrderWithOperationInfo : OperationInfo
    {
        /// <summary>
        /// Order.
        /// </summary>
        [JsonProperty(PropertyName = "orderInfo", Required = Required.Always)]
        public OrderInfo OrderInfo { get; set; } = default!;
    }
}
