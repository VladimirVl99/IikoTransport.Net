using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.DiscountsAndSurcharges
{
    /// <summary>
    /// Contains information about discounts/surcharges.
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1discounts/post.
    /// </summary>
    [JsonObject]
    public class DiscountInfo : OperationInfo
    {
        /// <summary>
        /// List of discounts/surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "discounts", Required = Required.Always)]
        public IEnumerable<Discount> Discounts { get; set; } = default!;
    }
}
