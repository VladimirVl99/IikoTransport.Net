using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    /// <summary>
    /// Restaurant section table.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionTable : RestaurantSectionElement
    {
        /// <summary>
        /// Table ID.
        /// </summary>
        [JsonProperty(PropertyName = "tableId", Required = Required.Always)]
        public Guid TableId { get; set; }
    }
}
