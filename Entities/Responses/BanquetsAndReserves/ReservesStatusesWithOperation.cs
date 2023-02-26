using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Banquets/reserves statuses.
    /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1status_by_id/post.
    /// </summary>
    [JsonObject]
    public class ReservesStatusesWithOperation : OperationInfo
    {
        /// <summary>
        /// Banquets/reserves.
        /// </summary>
        [JsonProperty(PropertyName = "reserves", Required = Required.Always)]
        public IEnumerable<ReserveInfo> Reserves { get; set; } = default!;
    }
}
