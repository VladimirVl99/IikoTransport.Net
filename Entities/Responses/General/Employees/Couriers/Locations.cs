using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees.Couriers
{
    /// <summary>
    /// Contains information about locations of a courier.
    /// </summary>
    [JsonObject]
    public class Locations
    {
        /// <summary>
        /// Driver ID.
        /// </summary>
        [JsonProperty(PropertyName = "courierId", Required = Required.Always)]
        public Guid CourierId { get; set; }

        /// <summary>
        /// List of locations.
        /// </summary>
        [JsonProperty(PropertyName = "locations", Required = Required.Always)]
        public IEnumerable<CoordinateInfo> Items { get; set; } = default!;
    }
}
