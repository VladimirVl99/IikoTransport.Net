using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Delivery.DeliveryCreateAndUpdate
{
	/// <summary>
	/// Delivery status.
	/// </summary>
	public enum DeliveryStatus
	{
		Unconfirmed,
		WaitCooking,
		ReadyForCooking,
		CookingStarted,
		CookingCompleted,
		Waiting,
		OnWay,
		Delivered,
		Closed,
		Cancelled
	}
}
