using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Restaurant section.
    /// </summary>
    [JsonObject]
    public class RestaurantSection
    {
        /// <summary>
        /// Restaurant section ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalGroupId", Required = Required.Always)]
        public Guid TerminalGroupId { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Tables.
        /// </summary>
        [JsonProperty(PropertyName = "tables", Required = Required.Always)]
        public IEnumerable<Table> Tables { get; set; } = default!;

        /// <summary>
        /// Table layout.
        /// </summary>
        [JsonProperty(PropertyName = "schema", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Schema? Schema { get; set; }
    }
}
