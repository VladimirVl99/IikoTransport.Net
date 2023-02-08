using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Contains information about a location.
    /// </summary>
    [JsonObject]
    public class CoordinateInfo
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonProperty(PropertyName = "latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        [JsonProperty(PropertyName = "longitude", Required = Required.Always)]
        public double Longitude { get; set; }

        /// <summary>
        /// Time of coordinate saving on server in the Unix timestamp format.
        /// </summary>
        [JsonProperty(PropertyName = "serverTimestamp", Required = Required.Always)]
        public long ServerTimestamp { get; set; }
    }
}
