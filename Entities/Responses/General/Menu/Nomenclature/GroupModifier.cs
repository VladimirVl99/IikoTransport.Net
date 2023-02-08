using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about the modifier group.
    /// </summary>
    [JsonObject]
    public class GroupModifier
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

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
        [JsonProperty(PropertyName = "required", Required = Required.AllowNull)]
        public bool? IsRequired { get; set; }

        /// <summary>
        /// Presence of max/min quantity limitations of child modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "childModifiersHaveMinMaxRestrictions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? ChildModifiesHaveMinMaxRestrictions { get; set; }

        /// <summary>
        /// List of child modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "childModifiers", Required = Required.Always)]
        public IEnumerable<Modifier> ChildModifiers { get; set; } = default!;

        /// <summary>
        /// Hide if the amount is by default. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "hideIfDefaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? HideIfDefaultAmount { get; set; }

        /// <summary>
        /// Amount by default. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "defaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DefaultAmount { get; set; }

        /// <summary>
        /// Modifier can be split. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "splittable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Splittable { get; set; }

        /// <summary>
        /// Free amount. This field is supported since 7.2.4 iikoRMS version.
        /// </summary>
        [JsonProperty(PropertyName = "freeOfChargeAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? FreeOfChargeAmount { get; set; }
    }
}
