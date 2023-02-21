using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Contains information about menu item and modifier.
    /// </summary>
    [JsonObject]
    public class Product : ProductShort
    {
        /// <summary>
        /// Fat per 100g.
        /// </summary>
        [JsonProperty(PropertyName = "fatAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? FatAmount { get; set; }

        /// <summary>
        /// Protein per 100g.
        /// </summary>
        [JsonProperty(PropertyName = "proteinsAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? ProteinsAmount { get; set; }

        /// <summary>
        /// Carbohydrate per 100g.
        /// </summary>
        [JsonProperty(PropertyName = "carbohydratesAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? CarbohydratesAmount { get; set; }

        /// <summary>
        /// Calories per 100g.
        /// </summary>
        [JsonProperty(PropertyName = "energyAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? EnergyAmount { get; set; }

        /// <summary>
        /// Fat per item.
        /// </summary>
        [JsonProperty(PropertyName = "fatFullAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? FatFullAmount { get; set; }

        /// <summary>
        /// Protein per item.
        /// </summary>
        [JsonProperty(PropertyName = "proteinsFullAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? ProteinsFullAmount { get; set; }

        /// <summary>
        /// Carbohydrate per item.
        /// </summary>
        [JsonProperty(PropertyName = "carbohydratesFullAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? CarbohydratesFullAmount { get; set; }

        /// <summary>
        /// Calories per item.
        /// </summary>
        [JsonProperty(PropertyName = "energyFullAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? EnergyFullAmount { get; set; }

        /// <summary>
        /// Item weight.
        /// </summary>
        [JsonProperty(PropertyName = "weight", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Weight { get; set; }

        /// <summary>
        /// Stock list group in RMS.
        /// </summary>
        [JsonProperty(PropertyName = "groupId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? GroupId { get; set; }

        /// <summary>
        /// Product category in RMS.
        /// </summary>
        [JsonProperty(PropertyName = "productCategoryId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ProductCategoryId { get; set; }

        /// <summary>
        /// dish | good | modifier.
        /// </summary>
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProductType? Type { get; set; }

        /// <summary>
        /// Enum: "Product" "Compound".
        /// Product or compound. Depends on modifiers scheme existence.
        /// </summary>
        [JsonProperty(PropertyName = "orderItemType", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderItemType OrderItemType { get; set; }

        /// <summary>
        /// Modifier schema's ID.
        /// </summary>
        [JsonProperty(PropertyName = "modifierSchemaId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ModifierSchemaId { get; set; }

        /// <summary>
        /// Modifier schema's name.
        /// </summary>
        [JsonProperty(PropertyName = "modifierSchemaName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? ModifierSchemaName { get; set; }

        /// <summary>
        /// Is product splittable.
        /// </summary>
        [JsonProperty(PropertyName = "splittable", Required = Required.Always)]
        public bool Splittable { get; set; }

        /// <summary>
        /// Item's unit of measurement.
        /// </summary>
        [JsonProperty(PropertyName = "measureUnit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? MeasureUnit { get; set; }

        /// <summary>
        /// Prices.
        /// </summary>
        [JsonProperty(PropertyName = "sizePrices", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<SizePrice>? SizePrices { get; set; }

        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Modifier>? Modifiers { get; set; }

        /// <summary>
        /// Modifier groups.
        /// </summary>
        [JsonProperty(PropertyName = "groupModifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<GroupModifier>? GroupModifiers { get; set; }

        /// <summary>
        /// Links to images.
        /// </summary>
        [JsonProperty(PropertyName = "imageLinks", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<string>? ImageLinks { get; set; }

        /// <summary>
        /// Do not print on bill.
        /// </summary>
        [JsonProperty(PropertyName = "doNotPrintInCheque", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool DoNotPrintInCheque { get; set; }

        /// <summary>
        /// External menu group.
        /// </summary>
        [JsonProperty(PropertyName = "parentGroup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? ParentGroup { get; set; }

        /// <summary>
        /// Product's order (priority) in menu.
        /// </summary>
        [JsonProperty(PropertyName = "order", Required = Required.Default,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Order { get; set; }

        /// <summary>
        /// Full name in a foreign language.
        /// </summary>
        [JsonProperty(PropertyName = "fullNameEnglish", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? FullNameEnglish { get; set; }

        /// <summary>
        /// Weighed product.
        /// </summary>
        [JsonProperty(PropertyName = "useBalanceForSell", Required = Required.Always)]
        public bool UseBalanceForSell { get; set; }

        /// <summary>
        /// Open price.
        /// </summary>
        [JsonProperty(PropertyName = "canSetOpenPrice", Required = Required.Always)]
        public bool CanSetOpenPrice { get; set; }

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
