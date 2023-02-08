using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about a combo price.
    /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1combo~1calculate/post.
    /// </summary>
    [JsonObject]
    public class ComboPriceInfo
    {
        /// <summary>
        /// Calculated price of combo item.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double Price { get; set; }

        /// <summary>
        /// Ids of incorrectly filled groups. If not empty - price will be 0.
        /// </summary>
        [JsonProperty(PropertyName = "incorrectlyFilledGroups", Required = Required.Always)]
        public IEnumerable<Guid> IncorrectlyFilledGroups { get; set; } = default!;
    }
}
