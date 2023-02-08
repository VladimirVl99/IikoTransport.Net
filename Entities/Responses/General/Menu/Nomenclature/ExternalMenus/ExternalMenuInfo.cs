using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature.ExternalMenus
{
    /// <summary>
    /// Contains information about external menus with price categories.
    /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~12~1menu/post.
    /// </summary>
    [JsonObject]
    public class ExternalMenuInfo : OperationInfo
    {
        /// <summary>
        /// External menu.
        /// </summary>
        [JsonProperty(PropertyName = "externalMenus", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ExternalMenu>? ExternalMenus { get; set; }

        /// <summary>
        /// Price category.
        /// </summary>
        [JsonProperty(PropertyName = "priceCategories", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<PriceCategory>? PriceCategories { get; set; }
    }
}
