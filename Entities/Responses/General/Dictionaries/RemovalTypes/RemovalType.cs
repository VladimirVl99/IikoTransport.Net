using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.RemovalTypes
{
    /// <summary>
    /// Contains information about removal type.
    /// </summary>
    [JsonObject]
    public class RemovalType
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of removal type.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Can write off to cafe.
        /// </summary>
        [JsonProperty(PropertyName = "canWriteoffToCafe", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CanWriteoffToCafe { get; set; }

        /// <summary>
        /// Can write off to waiter.
        /// </summary>
        [JsonProperty(PropertyName = "canWriteoffToWaiter", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CanWriteoffToWaiter { get; set; }

        /// <summary>
        /// Can write off to user.
        /// </summary>
        [JsonProperty(PropertyName = "canWriteoffToUser", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool CanWriteoffToUser { get; set; }

        /// <summary>
        /// Require comments on operations.
        /// </summary>
        [JsonProperty(PropertyName = "reasonRequired", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ReasonRequired { get; set; }

        /// <summary>
        /// Can be used manually.
        /// </summary>
        [JsonProperty(PropertyName = "manual", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Manual { get; set; }

        /// <summary>
        /// Is deleted sign.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
    }
}
