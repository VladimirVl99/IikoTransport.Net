using IikoTransport.Net.Repositories.IikoCloud.BanquetsAndReserves;
using IikoTransport.Net.Repositories.IikoCloud.Delivery;
using IikoTransport.Net.Repositories.IikoCloud.General;
using IikoTransport.Net.Repositories.IikoCloud.LoyaltyAndDiscounts;
using IikoTransport.Net.Repositories.IikoCloud.Orders;
using IikoTransport.Net.Repositories.IikoCloud.Webhooks;

namespace IikoTransport.Net.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIikoTransport : IGeneral, IDelivery, IOrders, IReserves, IWebhooks, ILoyaltyAndDiscounts
    {

    }
}
