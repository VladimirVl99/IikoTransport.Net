using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Restaurant section mark.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionMark
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

        /// <summary>
        /// X coordinate of left point of item.
        /// </summary>
        [JsonProperty(PropertyName = "x", Required = Required.Always)]
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of top point of item.
        /// </summary>
        [JsonProperty(PropertyName = "y", Required = Required.Always)]
        public int Y { get; set; }

        /// <summary>
        /// Z-index of item.
        /// </summary>
        [JsonProperty(PropertyName = "z", Required = Required.Always)]
        public int Z { get; set; }

        /// <summary>
        /// Item's angle of slope.
        /// </summary>
        [JsonProperty(PropertyName = "angle", Required = Required.Always)]
        public double Angle { get; set; }

        /// <summary>
        /// Item's width in px.
        /// </summary>
        [JsonProperty(PropertyName = "width", Required = Required.Always)]
        public int Width { get; set; }

        /// <summary>
        /// Item's height in px.
        /// </summary>
        [JsonProperty(PropertyName = "height", Required = Required.Always)]
        public int Height { get; set; }
    }
}
