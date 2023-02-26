namespace IikoTransport.Net.Entities.Responses.Webhooks.Orders
{
    public enum OrderStatus
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
        Cancelled,
        New,
        Bill,
        Deleted
    }
}
