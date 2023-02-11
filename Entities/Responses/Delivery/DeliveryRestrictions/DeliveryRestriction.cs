using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryRestrictions
{
	/// <summary>
	/// Information about delivery restriction.
	/// </summary>
	[JsonObject]
	public class DeliveryRestriction
	{
		/// <summary>
		/// Organization ID.
		/// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.
		/// </summary>
		[JsonProperty(PropertyName = "organizationId", Required = Required.Always)]
		public Guid OrganizationId { get; set; }

		/// <summary>
		/// Enum: 1 2 3 4.
		/// Geocoding service type.
		/// </summary>
		[JsonProperty(PropertyName = "deliveryGeocodeServiceType", Required = Required.Always)]
		public int DeliveryGeocodeServiceType { get; set; }

		/// <summary>
		/// Link to the map of delivery service regions.
		/// </summary>
		[JsonProperty(PropertyName = "deliveryRegionsMapUrl", Required = Required.AllowNull)]
		public string? DeliveryRegionsMapUrl { get; set; }

		/// <summary>
		/// General standard of delivery time.
		/// </summary>
		[JsonProperty(PropertyName = "defaultDeliveryDurationInMinutes", Required = Required.Always)]
		public long DefaultDeliveryDurationInMinutes { get; set; }

		/// <summary>
		/// Default pickup time.
		/// </summary>
		[JsonProperty(PropertyName = "defaultSelfServiceDurationInMinutes", Required = Required.Always)]
		public long DefaultSelfServiceDurationInMinutes { get; set; }

		/// <summary>
		/// Indication that all delivery points in all delivery zones use common delivery time limits.
		/// </summary>
		[JsonProperty(PropertyName = "useSameDeliveryDuration", Required = Required.Always)]
		public bool UseSameDeliveryDuration { get; set; }

		/// <summary>
		/// Indication that all delivery points for all delivery zones use the total minimum order amount.
		/// </summary>
		[JsonProperty(PropertyName = "useSameMinSum", Required = Required.Always)]
		public bool UseSameMinSum { get; set; }

		/// <summary>
		/// Total minimum order amount.
		/// </summary>
		[JsonProperty(PropertyName = "defaultMinSum", Required = Required.AllowNull)]
		public double? DefaultMinSum { get; set; }

		/// <summary>
		/// Indication that all delivery points in all zones use common time limits.
		/// </summary>
		[JsonProperty(PropertyName = "useSameWorkTimeInterval", Required = Required.Always)]
		public bool UseSameWorkTimeInterval { get; set; }

		/// <summary>
		/// The beginning of the interval of the total work time for all points and delivery zones,
		/// in minutes from the beginning of the day.
		/// </summary>
		[JsonProperty(PropertyName = "defaultFrom", Required = Required.AllowNull)]
		public int? DefaultFrom { get; set; }

		/// <summary>
		/// End of the total work time interval for all points and delivery zones,
		/// in minutes from the beginning of the day.
		/// </summary>
		[JsonProperty(PropertyName = "defaultTo", Required = Required.AllowNull)]
		public int? DefaultTo { get; set; }

		/// <summary>
		/// Indication that all delivery points in all zones use the same schedule for all days of the week.
		/// </summary>
		[JsonProperty(PropertyName = "useSameRestrictionsOnAllWeek", Required = Required.Always)]
		public bool UseSameRestictionsOnAllWeek { get; set; }

		/// <summary>
		/// Restrictions.
		/// </summary>
		[JsonProperty(PropertyName = "restrictions", Required = Required.Always)]
		public IEnumerable<DeliveryRestrictionItem> Restrictions { get; set; } = default!;

		/// <summary>
		/// Delivery zones.
		/// </summary>
		[JsonProperty(PropertyName = "deliveryZones", Required = Required.Always)]
		public IEnumerable<DeliveryZone> DeliveryZones { get; set; } = default!;

		/// <summary>
		/// Reject delivery if we could not geocode the address.
		/// </summary>
		[JsonProperty(PropertyName = "rejectOnGeocodingError", Required = Required.Always)]
		public bool RejectOnGeocodingError { get; set; }

		/// <summary>
		/// Add shipping cost to order.
		/// </summary>
		[JsonProperty(PropertyName = "addDeliveryServiceCost", Required = Required.Always)]
		public bool AddDeliveryServiceCost { get; set; }

		/// <summary>
		/// Indication that the cost is the same for all points of delivery.
		/// </summary>
		[JsonProperty(PropertyName = "useSameDeliveryServiceProduct", Required = Required.Always)]
		public bool UseSameDeliveryServiceProduct { get; set; }

		/// <summary>
		/// Link to "delivery service payment".
		/// </summary>
		[JsonProperty(PropertyName = "defaultDeliveryServiceProductId", Required = Required.AllowNull)]
		public Guid? DefaultDeliveryServiceProductId { get; set; }

		/// <summary>
		/// Use external delivery distribution service.
		/// </summary>
		[JsonProperty(PropertyName = "useExternalAssignationService", Required = Required.Always)]
		public bool UseExternalAssignationService { get; set; }

		/// <summary>
		/// Indication whether or not to trust on the fronts the call center mapping restrictions
		/// from the call center if the composition of the order has not changed since the last check.
		/// If true, then trust.
		/// </summary>
		[JsonProperty(PropertyName = "frontTrustsCallCenterCheck", Required = Required.Always)]
		public bool FrontTrustsCallCenterCheck { get; set; }

		/// <summary>
		/// Address of external delivery distribution service.
		/// </summary>
		[JsonProperty(PropertyName = "externalAssignationServiceUrl", Required = Required.AllowNull)]
		public string? ExternalAssignationServiceUrl { get; set; }

		/// <summary>
		/// Require an exact geocoding address.
		/// </summary>
		[JsonProperty(PropertyName = "requireExactAddressForGeocoding", Required = Required.Always)]
		public bool RequireExactAddressForGeocoding { get; set; }

		/// <summary>
		/// Enum: 0 1 2.
		/// Delivery restrictions mode.
		/// </summary>
		[JsonProperty(PropertyName = "zonesMode", Required = Required.Always)]
		public int ZonesMode { get; set; }

		/// <summary>
		/// Automatically assigned delivery method based on cartography.
		/// </summary>
		[JsonProperty(PropertyName = "autoAssignExternalDeliveries", Required = Required.Always)]
		public bool AutoAssignExteralDeliveries { get; set; }

		/// <summary>
		/// Enum: 1 2.
		/// Action on problems with auto-assignment.
		/// </summary>
		[JsonProperty(PropertyName = "actionOnValidationRejection", Required = Required.Always)]
		public int ActionOnValidationRejection { get; set; }
	}
}
