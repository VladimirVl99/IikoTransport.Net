using IikoTransport.Net.Repositories.IikoTransport.BanquetsAndReserves;
using IikoTransport.Net.Repositories.IikoTransport.Delivery;
using IikoTransport.Net.Repositories.IikoTransport.General;
using IikoTransport.Net.Repositories.IikoTransport.LoyaltyAndDiscounts;
using IikoTransport.Net.Repositories.IikoTransport.Orders;
using IikoTransport.Net.Repositories.IikoTransport.Webhooks;

namespace IikoTransport.Net.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIikoTransport : IGeneral, IDelivery, IOrders, IReserves, IWebhooks, ILoyaltyAndDiscounts
    {

    }
}
