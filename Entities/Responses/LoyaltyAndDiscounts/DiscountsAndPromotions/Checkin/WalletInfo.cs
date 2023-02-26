using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin
{
    /// <summary>
    /// Information about a wallet.
    /// </summary>
    [JsonObject]
    public class WalletInfo
    {
        /// <summary>
        /// Wallet id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Max sum for payment from the wallet.
        /// </summary>
        [JsonProperty(PropertyName = "maxSum", Required = Required.Always)]
        public double MaxSum { get; set; }

        /// <summary>
        /// Can hold money.
        /// </summary>
        [JsonProperty(PropertyName = "canHoldMoney", Required = Required.Always)]
        public bool CanHoldMoney { get; set; }
    }
}
