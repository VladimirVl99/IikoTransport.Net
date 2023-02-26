using Newtonsoft.Json;
using SourceModifier = IikoTransport.Net.Entities.Requests.Orders.Nomenclature.Modifier;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature
{
    /// <summary>
    /// Information about a modifier.
    /// </summary>
    [JsonObject]
    public class Modifier : SourceModifier
    {
        public  Modifier(Guid productId, double amount, Guid? productGroupId = null,
            double? price = null, Guid? positionId = null)
        {
            ProductId = productId;
            Amount = amount;
            ProductGroupId = productGroupId;
            Price = price;
            PositionId = positionId;
        }
    }
}
