using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains list of all employees which are delivery drivers in specified restaurants.
    /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers/post.
    /// </summary>
    [JsonObject]
    public class CouriersInfo : OperationInfo
    {
        /// <summary>
        /// List of drivers.
        /// </summary>
        [JsonProperty(PropertyName = "employees", Required = Required.Always)]
        public IEnumerable<CouriersByOrganization>? Employees { get; set; } = default!;
    }
}
