using IikoTransport.Net.Entities.Requests.Orders.Payments;
using Newtonsoft.Json;
using SourceTips = IikoTransport.Net.Entities.Requests.Orders.Payments.Tips;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments
{
    /// <summary>
    /// Order tips component.
    /// </summary>
    [JsonObject]
    public class Tips : SourceTips
    {
        /// <summary>
        /// Additional payment parameters.
        /// </summary>
        [JsonProperty(PropertyName = "paymentAdditionalData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new PaymentAdditional? PaymentAdditionalData { get; set; }


        public Tips(TipsTypeKind paymentTypeKind, Guid tipsTypeId, double sum,
            Guid paymentTypeId, string? number = null, bool isProcessedExternally = false,
            PaymentAdditional? paymentAdditionalData = null, bool isFiscalizedExternally = false)
        {
            PaymentTypeKind = paymentTypeKind;
            TipsTypeId = tipsTypeId;
            Sum = sum;
            PaymentTypeId = paymentTypeId;
            Number = number;
            IsProcessedExternally = isProcessedExternally;
            PaymentAdditionalData = paymentAdditionalData;
            IsFiscalizedExternally = isFiscalizedExternally;
        }
    }
}
