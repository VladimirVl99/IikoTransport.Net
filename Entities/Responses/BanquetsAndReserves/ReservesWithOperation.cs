using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
	/// <summary>
	/// All banquets/reserves for passed restaurant sections.
	/// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1restaurant_sections_workload/post.
	/// </summary>
	[JsonObject]
	public class ReservesWithOperation : OperationInfo
	{
		/// <summary>
		/// Banquets/reserves.
		/// </summary>
		[JsonProperty(PropertyName = "reserves", Required = Required.Always)]
		public IEnumerable<ReserveInWorkload> Reserves { get; set; } = default!;
	}
}
