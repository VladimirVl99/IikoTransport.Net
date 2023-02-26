using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.ManualConditions
{
    /// <summary>
    /// Info about manual condition.
    /// </summary>
    [JsonObject]
    public class ManualCondition
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of manual condition.
        /// </summary>
        [JsonProperty(PropertyName = "caption", Required = Required.Always)]
        public string Caption { get; set; } = default!;

        /// <summary>
        /// Arbitrary discount attribute.
        /// </summary>
        [JsonProperty(PropertyName = "isDynamicDiscount", Required = Required.Always)]
        public bool IsDynamicDiscount { get; set; }
    }
}
