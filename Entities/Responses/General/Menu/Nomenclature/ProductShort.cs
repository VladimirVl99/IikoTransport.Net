using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature
{
    /// <summary>
    /// Common information about a product.
    /// </summary>
    [JsonObject]
    public class ProductShort
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
    }
}
