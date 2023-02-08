﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders
{
    /// <summary>
    /// Order status.
    /// </summary>
    public enum Status
    {
        New,
        Bill,
        Closed,
        Deleted
    }
}