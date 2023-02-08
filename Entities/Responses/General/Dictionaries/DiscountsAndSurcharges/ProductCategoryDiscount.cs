using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.DiscountsAndSurcharges
{
    /// <summary>
    /// Contains the category discount information.
    /// </summary>
    [JsonObject]
    public class ProductCategoryDiscount
    {
        /// <summary>
        /// Category ID.
        /// </summary>
        [JsonProperty(PropertyName = "categoryId", Required = Required.Always)]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Category name.
        /// </summary>
        [JsonProperty(PropertyName = "categoryName", Required = Required.AllowNull)]
        public string? CategoryName { get; set; }

        /// <summary>
        /// This category discount %.
        /// </summary>
        [JsonProperty(PropertyName = "percent", Required = Required.Always)]
        public double Percent { get; set; }
    }
}
