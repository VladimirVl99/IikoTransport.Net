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
    public class Size : SizeShort
    {
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
