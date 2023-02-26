namespace IikoTransport.Net.Entities.Responses.Delivery.Restrictions.AllowedRestirctions
{
    /// <summary>
    /// Reject cause code.
    /// </summary>
    public enum RejectCode
    {
        Undefined,
        SumIsLessThenMinimum,
        DayOfWeekIsUnacceptable,
        DeliveryTimeIsUnacceptable,
        OutOfTerminalZone
    }
}
