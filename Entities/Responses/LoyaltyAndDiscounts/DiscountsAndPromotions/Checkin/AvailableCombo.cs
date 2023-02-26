using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Partially added combos, available for assembly.
    /// </summary>
    [JsonObject]
    public class AvailableCombo
    {
        /// <summary>
        /// Id of combo specification, describing combo content.
        /// </summary>
        [JsonProperty(PropertyName = "specificationId", Required = Required.Always)]
        public Guid SpecificationId { get; set; }

        /// <summary>
        /// Groups contained in combo. If null - there is no suitable product in order yet for that group.
        /// </summary>
        [JsonProperty(PropertyName = "groupMapping", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ComboGroupMapping>? GroupMapping { get; set; }
    }
}
