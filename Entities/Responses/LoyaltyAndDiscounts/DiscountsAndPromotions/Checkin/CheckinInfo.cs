using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Information about the checkin.
    /// </summary>
    [JsonObject]
    public class CheckinInfo
    {
        /// <summary>
        /// Loyalty program results.
        /// </summary>
        [JsonProperty(PropertyName = "loyaltyProgramResults", Required = Required.Always)]
        public IEnumerable<LoyaltyProgramResult> LoyaltyProgramResults { get; set; } = default!;

        /// <summary>
        /// Marketing campaigns with available payments.
        /// </summary>
        [JsonProperty(PropertyName = "availablePayments", Required = Required.Always)]
        public IEnumerable<AvailablePayment> AvailablePayments { get; set; } = default!;

        /// <summary>
        /// Warnings about errors, not blocking loyalty calculation.
        /// </summary>
        [JsonProperty(PropertyName = "validationWarnings", Required = Required.Always)]
        public IEnumerable<string> ValidationWarnings { get; set; } = default!;

        /// <summary>
        /// Warnings about errors, not blocking loyalty calculation.
        /// </summary>
        [JsonProperty(PropertyName = "Warnings", Required = Required.Always)]
        public IEnumerable<WarningInfo> Warnings { get; set; } = default!;

        /// <summary>
        /// Loyalty trace. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "LoyaltyTrace", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? LoyaltyTrace { get; set; }
    }
}
