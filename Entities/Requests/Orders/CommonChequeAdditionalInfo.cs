using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders
{
    /// <summary>
    /// Cheque additional information according to russian federal law #54.
    /// </summary>
    [JsonObject]
    public class CommonChequeAdditionalInfo
    {
        /// <summary>
        /// Whether paper cheque should be printed.
        /// </summary>
        [JsonProperty(PropertyName = "needReceipt", Required = Required.Always)]
        public bool NeedReceipt { get; set; }

        /// <summary>
        /// Email to send cheque information or null if the cheque shouldn't be sent by email.
        /// </summary>
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        /// <summary>
        /// Settlement place.
        /// </summary>
        [JsonProperty(PropertyName = "settlementPlace", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SettlementPlace { get; set; }

        /// <summary>
        /// Phone to send cheque information (by sms) or null if the cheque shouldn't be sent by sms.
        /// </summary>
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }
    }
}
