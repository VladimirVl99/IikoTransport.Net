using IikoTransport.Net.Entities.Responses.General.Employees.Couriers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Driver information.
    /// </summary>
    [JsonObject]
    public class CourierInfo
    {
        /// <summary>
        /// Order driver.
        /// </summary>
        [JsonProperty(PropertyName = "courier", Required = Required.Always)]
        public Courier Courier { get; set; } = default!;

        /// <summary>
        /// Whether driver is selected manually.
        /// </summary>
        [JsonProperty(PropertyName = "isCourierSelectedManually", Required = Required.Always)]
        public bool IsCourierSelectedManually { get; set; }
    }
}
