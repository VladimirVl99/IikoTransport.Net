namespace IikoTransport.Net.Entities.Requests.Orders.Payments
{
    /// <summary>
    /// Guest credential search scope.
    /// </summary>
    public enum SearchScope
    {
        Reserved,
        Phone,
        CardNumber,
        CardTrack,
        PaymentToken,
        FindFaceId
    }
}
