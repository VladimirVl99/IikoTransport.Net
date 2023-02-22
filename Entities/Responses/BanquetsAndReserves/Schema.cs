using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Table layout.
    /// </summary>
    [JsonObject]
    public class Schema
    {
        /// <summary>
        /// Layout width in px.
        /// </summary>
        [JsonProperty(PropertyName = "width", Required = Required.Always)]
        public int Width { get; set; }

        /// <summary>
        /// Layout height in px.
        /// </summary>
        [JsonProperty(PropertyName = "height", Required = Required.Always)]
        public int Height { get; set; }

        /// <summary>
        /// Collection of restaurant section marks.
        /// </summary>
        [JsonProperty(PropertyName = "markElements", Required = Required.Always)]
        public IEnumerable<RestaurantSectionMark> MarkElements { get; set; } = default!;

        /// <summary>
        /// Collection of restaurant section tables.
        /// </summary>
        [JsonProperty(PropertyName = "tableElements", Required = Required.Always)]
        public IEnumerable<RestaurantSectionTable> TableElements { get; set; } = default!;

        /// <summary>
        /// Collection of restaurant section rectangles.
        /// </summary>
        [JsonProperty(PropertyName = "rectangleElements", Required = Required.Always)]
        public IEnumerable<RestaurantSectionRectangle> RectangleElements { get; set; } = default!;

        /// <summary>
        /// Collection of restaurant section ellipses.
        /// </summary>
        [JsonProperty(PropertyName = "ellipseElements", Required = Required.Always)]
        public IEnumerable<RestaurantSectionEllipse> EllipseElements { get; set; } = default!;

        /// <summary>
        /// Last modified time.
        /// </summary>
        [JsonProperty(PropertyName = "revision", Required = Required.Always)]
        public long Revision { get; set; }

        /// <summary>
        /// Is schema deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
        public bool IsDeleted { get; set; }
    }
}
