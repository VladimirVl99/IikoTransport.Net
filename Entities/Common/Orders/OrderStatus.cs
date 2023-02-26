using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Common.Orders
{
    /// <summary>
    /// Order status.
    /// </summary>
    public enum OrderStatus
    {
        New,
        Bill,
        Closed,
        Deleted
    }
}
