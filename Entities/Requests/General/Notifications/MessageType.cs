using System.Runtime.Serialization;

namespace IikoTransport.Net.Entities.Requests.General.Notifications
{
    public enum MessageType
    {
        [EnumMember(Value = "order_attention")]
        OrderAttention
    }
}
