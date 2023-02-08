using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about menu item category.
    /// </summary>
    [JsonObject]
    public class ProductCategory
    {
        /// <summary>
        /// Product category ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Is deleted attribute.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
        public bool IsDeleted { get; set; }
    }
}
