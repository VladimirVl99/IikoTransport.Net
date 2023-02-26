using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Orders
{
    /// <summary>
    /// Cheque additional information according to russian federal law #54.
    /// </summary>
    [JsonObject]
    public class ChequeAdditionalInfo : CommonChequeAdditionalInfo
    {
        public ChequeAdditionalInfo(bool needReceipt, string? email = null,
            string? settlementPlace = null, string? phone = null)
        {
            NeedReceipt = needReceipt;
            Email = email;
            SettlementPlace = settlementPlace;
            Phone = phone;
        }
    }
}
