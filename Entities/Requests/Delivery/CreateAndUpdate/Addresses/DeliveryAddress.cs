using IikoTransport.Net.Entities.Common.Addresses;
using Newtonsoft.Json;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses
{
    /// <summary>
    /// Order delivery address.
    /// </summary>
    [JsonObject]
    public class DeliveryAddress : DeliveryAddressShort
    {
        /// <summary>
        /// Street.
        /// </summary>
        [JsonProperty(PropertyName = "street", Required = Required.Always)]
        public new Street Street { get; set; } = default!;


        public DeliveryAddress(Street street, string house)
        {
            Street = street;
            House = house;
        }
    }
}
