using Newtonsoft.Json;
using SourceGuestDetails = IikoTransport.Net.Entities.Responses.Delivery.Drafts.GuestDetails;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers
{
    /// <summary>
    /// Guest details.
    /// </summary>
    [JsonObject]
    public class GuestDetails : SourceGuestDetails
    {
        public GuestDetails(int count, bool? splitBetweenPersons = null)
        {
            Count = count;
            SplitBetweenPersons = splitBetweenPersons;
        }
    }
}
