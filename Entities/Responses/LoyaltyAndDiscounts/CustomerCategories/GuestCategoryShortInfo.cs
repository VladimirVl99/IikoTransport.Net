using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.CustomerCategories
{
    /// <summary>
    /// Guest category for organization.
    /// </summary>
    [JsonObject]
    public class GuestCategoryShortInfo
    {
        /// <summary>
        /// Category id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Category name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Is category active or not.
        /// </summary>
        [JsonProperty(PropertyName = "isActive", Required = Required.Always)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Is category default for new guests or not.
        /// </summary>
        [JsonProperty(PropertyName = "isDefaultForNewGuests", Required = Required.Always)]
        public bool IsDefaultForNewGuests { get; set; }
    }
}
