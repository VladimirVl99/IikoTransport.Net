using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    /// <summary>
    /// Restaurant section rectangle.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionRectangle : RestaurantSectionElement
    {
        /// <summary>
        /// Color.
        /// </summary>
        [JsonProperty(PropertyName = "color", Required = Required.Always)]
        public Color Color { get; set; } = default!;
    }
}
