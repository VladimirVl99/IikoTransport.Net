using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Payments
{
    /// <summary>
    /// Contains information about payment type and terminal groups where they are available.
    /// </summary>
    [JsonObject]
    public class PaymentType
    {
        /// <summary>
        /// Payment type ID.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Payment type code.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// Payment type name.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Payment type comment.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Combinability attribute.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Combinable { get; set; }

        /// <summary>
        /// External system revision number.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? ExternalRevision { get; set; }

        /// <summary>
        /// Array of marketing campaigns associated with LoyaltyApp payment type applicable to this organization.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", Required = Required.Always)]
        public IEnumerable<Guid> ApplicableMarketingCampaigns { get; set; } = default!;

        /// <summary>
        /// IsDeleted attribute of payment type.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// If true, payment type is fiscal and bill will be printed.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool PrintCheque { get; set; }

        /// <summary>
        /// Enum: "External" "Internal" "Both".
        /// Describes operation processing type.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentProcessingType? PaymentProcessingType { get; set; }

        /// <summary>
        /// Enum: "Unknown" "Cash" "Card" "Credit" "Writeoff" "Voucher" "External" "IikoCard".
        /// Payment type category.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentTypeKind? PaymentTypeKind { get; set; }

        /// <summary>
        /// Terminal groups where this payment type is available.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", Required = Required.Always)]
        public IEnumerable<TerminalGroup> TerminalGroups { get; set; } = default!;
    }
}
