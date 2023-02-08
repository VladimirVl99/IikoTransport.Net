using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.DiscountsAndSurcharges
{
    /// <summary>
    /// Contains information about discount of the organization.
    /// </summary>
    [JsonObject]
    public class DiscountCardTypeInfo
    {
        /// <summary>
        /// Discount ID in RMS.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Discount name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public string? Name { get; set; }

        /// <summary>
        /// Total discount rate.
        /// Ignored if "isCategorisedDiscount" specified.
        /// </summary>
        [JsonProperty(PropertyName = "percent", Required = Required.AllowNull)]
        public double? Percent { get; set; }

        /// <summary>
        /// Whether it is category discount or not.
        /// If true, "productCategoryDiscounts" discounts will apply.
        /// </summary>
        [JsonProperty(PropertyName = "isCategorisedDiscount", Required = Required.Always)]
        public bool IsCategorisedDiscount { get; set; }

        /// <summary>
        /// Category discount.
        /// </summary>
        [JsonProperty(PropertyName = "productCategoryDiscounts", Required = Required.AllowNull,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ProductCategoryDiscount>? ProductCategoryDiscounts { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Whether discount allows for selected application to individual items at user's discretion.
        /// </summary>
        [JsonProperty(PropertyName = "canBeAppliedSelectively", Required = Required.Always)]
        public bool CanBeAppliedSelectively { get; set; }

        /// <summary>
        /// Minimum order amount required for discount application. If order amount is less
        /// than specified threshold, discount does not apply.
        /// </summary>
        [JsonProperty(PropertyName = "minOrderSum", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? MinOrderSum { get; set; }

        /// <summary>
        /// Enum: "Percent" "FlexibleSum" "FixedSum".
        /// Discount type.
        /// Can be obtained by https://api-ru.iiko.services/api/1/discounts operation.
        /// </summary>
        [JsonProperty(PropertyName = "mode", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DiscountType Mode { get; set; }

        /// <summary>
        /// Fixed amount.
        /// Triggers if fixed amount has been specified.
        /// </summary>
        [JsonProperty(PropertyName = "sum", Required = Required.Always)]
        public double Sum { get; set; }

        /// <summary>
        /// Can be applied by card No.
        /// If true, it's enough to enter discount card No. (card swiping not required)
        /// </summary>
        [JsonProperty(PropertyName = "canApplyByCardNumber", Required = Required.Always)]
        public bool CanApplyByCardNumber { get; set; }

        /// <summary>
        /// Created manually.
        /// </summary>
        [JsonProperty(PropertyName = "isManual", Required = Required.Always)]
        public bool IsManual { get; set; }

        /// <summary>
        /// Executed by card.
        /// </summary>
        [JsonProperty(PropertyName = "isCard", Required = Required.Always)]
        public bool IsCard { get; set; }

        /// <summary>
        /// Created automatically.
        /// </summary>
        [JsonProperty(PropertyName = "isAutomatic", Required = Required.Always)]
        public bool IsAutomatic { get; set; }

        /// <summary>
        /// IsDeleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
    }
}
