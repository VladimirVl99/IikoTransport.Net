using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.DiscountsAndPromotions
{
    /// <summary>
    /// Applicable manual discount.
    /// </summary>
    [JsonObject]
    public class DynamicDiscount : CommonDynamicDiscount
    {
        public DynamicDiscount(Guid manualConditionId, double sum)
        {
            ManualConditionId = manualConditionId;
            Sum = sum;
        }
    }
}
