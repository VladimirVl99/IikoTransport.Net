using IikoTransport.Net.Entities.Requests.Orders.Payments;
using Newtonsoft.Json;
using SourcePayment = IikoTransport.Net.Entities.Requests.Orders.Payments.Payment;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments
{
    /// <summary>
    /// Order payment component.
    /// </summary>
    [JsonObject]
    public class Payment : SourcePayment
    {
        /// <summary>
        /// Additional payment parameters.
        /// </summary>
        [JsonProperty(PropertyName = "paymentAdditionalData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new PaymentAdditional? PaymentAdditionalData { get; set; }


        public Payment(PaymentTypeKind paymentTypeKind, double sum, Guid paymentTypeId,
            string? number = null, bool isProcessedExternally = false,
            PaymentAdditional? paymentAdditionalData = null,
            bool isFiscalizedExternally = false)
        {
            PaymentTypeKind = paymentTypeKind;
            Sum = sum;
            PaymentTypeId = paymentTypeId;
            Number = number;
            IsProcessedExternally = isProcessedExternally;
            PaymentAdditionalData = paymentAdditionalData;
            IsFiscalizedExternally = isFiscalizedExternally;
        }
    }
}
