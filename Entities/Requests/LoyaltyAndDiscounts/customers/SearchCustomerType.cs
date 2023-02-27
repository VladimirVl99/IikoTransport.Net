using System.Runtime.Serialization;

namespace IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.Customers
{
    public enum SearchCustomerType
    {
        [EnumMember(Value = "id")]
        Id,
        [EnumMember(Value = "phone")]
        Phone,
        [EnumMember(Value = "cardTrack")]
        CardTrack,
        [EnumMember(Value = "cardNumber")]
        CardNumber,
        [EnumMember(Value = "email")]
        Email
    }
}
