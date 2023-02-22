using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Information about a color.
    /// </summary>
    [JsonObject]
    public class Color
    {
		/// <summary>
		/// Alpha-component.
		/// </summary>
		[JsonProperty(PropertyName = "a", Required = Required.Always)]
		public int A { get; set; }

		/// <summary>
		/// Red-component.
		/// </summary>
		[JsonProperty(PropertyName = "r", Required = Required.Always)]
		public int R { get; set; }

		/// <summary>
		/// Green-component.
		/// </summary>
		[JsonProperty(PropertyName = "g", Required = Required.Always)]
		public int G { get; set; }

		/// <summary>
		/// Blue-component.
		/// </summary>
		[JsonProperty(PropertyName = "b", Required = Required.Always)]
		public int B { get; set; }
    }
}
