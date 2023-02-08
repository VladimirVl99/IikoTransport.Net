using System.Runtime.Serialization;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    public enum CustomerType
    {
        [EnumMember(Value = "regular")]
        Regular,
        [EnumMember(Value = "one-time")]
        OneTime
    }
}
