using IikoTransport.Net.Entities.Common.Date;
using IikoTransport.Net.Entities.Responses.Orders.Customers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Common.Customers
{
    /// <summary>
    /// Common information about a customer.
    /// </summary>
    [JsonObject]
    public class CustomerShort
    {
        /// <summary>
        /// Customer ID.
        /// </summary>
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual Guid? Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public virtual string Name { get; set; } = default!;

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonProperty(PropertyName = "surname", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string? Surname { get; set; }

        /// <summary>
        /// Comment.
        /// </summary>
        [JsonProperty(PropertyName = "comment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public virtual string? Comment { get; set; }

        /// <summary>
        /// Date of birth.
        /// Allowed from version 7.6.1.
        /// </summary>
        [JsonProperty(PropertyName = "birthdate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy-MM-dd HH:mm:ss.fff")]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Enum: "NotSpecified" "Male" "Female".
        /// Sex.
        /// </summary>
        [JsonProperty(PropertyName = "gender", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Customer type.
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerType Type { get; set; }
    }
}
