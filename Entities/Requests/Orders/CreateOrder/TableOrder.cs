using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Orders.Loyalties;
using DiscountsInfo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties.DiscountsInfo;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders.CreateOrder
{
    /// <summary>
    /// Information about a table order.
    /// </summary>
    [JsonObject]
    public class TableOrder : OrderShort
    {
        public TableOrder(IEnumerable<OrderItem> items, Guid? id = null, string? externalNumber = null,
            IEnumerable<Guid>? tableIds = null, Customer? customer = null, GuestDetails? guests = null,
            string? phone = null, string? tabName = null, IEnumerable<Combo>? combos = null,
            IEnumerable<Payment>? payments = null, IEnumerable<Tips>? tips = null, string? sourceKey = null,
            DiscountsInfo? discountsInfo = null, IikoCard5Info? iikoCard5Info = null, Guid? orderTypeId = null)
        {
            Items = items;
            Id = id;
            ExternalNumber = externalNumber;
            TableIds = tableIds;
            Customer = customer;
            Guests = guests;
            Phone = phone;
            TabName = tabName;
            Combos = combos;
            Payments = payments;
            Tips = tips;
            SourceKey = sourceKey;
            DiscountsInfo = discountsInfo;
            IikoCard5Info = iikoCard5Info;
            OrderTypeId = orderTypeId;
        }
    }
}

