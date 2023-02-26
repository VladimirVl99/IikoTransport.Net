using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Suggested item to add or advices for customer.
    /// </summary>
    [JsonObject]
    public class Upsale
    {
        /// <summary>
        /// Id of action that caused the suggestion.
        /// </summary>
        [JsonProperty(PropertyName = "sourceActionId", Required = Required.Always)]
        public Guid SourceActionId { get; set; }

        /// <summary>
        /// Suggestion text.
        /// </summary>
        [JsonProperty(PropertyName = "suggestionText", Required = Required.Always)]
        public string SuggestionText { get; set; } = default!;

        /// <summary>
        /// Codes of products that suggested to be added to order.
        /// </summary>
        [JsonProperty(PropertyName = "productCodes", Required = Required.Always)]
        public IEnumerable<string> ProductCodes { get; set; } = default!;
    }
}
