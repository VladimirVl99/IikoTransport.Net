using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Customers
{
    /// <summary>
    /// Customer info.
    /// </summary>
    [JsonObject]
    public class Customer
    {
        /// <summary>
        /// Customer ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonProperty(PropertyName = "surname", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Surname { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Comment { get; set; }

        /// <summary>
        /// Enum: "NotSpecified" "Male" "Female".
        /// Sex.
        /// </summary>
        [JsonProperty(PropertyName = "gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Is client in blacklist.
        /// </summary>
        [JsonProperty(PropertyName = "inBlacklist", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? InBlacklist { get; set; }

        /// <summary>
        /// Reason why client was added to blacklist.
        /// </summary>
        [JsonProperty(PropertyName = "blacklistReason", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? BlacklistReason { get; set; }

        /// <summary>
        /// Date of birth.
        /// Allowed from version 7.6.1.
        /// </summary>
        [JsonProperty(PropertyName = "birthdate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Customer type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerType Type { get; set; }
    }
}
