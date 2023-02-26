using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs
{
    /// <summary>
    /// Information about a loyalty program.
    /// </summary>
    [JsonObject]
    public class LoyaltyProgram
    {
        /// <summary>
        /// Program id.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Program name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Program description. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// Program works since date.
        /// </summary>
        [JsonProperty(PropertyName = "serviceFrom", Required = Required.Always)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime ServiceFrom { get; set; }

        /// <summary>
        /// Program works till date.
        /// </summary>
        [JsonProperty(PropertyName = "serviceTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? ServiceTo { get; set; }

        /// <summary>
        /// Notify customer when balance has changed (sms/push).
        /// </summary>
        [JsonProperty(PropertyName = "notifyAboutBalanceChanges", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool NotifyAboutBalanceChanges { get; set; }

        /// <summary>
        /// Program type.
        /// </summary>
        [JsonProperty(PropertyName = "programType", Required = Required.Always)]
        public ProgramType ProgramType { get; set; }

        /// <summary>
        /// Program is active.
        /// </summary>
        [JsonProperty(PropertyName = "isActive", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Wallet id. Program has only wallet that means global payment type for customers.
        /// </summary>
        [JsonProperty(PropertyName = "walletId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? WalletId { get; set; }

        /// <summary>
        /// Program marketing campaigns.
        /// </summary>
        [JsonProperty(PropertyName = "marketingCampaigns", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<MarketingCampaignInfo>? MarketingCampaigns { get; set; }

        /// <summary>
        /// Program applied organizations.
        /// </summary>
        [JsonProperty(PropertyName = "appliedOrganizations", Required = Required.Always)]
        public IEnumerable<Guid> AppiedOrganizations { get; set; } = default!;

        /// <summary>
        /// Program template type.
        /// </summary>
        [JsonProperty(PropertyName = "templateType", Required = Required.Always)]
        public TemplateType TemplateType { get; set; }

        /// <summary>
        /// Program has welcome bonus.
        /// </summary>
        [JsonProperty(PropertyName = "hasWelcomeBonus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool HasWelcomeBonus { get; set; }

        /// <summary>
        /// All new customers will get bonus.
        /// </summary>
        [JsonProperty(PropertyName = "welcomeBonusSum", Required = Required.Always)]
        public double WelcomeBonusSum { get; set; }

        /// <summary>
        /// Exchange rate for bonuses and real currency.
        /// </summary>
        [JsonProperty(PropertyName = "isExchangeRateEnabled", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsExchangeRateEnabled { get; set; }

        /// <summary>
        /// Refill type with payment.
        /// </summary>
        [JsonProperty(PropertyName = "refillType", Required = Required.Always)]
        public int RefillType { get; set; }
    }
}
