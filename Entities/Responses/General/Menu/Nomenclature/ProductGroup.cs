using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about stock group.
    /// </summary>
    [JsonObject]
    public class ProductGroup : ProductGroupShort
    {
        /// <summary>
        /// Links to images.
        /// </summary>
        [JsonProperty(PropertyName = "imageLinks", Required = Required.Always)]
        public IEnumerable<string> ImageLinks { get; set; } = default!;

        /// <summary>
        /// Parent group.
        /// </summary>
        [JsonProperty(PropertyName = "parentGroup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ParentGroup { get; set; }

        /// <summary>
        /// Group's order (priority) in menu.
        /// </summary>
        [JsonProperty(PropertyName = "order", Required = Required.Always)]
        public int Order { get; set; }

        /// <summary>
        /// On-the-menu attribute.
        /// </summary>
        [JsonProperty(PropertyName = "isIncludedInMenu", Required = Required.Always)]
        public bool IsIncludedInMenu { get; set; }

        /// <summary>
        /// Is group modifier attribute.
        /// true - group modifier.
        /// false - external menu group.
        /// </summary>
        [JsonProperty(PropertyName = "isGroupModifier", Required = Required.Always)]
        public bool IsGroupModifier { get; set; }

        /// <summary>
        /// SKU.
        /// </summary>
        [JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Code { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

        /// <summary>
        /// Additional information.
        /// </summary>
        [JsonProperty(PropertyName = "additionalInfo", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? AdditionalInfo { get; set; }

        /// <summary>
        /// Tags.
        /// </summary>
        [JsonProperty(PropertyName = "tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<string>? Tags { get; set; }

        /// <summary>
        /// Is-Deleted attribute.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// SEO description for client.
        /// </summary>
        [JsonProperty(PropertyName = "seoDescription", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SeoDescription { get; set; }

        /// <summary>
        /// SEO text for robots.
        /// </summary>
        [JsonProperty(PropertyName = "seoText", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SeoText { get; set; }

        /// <summary>
        /// SEO key words.
        /// </summary>
        [JsonProperty(PropertyName = "seoKeywords", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SeoKeywords { get; set; }

        /// <summary>
        /// SEO header.
        /// </summary>
        [JsonProperty(PropertyName = "seoTitle", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? SeoTitle { get; set; }
    }
}
