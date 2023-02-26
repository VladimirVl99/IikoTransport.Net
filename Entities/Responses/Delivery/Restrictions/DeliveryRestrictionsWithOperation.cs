using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Restrictions
{
    /// <summary>
    /// List of delivery restrictions.
    /// </summary>
    [JsonObject]
    public class DeliveryRestrictionsWithOperation : OperationInfo
    {
        /// <summary>
        /// Delivery restrictions.
        /// </summary>
        [JsonProperty(PropertyName = "deliveryRestrictions", Required = Required.Always)]
        public IEnumerable<DeliveryRestriction> DeliveryRestrictions { get; set; } = default!;
    }
}
