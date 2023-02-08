using IikoTransport.Net.Entities.Responses.General.Operations;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Responses.General.Employees
{
    /// <summary>
    /// Employee info.
    /// </summary>
    [JsonObject]
    public class EmployeeInfo : OperationInfo
    {
        /// <summary>
        /// Employee info.
        /// </summary>
        [JsonProperty(PropertyName = "employeeInfo", Required = Required.Always)]
        public Employee Employee { get; set; } = default!;
    }
}
