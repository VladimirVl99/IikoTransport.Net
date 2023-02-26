using Newtonsoft.Json;
using SourceDeliveryZoneHouse = IikoTransport.Net.Entities.Responses.Delivery.Restrictions.DeliveryZoneHouse;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Range of house numbers in the delivery zone.
    /// </summary>
    [JsonObject]
    public class DeliveryZoneHouse : SourceDeliveryZoneHouse
    {
        public DeliveryZoneHouse(int type, int startingNumber, int maxNumber,
            bool isUnlimitedRange, IEnumerable<string> specificNumbers)
        {
            Type = type;
            StartingNumber = startingNumber;
            MaxNumber = maxNumber;
            IsUnlimitedRange = isUnlimitedRange;
            SpecificNumbers = specificNumbers;
        }
    }
}
