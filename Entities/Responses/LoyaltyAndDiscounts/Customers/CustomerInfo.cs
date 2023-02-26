using IikoTransport.Net.Entities.Common.Customers;
using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.CustomerCategories;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.Customers
{
    /// <summary>
    /// Customer info by specified criterion.
    /// </summary>
    [JsonObject]
    public class CustomerInfo
    {
        /// <summary>
        /// Guest id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Guest referrer id.
        /// </summary>
        [JsonProperty(PropertyName = "referrerId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ReferrerId { get; set; }

        /// <summary>
        /// Guest name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Guest surname. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "surname", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Surname { get; set; }

        /// <summary>
        /// Guest middle name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "middleName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Guest comment. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Main customer's phone. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }

        /// <summary>
        /// Guest culture name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "cultureName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CultureName { get; set; }

        /// <summary>
        /// Guest birthday.
        /// </summary>
        [JsonProperty(PropertyName = "birthday", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Guest email. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Sex.
        /// </summary>
        [JsonProperty(PropertyName = "sex", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Gender Sex { get; set; }

        /// <summary>
        /// Guest consent status.
        /// </summary>
        [JsonProperty(PropertyName = "consentStatus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public GuestConsentStatus ConsentStatus { get; set; }

        /// <summary>
        /// Guest anonymized.
        /// </summary>
        [JsonProperty(PropertyName = "anonymized", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Anonymized { get; set; }

        /// <summary>
        /// Customer's cards.
        /// </summary>
        [JsonProperty(PropertyName = "cards", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<GuestCardInfo>? Cards { get; set; }

        /// <summary>
        /// Customer categories.
        /// </summary>
        [JsonProperty(PropertyName = "categories", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<GuestCategoryShortInfo>? Categories { get; set; }

        /// <summary>
        /// Customer's user wallets. Contains bonus balances of different loyalty programs.
        /// </summary>
        [JsonProperty(PropertyName = "walletBalances", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<GuestBalanceInfo>? WalletBalances { get; set; }

        /// <summary>
        /// Technical user data, customizable by restaurateur. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "userData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? UserData { get; set; }

        /// <summary>
        /// Customer get promo messages (email, sms). If null - unknown.
        /// </summary>
        [JsonProperty(PropertyName = "shouldReceivePromoActionsInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ShouldReceivePromoActionsInfo { get; set; }

        /// <summary>
        /// Guest should receive loyalty info.
        /// </summary>
        [JsonProperty(PropertyName = "shouldReceiveLoyaltyInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ShouldReceiveLoyaltyInfo { get; set; }

        /// <summary>
        /// Guest should receive order status info.
        /// </summary>
        [JsonProperty(PropertyName = "shouldReceiveOrderStatusInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ShouldReceiveOrderStatusInfo { get; set; }

        /// <summary>
        /// Guest personal data consent from.
        /// </summary>
        [JsonProperty(PropertyName = "personalDataConsentFrom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? PersonalDataConsentFrom { get; set; }

        /// <summary>
        /// Guest personal data consent to.
        /// </summary>
        [JsonProperty(PropertyName = "personalDataConsentTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? PersonalDataConsentTo { get; set; }

        /// <summary>
        /// Guest personal data processing from.
        /// </summary>
        [JsonProperty(PropertyName = "personalDataProcessingFrom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? PersonalDataProcessingFrom { get; set; }

        /// <summary>
        /// Guest personal data processing to.
        /// </summary>
        [JsonProperty(PropertyName = "personalDataProcessingTo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? PersonalDataProcessingTo { get; set; }

        /// <summary>
        /// Customer marked as deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDeleted { get; set; }
    }
}
