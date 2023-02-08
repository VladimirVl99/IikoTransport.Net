using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Delivery
{
    /// <summary>
    /// Contains information about delivery cancel causes.
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1cancel_causes/post
    /// </summary>
    [JsonObject]
    public class CancelCauseInfo : OperationInfo
    {
        /// <summary>
        /// List of delivery cancel causes.
        /// </summary>
        [JsonProperty(PropertyName = "cancelCauses", Required = Required.Always)]
        public IEnumerable<CancelCause> CancelCauses { get; set; } = default!;
    }
}
