using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.Customers
{
    /// <summary>
    /// Customer's user wallet. Contains bonus balances of different loyalty programs.
    /// </summary>
    [JsonObject]
    public class GuestBalanceInfo
    {
        /// <summary>
        /// Wallet id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Wallet name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Wallet type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public ProgramType Type { get; set; }

        /// <summary>
        /// Wallet balance.
        /// </summary>
        [JsonProperty(PropertyName = "balance", Required = Required.Always)]
        public double Balance { get; set; }
    }
}
