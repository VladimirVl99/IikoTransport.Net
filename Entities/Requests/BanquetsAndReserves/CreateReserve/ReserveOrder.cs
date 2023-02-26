using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using DiscountsInfo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties.DiscountsInfo;
using Newtonsoft.Json;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;

namespace IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve
{
    /// <summary>
    /// Information about a reserve order.
    /// </summary>
    [JsonObject]
    public class ReserveOrder : ReserveOrderShort
    {
        public ReserveOrder(IEnumerable<OrderItem> items, IEnumerable<Combo>? combos = null,
            IEnumerable<Payment>? payments = null, IEnumerable<Tips>? tips = null,
            string? sourceKey = null, DiscountsInfo? discountsInfo = null,
            IikoCard5Info? iikoCard5Info = null, Guid? orderTypeId = null)
        {
            Items = items;
            Combos = combos;
            Payments = payments;
            Tips = tips;
            SourceKey = sourceKey;
            DiscountsInfo = discountsInfo;
            IikoCard5Info = iikoCard5Info;
            OrderTypeId = orderTypeId;
        }
    }
}
