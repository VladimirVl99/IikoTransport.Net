using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.Orders.Nomenclature
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class Size : SizeShort
    {
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public override string Name
        {
            get => base.Name!;
#pragma warning disable CS8765
            set => base.Name = value;
#pragma warning restore CS8765
        }
    }
}
