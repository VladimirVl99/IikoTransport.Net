using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature.ExternalMenus
{
    /// <summary>
    /// Contains information about tax category.
    /// </summary>
    [JsonObject]
    public class TaxCategory
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        /// <summary>
        /// Percentage.
        /// </summary>
        [JsonProperty(PropertyName = "percentage", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float? Percentage { get; set; }
    }
}
