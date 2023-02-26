using Newtonsoft.Json;
using SourceIikoCardDiscountItem
    = IikoTransport.Net.Entities.Requests.Orders.Loyalties.IikoCardDiscountItem;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties
{
    /// <summary>
    /// Discount information for order item.
    /// </summary>
    [JsonObject]
    public class IikoCardDiscountItem : SourceIikoCardDiscountItem
    {
        public IikoCardDiscountItem(Guid positionId, double sum, double amount)
        {
            PositionId = positionId;
            Sum = sum;
            Amount = amount;
        }
    }
}
