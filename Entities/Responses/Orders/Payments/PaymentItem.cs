using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Payments
{
    /// <summary>
    /// Information about a payment.
    /// </summary>
    [JsonObject]
    public class PaymentItem
    {
        /// <summary>
        /// Payment type.
        /// Can be obtained by https://api-ru.iiko.services/api/1/payment_types operation.
        /// </summary>
        [JsonProperty(PropertyName = "paymentType", Required = Required.Always)]
        public PaymentType PaymentType { get; set; } = default!;

        /// <summary>
        /// Amount due.
        /// </summary>
        [JsonProperty(PropertyName = "sum", Required = Required.Always)]
        public double Sum { get; set; }

        /// <summary>
        /// Whether payment item is preliminary.
        /// </summary>
        [JsonProperty(PropertyName = "isPreliminary", Required = Required.Always)]
        public bool IsPreliminary { get; set; }

        /// <summary>
        /// Payment item is external (created via biz.API).
        /// </summary>
        [JsonProperty(PropertyName = "isExternal", Required = Required.Always)]
        public bool IsExternal { get; set; }

        /// <summary>
        /// Payment item is processed by external payment system.
        /// </summary>
        [JsonProperty(PropertyName = "isProcessedExternally", Required = Required.Always)]
        public bool IsProcessedExternally { get; set; }
        
        /// <summary>
        /// Whether the payment item is externally fiscalized.
        /// Allowed from version 7.6.3.
        /// </summary>
        [JsonProperty(PropertyName = "isFiscalizedExternally", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsFiscalizedExternally { get; set; }
    }
}
