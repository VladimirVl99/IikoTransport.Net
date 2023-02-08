using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Combo.
    /// </summary>
    [JsonObject]
    public class Combo
    {
        /// <summary>
        /// Combo ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of combo.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Number of combos.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public int Amount { get; set; }

        /// <summary>
        /// Price of combo. Given for 1 combo, without regard to amount.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double Price { get; set; }

        /// <summary>
        /// Combo action ID.
        /// </summary>
        [JsonProperty(PropertyName = "sourceId", Required = Required.Always)]
        public Guid SourceId { get; set; }
    }
}
