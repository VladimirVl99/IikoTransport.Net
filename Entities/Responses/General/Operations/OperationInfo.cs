using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Operations
{
    [JsonObject]
    public class OperationInfo
    {
        /// <summary>
        /// Operation ID.
        /// </summary>
        [JsonProperty(PropertyName = "correlationId", Required = Required.Always)]
        public Guid CorrelationId { get; set; }
    }
}
