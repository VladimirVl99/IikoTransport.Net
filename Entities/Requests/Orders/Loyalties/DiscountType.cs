using System.Runtime.Serialization;

namespace IikoTransport.Net.Entities.Requests.Orders.Loyalties
{
    /// <summary>
    /// Discount source type.
    /// </summary>
    public enum DiscountType
    {
        RMS,
        [EnumMember(Value = "iikoCard")]
        IikoCard
    }
}
