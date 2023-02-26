using Newtonsoft.Json;
using SourceDeliveryRestrictionItem
    = IikoTransport.Net.Entities.Responses.Delivery.Restrictions.DeliveryRestrictionItem;

namespace IikoTransport.Net.Entities.Requests.Delivery.Restrictions
{
    /// <summary>
    /// Delivery restriction.
    /// </summary>
    [JsonObject]
    public class DeliveryRestrictionItem : SourceDeliveryRestrictionItem
    {
        public DeliveryRestrictionItem(int weekMap, int priority, long deliveryDurationInMinutes,
            double? minSum = null, Guid? terminalGroupId = null, Guid? organizationId = null,
            string? zone = null, int? from = null, int? to = null,
            Guid? deliveryServiceProductId = null)
        {
            WeekMap = weekMap;
            Priority = priority;
            DeliveryDurationInMinutes = deliveryDurationInMinutes;
            MinSum = minSum;
            TerminalGroupId = terminalGroupId;
            OrganizationId = organizationId;
            Zone = zone;
            From = from;
            To = to;
            DeliveryServiceProductId = deliveryServiceProductId;
        }
    }
}
