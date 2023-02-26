namespace IikoTransport.Net.Entities.Common.Deliveries
{
    /// <summary>
    /// Delivery status.
    /// </summary>
    public enum DeliveryStatus
    {
        Unconfirmed,
        WaitCooking,
        ReadyForCooking,
        CookingStarted,
        CookingCompleted,
        Waiting,
        OnWay,
        Delivered,
        Closed,
        Cancelled
    }
}
