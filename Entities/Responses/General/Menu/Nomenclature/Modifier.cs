using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about a modifier.
    /// </summary>
    [JsonObject]
    public class Modifier
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Default quantity.
        /// </summary>
        [JsonProperty(PropertyName = "defaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DefaultAmount { get; set; }

        /// <summary>
        /// Minimum quantity.
        /// </summary>
        [JsonProperty(PropertyName = "minAmount", Required = Required.Always)]
        public int MinAmount { get; set; }

        /// <summary>
        /// Maximum quantity.
        /// </summary>
        [JsonProperty(PropertyName = "maxAmount", Required = Required.Always)]
        public int MaxAmount { get; set; }

        /// <summary>
        /// Required availability.
        /// </summary>
        [JsonProperty(PropertyName = "required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsRequired { get; set; }

        /// <summary>
        /// Hide if default amount applied. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "hideIfDefaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? HideIfDefaultAmount { get; set; }

        /// <summary>
        /// Modifier can be split. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "splittable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Splittable { get; set; }

        /// <summary>
        /// Free of charge amount. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "freeOfChargeAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? FreeOfChargeAmount { get; set; }
    }
}
