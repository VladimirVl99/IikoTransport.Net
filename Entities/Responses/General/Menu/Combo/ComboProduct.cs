using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about a product.
    /// </summary>
    [JsonObject]
    public class ComboProduct
    {
        /// <summary>
        /// Product id.
        /// </summary>
        [JsonProperty(PropertyName = "productId", Required = Required.Always)]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Size id.
        /// </summary>
        [JsonProperty(PropertyName = "sizeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? SizeId { get; set; }

        /// <summary>
        /// Forbidden modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "forbiddenModifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? ForbiddenModifiers { get; set; }

        /// <summary>
        /// Price modification amount.
        /// </summary>
        [JsonProperty(PropertyName = "priceModificationAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double PriceModificationAmount { get; set; }
    }
}
