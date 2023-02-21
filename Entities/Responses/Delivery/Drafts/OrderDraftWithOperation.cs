using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.Delivery.Drafts
{
    /// <summary>
    /// Information about an order draft.
    /// </summary>
    [JsonObject]
    public class OrderDraftWithOperation : OperationInfo
    {
        /// <summary>
        /// Order draft object.
        /// </summary>
        [JsonProperty(PropertyName = "order", Required = Required.AllowNull)]
        public Order? Order { get; set; }

        /// <summary>
        /// ID of the employee who is currently editing this draft.
        /// </summary>
        [JsonProperty(PropertyName = "lockedByUser", Required = Required.AllowNull)]
        public Guid? LockedByUser { get; set; }
    }
}
