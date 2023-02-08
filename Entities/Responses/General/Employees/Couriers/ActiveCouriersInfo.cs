using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// List of all active (courier session is opened) courier's locations which are delivery
    /// drivers in specified restaurant and are clocked in on specified delivery terminal.
    /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1active_location~1by_terminal/post.
    /// </summary>
    [JsonObject]
    public class ActiveCouriersInfo : OperationInfo
    {
        /// <summary>
        /// List of courier's locations.
        /// </summary>
        [JsonProperty(PropertyName = "activeCourierLocations", Required = Required.Always)]
        public IEnumerable<ActiveCouriersByOrganization> ActiveCourierLocations { get; set; } = default!;
    }
}
