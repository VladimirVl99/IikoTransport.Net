using IikoTransport.Net.Entities.Common.Orders.CreateOrder;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve
{
    /// <summary>
    /// Information about a reserve order.
    /// </summary>
    [JsonObject]
    public class ReserveOrderShort : GeneralOrderCreation
    {
        /// <summary>
        /// Order type ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/deliveries/order_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "orderTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OrderTypeId { get; set; }
    }
}
