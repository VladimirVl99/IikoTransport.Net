using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Dictionaries.TipsTypes
{
    /// <summary>
    /// Contains information about tips tipes for api-login`s rms group.
    /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1tips_types/post.
    /// </summary>
    [JsonObject]
    public class TipTypeInfo : OperationInfo
    {
        /// <summary>
        /// List of tips types for rms group.
        /// </summary>
        [JsonProperty(PropertyName = "tipsTypes", Required = Required.Always)]
        public IEnumerable<TipsType> TipsTypes { get; set; } = default!;
    }
}
