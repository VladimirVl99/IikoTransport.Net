using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Discount operation applied to order items.
    /// </summary>
    [JsonObject]
    public class Discount
    {
        /// <summary>
        /// Operation Type Code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public OperationTypeCode Code { get; set; }

        /// <summary>
        /// Deprecated, use positionId.
        /// </summary>
        [JsonProperty(PropertyName = "orderItemId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? OrderItemId { get; set; }

        /// <summary>
        /// Id of item the discount is applied to. If null - discount applied to whole orders.
        /// </summary>
        [JsonProperty(PropertyName = "positionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Discount sum.
        /// </summary>
        [JsonProperty(PropertyName = "discountSum", Required = Required.Always)]
        public double DiscountSum { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Amount { get; set; }

        /// <summary>
        /// Comment. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }
    }
}
