using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Information about a section's font.
    /// </summary>
    [JsonObject]
    public class Font
    {
		/// <summary>
		/// Font family.
		/// </summary>
		[JsonProperty(PropertyName = "fontFamily", Required = Required.Always)]
		public string FontFamily { get; set; } = default!;

		/// <summary>
		/// Font size.
		/// </summary>
		[JsonProperty(PropertyName = "size", Required = Required.Always)]
		public float Size { get; set; }

		/// <summary>
		/// Font style. May be multiple values.
		/// </summary>
		[JsonProperty(PropertyName = "fontStyle", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public FontStyle FontStyle { get; set; }
	}
}
