using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryCreateAndUpdate
{
	/// <summary>
	/// Delivery cancellation details.
	/// </summary>
	[JsonObject]
	public class CancelInfo
	{
		/// <summary>
		/// Cancellation time (Local for delivery terminal).
		/// </summary>
		[JsonProperty(PropertyName = "whenCancelled", Required = Required.Always)]
		public DateTime WhenCancelled { get; set; }

		/// <summary>
		/// Delivery cancellation reason.
		/// </summary>
		[JsonProperty(PropertyName = "cause", Required = Required.Always)]
		public CancellationReason Cause { get; set; } = default!;

		/// <summary>
		/// Delivery cancellation comment.
		/// </summary>
		[JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string? Comment { get; set; }
	}
}
