namespace IikoTransport.Net.Entities.Responses.Webhooks
{
    /// <summary>
    /// WebHooks' events.
    /// </summary>
    public enum EventType
    {
        DeliveryOrderUpdate,
        DeliveryOrderError,
        ReserveUpdate,
        ReserveError,
        TableOrderUpdate,
        TableOrderError,
        StopListUpdate,
        PersonalShift
    }
}
