using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Marketing campaigns with available payment.
    /// </summary>
    [JsonObject]
    public class AvailablePayment
    {
        /// <summary>
        /// Marketing campaign id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Max sum.
        /// </summary>
        [JsonProperty(PropertyName = "maxSum", Required = Required.Always)]
        public double MaxSum { get; set; }

        /// <summary>
        /// Payment order. In case of partial payment,
        /// payments with lesser order should be filled first.
        /// </summary>
        [JsonProperty(PropertyName = "order", Required = Required.Always)]
        public int Order { get; set; }

        /// <summary>
        /// Wallet infos.
        /// </summary>
        [JsonProperty(PropertyName = "walletInfos", Required = Required.Always)]
        public IEnumerable<WalletInfo> WalletInfos { get; set; } = default!;
    }
}
