using IikoTransport.Net.Entities.Common.Combos;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate
{
    public class Combo : ComboShort
    {
        /// <summary>
        /// Card program ID.
        /// Allowed from version 7.6.1.
        /// </summary>
        [JsonProperty(PropertyName = "programId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid ProgramId { get; set; }


        public Combo(Guid id, string name, int amount, double price, Guid sourceId, Guid programId)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
            SourceId = sourceId;
            ProgramId = programId;
        }
    }
}
