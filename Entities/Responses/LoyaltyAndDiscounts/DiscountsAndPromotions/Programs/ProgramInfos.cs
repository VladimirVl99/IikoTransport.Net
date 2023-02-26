using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs
{
    /// <summary>
    /// Information about a programs.
    /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1program/post.
    /// </summary>
    [JsonObject]
    public class ProgramInfos
    {
        /// <summary>
        /// Programs.
        /// </summary>
        [JsonProperty(PropertyName = "responseType", Required = Required.Always)]
        public IEnumerable<LoyaltyProgram> Programs { get; set; } = default!;
    }
}
