using IikoTransport.Net.Entities.Requests.Orders.Payments;
using Newtonsoft.Json;
using SourcePaymentAdditional = IikoTransport.Net.Entities.Requests.Orders.Payments.PaymentAdditional;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments
{
    /// <summary>
    /// Additional payment parameters.
    /// </summary>
    [JsonObject]
    public class PaymentAdditional : SourcePaymentAdditional
    {
        public PaymentAdditional(string credential, SearchScope searchScope, PaymentAdditionalType type)
        {
            Credential = credential;
            SearchScope = searchScope;
            Type = type;
        }
    }
}
