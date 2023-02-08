using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Authorizations
{
    /// <summary>
    /// Contains the session key for API user.
    /// </summary>
    [JsonObject]
    public class SessionKey : OperationInfo
    {
        /// <summary>
        /// Authentication token. The standard token lifetime is 1 hour.
        /// </summary>
        [JsonProperty(PropertyName = "token", Required = Required.Always)]
        public string Token { get; set; } = default!;
    }
}
