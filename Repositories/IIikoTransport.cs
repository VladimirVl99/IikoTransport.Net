using IikoTransport.Net.Repositories.IikoTransport.Delivery;
using IikoTransport.Net.Repositories.IikoTransport.General;
using IikoTransport.Net.Repositories.IikoTransport.Orders;

namespace IikoTransport.Net.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIikoTransport : IGeneral, IDelivery, IOrders
    {

    }
}
