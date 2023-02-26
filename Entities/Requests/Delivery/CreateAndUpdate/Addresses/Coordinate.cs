using Newtonsoft.Json;
using SourceCoordinate = IikoTransport.Net.Entities.Common.Addresses.Coordinate;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses
{
    /// <summary>
    /// Delivery address coordinates.
    /// </summary>
    [JsonObject]
    public class Coordinate : SourceCoordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
