using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Orders.Nomenclature
{
    /// <summary>
    /// Information about a modifier from a order.
    /// </summary>
    [JsonObject]
    public class Modifier
    {
        /// <summary>
        /// Item.
        /// </summary>
        [JsonProperty(PropertyName = "product", Required = Required.Always)]
        public ProductShort Product { get; set; } = default!;

        /// <summary>
        /// Quantity.
        /// </summary>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }

        /// <summary>
        /// Whether quantity of modifier depends on quantity of item.
        /// </summary>
        [JsonProperty(PropertyName = "amountIndependentOfParentAmount", Required = Required.Always)]
        public bool AmountIndependentOfParentAmount { get; set; }

        /// <summary>
        /// Group of modifiers (in case of a group modifier).
        /// </summary>
        [JsonProperty(PropertyName = "productGroup", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ProductGroupShort? ProductGroup { get; set; }

        /// <summary>
        /// Price per item unit. Can be sent different from the price in RMS.
        /// </summary>
        [JsonProperty(PropertyName = "price", Required = Required.Always)]
        public double Price { get; set; }

        /// <summary>
        /// Whether price is predefined.
        /// </summary>
        [JsonProperty(PropertyName = "pricePredefined", Required = Required.Always)]
        public bool PricePredefined { get; set; }

        /// <summary>
        /// Total amount per item including tax, discounts/surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "resultSum", Required = Required.Always)]
        public double ResultSum { get; set; }

        /// <summary>
        /// Item deletion details. If specified, the item is deleted.
        /// </summary>
        [JsonProperty(PropertyName = "deleted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Deletion? Deleted { get; set; }

        /// <summary>
        /// Unique identifier of the item in the order and for the whole system.
        /// </summary>
        [JsonProperty(PropertyName = "positionId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Default amount.
        /// </summary>
        [JsonProperty(PropertyName = "defaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DefaultAmount { get; set; }

        /// <summary>
        /// Hide modifier in UI if "amount" equals "defaultAmount".
        /// </summary>
        [JsonProperty(PropertyName = "hideIfDefaultAmount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? HideIfDefaultAmount { get; set; }

        /// <summary>
        /// Tax rate.
        /// </summary>
        [JsonProperty(PropertyName = "taxPercent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? TaxPercent { get; set; }
    }
}
