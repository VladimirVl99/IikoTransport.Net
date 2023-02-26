using IikoTransport.Net.Entities.Common.Orders;
using Newtonsoft.Json;
using DeliveryPoint = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.DeliveryPoint;
using Customer = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers.Customer;
using GuestDetails = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers.GuestDetails;
using Payment = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Payment;
using Tips = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Tips;
using DiscountsInfo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties.DiscountsInfo;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate
{
    /// <summary>
    /// Information about a delivery order.
    /// </summary>
    [JsonObject]
    public class DeliveryOrder : OrderShort
    {
        public DeliveryOrder(string phone, IEnumerable<OrderItem> items, Guid? id = null, string? externalNumber = null,
            DateTime? completeBefore = null, Guid? orderTypeId = null, OrderServiceType? orderServiceType = null,
            DeliveryPoint? deliveryPoint = null, string? comment = null, Customer? customer = null,
            GuestDetails? guests = null, Guid? marketingSourceId = null, Guid? operatorId = null,
            IEnumerable<Combo>? combos = null, IEnumerable<Payment>? payments = null, IEnumerable<Tips>? tips = null,
            string? sourceKey = null, DiscountsInfo? discountsInfo = null, IikoCard5Info? iikoCard5Info = null)
        {
            Phone = phone;
            Items = items;
            Id = id;
            ExternalNumber = externalNumber;
            CompleteBefore = completeBefore;
            OrderTypeId = orderTypeId;
            OrderServiceType = orderServiceType;
            DeliveryPoint = deliveryPoint;
            Comment = comment;
            Customer = customer;
            Guests = guests;
            MarketingSourceId = marketingSourceId;
            OperatorId = operatorId;
            Combos = combos;
            Payments = payments;
            Tips = tips;
            SourceKey = sourceKey;
            DiscountsInfo = discountsInfo;
            IikoCard5Info = iikoCard5Info;
        }
    }
}
