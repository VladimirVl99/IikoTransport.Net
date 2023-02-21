using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.BanquetsAndReserves
{
    /// <summary>
    /// Information about a table.
    /// </summary>
    [JsonObject]
    public class Table
    {
        /// <summary>
        /// Table ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public Guid Id { get; set; }

        /// <summary>
        /// Number of table.
        /// </summary>
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public int Number { get; set; }

        /// <summary>
        /// Table name specified in the organization settings.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Seating capacity of the table.
        /// </summary>
        [JsonProperty(PropertyName = "seatingCapacity", Required = Required.Always)]
        public int SeatingCapacity { get; set; }

        /// <summary>
        /// Last modified time.
        /// </summary>
        [JsonProperty(PropertyName = "revision", Required = Required.Always)]
        public long Revision { get; set; }

        /// <summary>
        /// Is table deleted.
        /// </summary>
        [JsonProperty(PropertyName = "isDeleted", Required = Required.Always)]
        public bool IsDeleted { get; set; }
    }
}
