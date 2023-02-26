using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Information about a problem.
    /// </summary>
    [JsonObject]
    public class Problem
    {
        /// <summary>
        /// Has problem.
        /// </summary>
        [JsonProperty(PropertyName = "hasProblem", Required = Required.Always)]
        public bool HasProblem { get; set; }

        /// <summary>
        /// Problem description.
        /// </summary>
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }
    }
}
