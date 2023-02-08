using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about a group.
    /// </summary>
    [JsonObject]
    public class ComboGroup
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Is main group.
        /// </summary>
        [JsonProperty(PropertyName = "isMainGroup", Required = Required.Always)]
        public bool IsMainGroup { get; set; }

        /// <summary>
        /// Products.
        /// </summary>
        [JsonProperty(PropertyName = "products", Required = Required.Always)]
        public IEnumerable<ComboProduct>? Products { get; set; } = default!;
    }
}
