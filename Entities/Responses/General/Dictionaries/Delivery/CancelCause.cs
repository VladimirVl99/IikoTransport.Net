using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Delivery
{
    /// <summary>
    /// Contains list of delivery cancel causes.
    /// </summary>
    [JsonObject]
    public class CancelCause
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Is deleted sign.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", Required = Required.Default)]
        public bool IsDeleted { get; set; }
    }
}
