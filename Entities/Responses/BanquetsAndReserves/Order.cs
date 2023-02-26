using IikoTransport.Net.Entities.Common.Loyalties;
using IikoTransport.Net.Entities.Responses.Orders;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Reserve's order.
    /// </summary>
    [JsonObject]
    public class Order : OrderShort
    {
        /// <summary>
        /// Information about Loyalty app. null - only for unsupported POS versions.
        /// </summary>
        [JsonProperty(PropertyName = "loyaltyInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LoyaltyInfo? LoyaltyInfo { get; set; }
    }
}
