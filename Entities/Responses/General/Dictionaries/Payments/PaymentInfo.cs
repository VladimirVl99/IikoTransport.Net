using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Payments
{
    /// <summary>
    /// Contains information about payment types.
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1payment_types/post.
    /// </summary>
    [JsonObject]
    public class PaymentInfo : OperationInfo
    {
        /// <summary>
        /// List of payment types and terminal groups where they are available.
        /// </summary>
        [JsonProperty(PropertyName = "paymentTypes", Required = Required.Always)]
        public IEnumerable<PaymentType> PaymentTypes { get; set; } = default!;
    }
}
