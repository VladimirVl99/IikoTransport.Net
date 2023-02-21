using System.Runtime.Serialization;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    /// <summary>
    /// 'Regular' customer:
    /// - can be used only if a customer agrees to take part in the store's loyalty programs
    /// - customer details will be added (updated) to the store's customer database
    /// - benefits (accumulation of rewards, etc.) of active loyalty programs will
    /// be made available to the customer
    /// 'One-time' customer:
    /// - should be used if a customer does not agree to take part in the store's
    /// loyalty programs or an aggregator (external system) does not provide customer details
    /// - customer details will NOT be added to the store's customer database and
    /// will be used ONLY to complete the current order
    /// </summary>
    public enum CustomerType
    {
        [EnumMember(Value = "regular")]
        Regular,
        [EnumMember(Value = "one-time")]
        OneTime
    }
}
