using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about item size.
    /// </summary>
    [JsonObject]
    public class Size
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public string? Name { get; set; }

        /// <summary>
        /// Priority (serial number) of the size in the size scale.
        /// </summary>
        [JsonProperty(PropertyName = "priority", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Priority { get; set; }

        /// <summary>
        /// Is the default size in the size scale.
        /// </summary>
        [JsonProperty(PropertyName = "isDefault", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDefault { get; set; }
    }
}
