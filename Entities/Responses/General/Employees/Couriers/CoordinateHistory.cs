using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains drivers' coordinates history.
    /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1locations~1by_time_offset/post.
    /// </summary>
    [JsonObject]
    public class CoordinateHistory : OperationInfo
    {
        /// <summary>
        /// List of drivers' coordinates broken down by organizations.
        /// </summary>
        [JsonProperty(PropertyName = "courierLocations", Required = Required.Always)]
        public IEnumerable<LocationsByOrganization> CourierLocations { get; set; } = default!;
    }
}
