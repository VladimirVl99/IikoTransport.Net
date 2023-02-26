using Newtonsoft.Json;
using SourceCard = IikoTransport.Net.Entities.Requests.Orders.Loyalties.Card;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties
{
    /// <summary>
    /// Track of discount card to be applied to order.
    /// </summary>
    [JsonObject]
    public class Card : SourceCard
    {
        public Card(string track)
        {
            Track = track;
        }
    }
}
