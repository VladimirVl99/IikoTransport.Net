using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.RemovalTypes
{
    /// <summary>
    /// Contains information about removal types (reasons for deletion).
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1removal_types/post.
    /// </summary>
    [JsonObject]
    public class RemovalTypeInfo : OperationInfo
    {
        /// <summary>
        /// List of removal types.
        /// </summary>
        [JsonProperty(PropertyName = "removalTypes", Required = Required.Always)]
        public IEnumerable<RemovalType> RemovalTypes { get; set; } = default!;
    }
}
