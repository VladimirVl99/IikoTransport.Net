using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.Loyalties
{
    /// <summary>
    /// Discount information for order item.
    /// </summary>
    [JsonObject]
    public class IikoCardDiscountItem
    {
        /// <summary>
        /// Position ID of order item.
        /// </summary>
        [JsonProperty(PropertyName = "positionId", Required = Required.Always)]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Discount/surcharge sum.
        /// </summary>
        [JsonProperty(PropertyName = "sum", Required = Required.Always)]
        public double Sum { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }
    }
}
