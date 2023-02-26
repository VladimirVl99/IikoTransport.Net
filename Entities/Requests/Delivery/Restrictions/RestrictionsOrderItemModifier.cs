using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Information about a restriction order modifier.
    /// </summary>
    [JsonObject]
    public class RestrictionsOrderItemModifier : RestrictionsOrderItemShort
    {
        public RestrictionsOrderItemModifier(Guid id, string product, double amount)
        {
            Id = id;
            Product = product;
            Amount = amount;
        }
    }
}
