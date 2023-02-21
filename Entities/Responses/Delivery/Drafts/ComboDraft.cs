using IikoTransport.Net.Entities.Common.Combos;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about a draft combo.
    /// </summary>
    [JsonObject]
    public class ComboDraft : ComboShort
    {
        /// <summary>
        /// Card program ID.
        /// Allowed from version 7.6.1.
        /// </summary>
        [JsonProperty(PropertyName = "programId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid ProgramId { get; set; }
    }
}
