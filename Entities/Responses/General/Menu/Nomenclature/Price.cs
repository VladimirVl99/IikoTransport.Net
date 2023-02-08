using IikoTransport.Net.Entities.Common.Date;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about price.
    /// </summary>
    [JsonObject]
    public class Price
    {
        /// <summary>
        /// Current price.
        /// </summary>
        [JsonProperty(PropertyName = "currentPrice", Required = Required.Always)]
        public double CurrentPrice { get; set; }

        /// <summary>
        /// Is on the menu.
        /// </summary>
        [JsonProperty(PropertyName = "isIncludedInMenu", Required = Required.Always)]
        public bool IsIncludedInMenu { get; set; }

        /// <summary>
        /// New price.
        /// </summary>
        [JsonProperty(PropertyName = "nextPrice", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? NextPrice { get; set; }

        /// <summary>
        /// Will be on the menu in the future.
        /// </summary>
        [JsonProperty(PropertyName = "nextIncludedInMenu", Required = Required.Always)]
        public bool NextIncludedMenu { get; set; }

        /// <summary>
        /// New price validity start date (Local for the terminal).
        /// </summary>
        [JsonProperty(PropertyName = "nextDatePrice", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? NextDatePrice { get; set; }
    }
}
