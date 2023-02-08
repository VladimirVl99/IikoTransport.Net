using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about size price.
    /// </summary>
    [JsonObject]
    public class SizePrice
    {
        /// <summary>
        /// Item size ID.
        /// </summary>
        [JsonProperty(PropertyName = "sizeId", Required = Required.AllowNull)]
        public Guid? SizeId { get; set; }

        /// <summary>
        /// Price per this item size.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public Price Price { get; set; } = default!;
    }
}
