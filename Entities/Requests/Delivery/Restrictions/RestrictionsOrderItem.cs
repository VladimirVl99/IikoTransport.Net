using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Information about a restriction order item.
    /// </summary>
    [JsonObject]
    public class RestrictionsOrderItem : RestrictionsOrderItemShort
    {
        /// <summary>
        /// Modifiers (absolute amount).
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<RestrictionsOrderItemModifier>? Modifiers { get; set; }


        public RestrictionsOrderItem(Guid id, string product, double amount,
            IEnumerable<RestrictionsOrderItemModifier>? modifiers = null)
        {
            Id = id;
            Product = product;
            Amount = amount;
            Modifiers = modifiers;
        }
    }
}
