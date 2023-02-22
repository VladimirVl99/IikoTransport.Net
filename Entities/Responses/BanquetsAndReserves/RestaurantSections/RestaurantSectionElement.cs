using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    [JsonObject]
    public class RestaurantSectionElement
    {
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
