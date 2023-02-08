using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about combo's specifications.
    /// </summary>
    [JsonObject]
    public class ComboSpecification
    {
        /// <summary>
        /// Id of action that added the combo.
        /// </summary>
        [JsonProperty(PropertyName = "sourceActionId", Required = Required.Always)]
        public Guid SourceActionId { get; set; }

        /// <summary>
        /// Combo's category id.
        /// </summary>
        [JsonProperty(PropertyName = "categoryId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Name. Can be null.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public string? Name { get; set; }

        /// <summary>
        /// Enum: 0 1 2 3 4.
        /// Price modification type.
        /// 0 - fixed combo price,
        /// 1 - fixed position price,
        /// 2 - cheapest position discount,
        /// 3 - most expensive position discount,
        /// 4 - percentage discount for each position.
        /// </summary>
        [JsonProperty(PropertyName = "priceModificationType", Required = Required.Always)]
        public PriceModificationType PriceModificationType { get; set; }

        /// <summary>
        /// Price modification.
        /// </summary>
        [JsonProperty(PropertyName = "priceModification", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double PriceModification { get; set; }

        /// <summary>
        /// Is active.
        /// </summary>
        [JsonProperty(PropertyName = "isActive", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Start date.
        /// </summary>
        [JsonProperty(PropertyName = "startDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Expiration date.
        /// </summary>
        [JsonProperty(PropertyName = "expirationDate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Lacking groups to suggest.
        /// </summary>
        [JsonProperty(PropertyName = "lackingGroupsToSuggest", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? LackingGroupsToSuggest { get; set; }

        /// <summary>
        /// Include modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "includeModifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IncludeModifiers { get; set; }

        /// <summary>
        /// Groups.
        /// </summary>
        [JsonProperty(PropertyName = "groups", Required = Required.Always)]
        public IEnumerable<ComboGroup> Groups { get; set; } = default!;
    }
}
