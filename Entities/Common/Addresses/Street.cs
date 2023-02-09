﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Common.Addresses
{
	/// <summary>
	/// Street.
	/// </summary>
	[JsonObject]
	public class Street
	{
		/// <summary>
		/// ID.
		/// </summary>
		[JsonProperty(PropertyName = "id", Required = Required.Always)]
		public Guid Id { get; set; }

		/// <summary>
		/// Name.
		/// </summary>
		[JsonProperty(PropertyName = "name", Required = Required.Always)]
		public string Name { get; set; } = default!;

		/// <summary>
		/// City.
		/// </summary>
		[JsonProperty(PropertyName = "city", Required = Required.Always)]
		public City City { get; set; } = default!;
	}
}