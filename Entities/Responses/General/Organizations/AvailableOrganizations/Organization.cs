using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations
{
    [JsonObject]
    /// <summary>
    /// Contains all the information about the organization.
    /// Source: https://api-ru.iiko.services/#tag/Organizations/paths/~1api~11~1organizations/post.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Response type.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", Required = Required.Always)]
        public string? ResponseType { get; set; } = default!;

        /// <summary>
        /// Organization ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Organization name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.AllowNull)]
        public string? Name { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        [JsonProperty(PropertyName = "country", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Country { get; set; }

        /// <summary>
        /// Restaurant address.
        /// </summary>
        [JsonProperty(PropertyName = "restaurantAddress", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? RestaurantAddress { get; set; }

        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonProperty(PropertyName = "latitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        [JsonProperty(PropertyName = "longitude", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? Longitude { get; set; }

        /// <summary>
        /// Regional setting "Use the UAE Addressing System".
        /// </summary>
        [JsonProperty(PropertyName = "useUaeAddressingSystem", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? UseUaeAddressingSystem { get; set; }

        /// <summary>
        /// iikoRms version.
        /// </summary>
        [JsonProperty(PropertyName = "version", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Version { get; set; }

        /// <summary>
        /// ISO currency code (for example: RUB, USD, EUR).
        /// </summary>
        [JsonProperty(PropertyName = "currencyIsoName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CurrencyIsoName { get; set; }

        /// <summary>
        /// Value rounding of position.
        /// </summary>
        [JsonProperty(PropertyName = "currencyMinimumDenomination", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double? CurrencyMinimumDenomination { get; set; }

        /// <summary>
        /// Country dialing code.
        /// </summary>
        [JsonProperty(PropertyName = "countryPhoneCode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? CountryPhoneCode { get; set; }

        /// <summary>
        /// Require mandatory marketing source input when creating a delivery.
        /// </summary>
        [JsonProperty(PropertyName = "marketingSourceRequiredInDelivery", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? MarketingSourceRequiredInDelivery { get; set; }

        /// <summary>
        /// Default delivery city.
        /// </summary>
        [JsonProperty(PropertyName = "defaultDeliveryCityId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? DefaultDeliveryCityId { get; set; }

        /// <summary>
        /// Delivery cities.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryCityIds", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Guid>? DeliveryCityIds { get; set; }

        /// <summary>
        /// Enum: "CourierOnly", "SelfServiceOnly", "CourierAndSelfService".
        /// Delivery type.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryServiceType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryServiceType? DeliveryServiceType { get; set; }

        /// <summary>
        /// Default payment type for CallCenter.
        /// </summary>
        [JsonProperty(PropertyName = "defaultCallCenterPaymentTypeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? DefaultCallCenterPaymentTypeId { get; set; }

        /// <summary>
        /// Allow text comments for order items (in all restaurant sections).
        /// </summary>
        [JsonProperty(PropertyName = "orderItemCommentEnabled", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? OrderItemCommentEnabled { get; set; }

        /// <summary>
        /// Restaurant's INN (Taxpayer Identification Number).
        /// </summary>
        [JsonProperty(PropertyName = "inn", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Inn { get; set; }

        /// <summary>
        /// Enum: "Legacy", "City", "International", "IntNoPostcode".
        /// Address format type.
        /// </summary>
        [JsonProperty(PropertyName = "addressFormatType", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AddressFormatType? AddressFormatType { get; set; }

        /// <summary>
        /// Determine whether to use delivery confirmation.
        /// </summary>ы
        [JsonProperty(PropertyName = "isConfirmationEnabled", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsConfirmationEnabled { get; set; }

        /// <summary>
        /// Confirm orders time interval.
        /// </summary>
        [JsonProperty(PropertyName = "confirmAllowedIntervalInMinutes", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ConfirmAllowedIntervalInMinutes { get; set; }
    }
}
