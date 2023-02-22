using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    /// <summary>
    /// Restaurant section mark.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionMark : RestaurantSectionElement
    {
        /// <summary>
        /// Text.
        /// </summary>
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; } = default!;

        /// <summary>
        /// Font.
        /// </summary>
        [JsonProperty(PropertyName = "font", Required = Required.Always)]
        public Font Font { get; set; } = default!;

        /// <summary>
        /// Color.
        /// </summary>
        [JsonProperty(PropertyName = "color", Required = Required.Always)]
        public Color Color { get; set; } = default!;
    }
}
