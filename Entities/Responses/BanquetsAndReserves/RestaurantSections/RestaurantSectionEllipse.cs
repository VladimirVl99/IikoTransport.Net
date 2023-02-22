using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    /// <summary>
    /// Restaurant section ellipse.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionEllipse : RestaurantSectionElement
    {
        /// <summary>
        /// Color.
        /// </summary>
		[JsonProperty(PropertyName = "color", Required = Required.Always)]
        public Color Color { get; set; } = default!;
    }
}
