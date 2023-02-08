using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Combo
{
    /// <summary>
    /// Contains information about combo's category.
    /// </summary>
    [JsonObject]
    public class ComboCategory
    {
        /// <summary>
        /// Category id.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Category name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;
    }
}
