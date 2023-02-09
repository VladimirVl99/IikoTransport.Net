using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Common information about an order item size.
    /// </summary>
    [JsonObject]
    public class SizeShort
    {
        /// <summary>
        /// ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public virtual string? Name { get; set; }
    }
}
