using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections
{
    /// <summary>
    /// All restaurant sections of specified terminal groups,
    /// for which banquet/reserve booking are available.
    /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1available_restaurant_sections/post.
    /// </summary>
    [JsonObject]
    public class RestaurantSectionsWithOperation : OperationInfo
    {
        /// <summary>
        /// Restaurant sections.
        /// </summary>
        [JsonProperty(PropertyName = "restaurantSections", Required = Required.Always)]
        public IEnumerable<RestaurantSection> RestaurantSections { get; set; } = default!;

        /// <summary>
        /// Items list revision.
        /// </summary>
        [JsonProperty(PropertyName = "revision", Required = Required.Always)]
        public long Revision { get; set; }
    }
}
