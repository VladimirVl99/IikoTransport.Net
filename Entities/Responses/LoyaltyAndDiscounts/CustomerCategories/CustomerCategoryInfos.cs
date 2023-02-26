using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.CustomerCategories
{
    /// <summary>
    /// All organization's customer categories.
    /// </summary>
    [JsonObject]
    public class CustomerCategoryInfos
    {
        /// <summary>
        /// Guest categories for organization.
        /// </summary>
        [JsonProperty(PropertyName = "guestCategories", Required = Required.Always)]
        public IEnumerable<GuestCategoryShortInfo> GuestCategories { get; set; } = default!;
    }
}
