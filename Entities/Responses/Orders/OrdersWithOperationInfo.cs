using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Information about table orders.
    /// </summary>
    [JsonObject]
    public class OrdersWithOperationInfo : OperationInfo
    {
        /// <summary>
        /// Orders.
        /// </summary>
        [JsonProperty(PropertyName = "orderInfo", Required = Required.Always)]
        public IEnumerable<OrderInfo> Orders { get; set; } = default!;
    }
}
