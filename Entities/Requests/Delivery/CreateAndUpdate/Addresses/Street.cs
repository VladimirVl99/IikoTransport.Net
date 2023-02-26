using Newtonsoft.Json;
using SourceStreet = IikoTransport.Net.Entities.Responses.Delivery.Drafts.Street;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses
{
    /// <summary>
    /// Information about a street.
    /// </summary>
    [JsonObject]
    public class Street : SourceStreet
    {
    }
}
