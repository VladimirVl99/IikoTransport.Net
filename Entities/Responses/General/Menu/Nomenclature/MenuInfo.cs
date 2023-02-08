using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about menu.
    /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1nomenclature/post.
    /// </summary>
    [JsonObject]
    public class MenuInfo : OperationInfo
    {
        /// <summary>
        /// Stock list group.
        /// </summary>
        [JsonProperty(PropertyName = "groups", Required = Required.Always)]
        public IEnumerable<ProductGroup> Groups { get; set; } = default!;

        /// <summary>
        /// Menu item category.
        /// </summary>
        [JsonProperty(PropertyName = "productCategories", Required = Required.Always)]
        public IEnumerable<ProductCategory> Categories { get; set; } = default!;

        /// <summary>
        /// Menu items and modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "products", Required = Required.Always)]
        public IEnumerable<Product> Products { get; set; } = default!;

        /// <summary>
        /// Item sizes.
        /// </summary>
        [JsonProperty(PropertyName = "sizes", Required = Required.Always)]
        public IEnumerable<Size> Sizes { get; set; } = default!;

        /// <summary>
        /// Items list revision.
        /// </summary>
        [JsonProperty(PropertyName = "revision", Required = Required.Always)]
        public long Revision { get; set; }
    }
}
