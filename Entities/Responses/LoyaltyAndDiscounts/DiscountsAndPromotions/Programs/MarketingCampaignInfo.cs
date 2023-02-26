using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs
{
    /// <summary>
    /// Program marketing campaign.
    /// </summary>
    [JsonObject]
    public class MarketingCampaignInfo
    {
        /// <summary>
        /// Marketing campaign id.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Loyalty program id.
        /// </summary>
        [JsonProperty(PropertyName = "programId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProgramId { get; set; }

        /// <summary>
        /// Loyalty program name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Marketing campaign description. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// Marketing campaign is active.
        /// </summary>
        [JsonProperty(PropertyName = "isActive", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Marketing campaign works since date.
        /// </summary>
        [JsonProperty(PropertyName = "periodFrom", Required = Required.Always)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime PeriodFrom { get; set; }

        /// <summary>
        /// Marketing campaign works till date. Null means limitless.
        /// </summary>
        [JsonProperty(PropertyName = "periodTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? PeriodTo { get; set; }

        /// <summary>
        /// Conditions and actions that will be checked when order is processed.
        /// </summary>
        [JsonProperty(PropertyName = "orderActionConditionBindings",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignActionConditionBindingInfo>?
            OrderActionConditionBindings { get; set; }

        /// <summary>
        /// Conditions and actions that will be checked by schedule.
        /// </summary>
        [JsonProperty(PropertyName = "periodicActionConditionBindings",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignActionConditionBindingInfo>?
            PeriodicActionConditionBindings { get; set; }

        /// <summary>
        /// Conditions and actions that will be checked by overdraft.
        /// </summary>
        [JsonProperty(PropertyName = "overdraftActionConditionBindings",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignActionConditionBindingInfo>?
            OverdraftActionConditionBindings { get; set; }

        /// <summary>
        /// Conditions and actions that will be checked by guest registration.
        /// </summary>
        [JsonProperty(PropertyName = "guestRegistrationActionConditionBindings",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignActionConditionBindingInfo>?
            GuestRegistrationActionConditionBindings { get; set; }
    }
}
