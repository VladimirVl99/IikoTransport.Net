using Newtonsoft.Json;
using SourceOrderItemComponent = IikoTransport.Net.Entities.Requests.Orders.Nomenclature.OrderItemComponent;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature
{
    /// <summary>
    /// Information about an order item's component.
    /// </summary>
    [JsonObject]
    public class OrderItemComponent : SourceOrderItemComponent
    {
        /// <summary>
        /// Modifiers.
        /// </summary>
        [JsonProperty(PropertyName = "modifiers", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<Modifier>? Modifiers { get; set; }


        public OrderItemComponent(Guid productId, IEnumerable<Modifier>? modifiers = null,
            double? price = null, Guid? positionId = null)
        {
            ProductId = productId;
            Modifiers = modifiers;
            Price = price;
            PositionId = positionId;
        }
    }
}
