using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.Payments
{
    public enum PaymentTypeKind
    {
        Unknown,
        Cash,
        Card,
        Credit,
        Writeoff,
        Voucher,
        External,
        IikoCard
    }
}
