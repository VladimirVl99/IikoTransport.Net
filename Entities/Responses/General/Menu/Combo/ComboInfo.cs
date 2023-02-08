using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about combos.
    /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1combo/post
    /// </summary>
    [JsonObject]
    public class ComboInfo
    {
        /// <summary>
        /// Full combo's specifications.
        /// </summary>
        [JsonProperty(PropertyName = "comboSpecifications", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ComboSpecification>? Specifications { get; set; }

        /// <summary>
        /// Combo's categories.
        /// </summary>
        [JsonProperty(PropertyName = "comboCategories", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ComboCategory>? Categories { get; set; }

        /// <summary>
        /// Warnings about errors, not blocking loyalty calculation.
        /// </summary>
        [JsonProperty(PropertyName = "Warnings", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Warning>? Warnings { get; set; }
    }
}
