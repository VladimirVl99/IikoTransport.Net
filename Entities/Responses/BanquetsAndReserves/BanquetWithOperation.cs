using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
	/// <summary>
	/// Banquet/reserve.
	/// </summary>
	[JsonObject]
	public class BanquetWithOperation : OperationInfo
	{
		/// <summary>
		/// Banquet/reserve.
		/// </summary>
		[JsonProperty(PropertyName = "reserveInfo", Required = Required.Always)]
		public ReserveInfo ReserveInfo { get; set; } = default!;
	}
}
