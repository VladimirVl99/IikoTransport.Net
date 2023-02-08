using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Payments
{
    /// <summary>
    /// Payment type classifier.
    /// </summary>
    public enum PaymentClassifier
    {
        Unknown,
        Cash,
        Card,
        Credit,
        Writeoff,
        Voucher,
        External,
        SmartSale,
        Sberbank,
        Trpos
    }
}
