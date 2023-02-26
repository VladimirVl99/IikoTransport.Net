using Newtonsoft.Json;
using SourceComboInfo = IikoTransport.Net.Entities.Requests.Orders.Nomenclature.ComboInfo;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Nomenclature
{
    /// <summary>
    /// Combo details if combo includes order item.
    /// </summary>
    [JsonObject]
    public class ComboInfo : SourceComboInfo
    {
        public ComboInfo(Guid comboId, Guid comboSourceId, Guid comboGroupId)
        {
            ComboId = comboId;
            ComboSourceId = comboSourceId;
            ComboGroupId = comboGroupId;
        }
    }
}
