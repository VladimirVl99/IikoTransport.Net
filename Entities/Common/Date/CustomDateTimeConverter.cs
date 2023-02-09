using Newtonsoft.Json.Converters;

namespace IikoTransport.Net.Entities.Common.Date
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
