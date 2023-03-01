using SimpleDeliveryStatus = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryStatus;
using DeliveryStatus = IikoTransport.Net.Entities.Common.Deliveries.DeliveryStatus;
using TableOrderStatus = IikoTransport.Net.Entities.Common.Orders.OrderStatus;
using IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.Customers;

namespace IikoTransport.Net.Repositories
{
    public static class Extensions
    {
        private const string DefaultCustomDateFormat = "yyyy-MM-dd HH:mm:ss.fff";


        public static IEnumerable<string> ToSimpleDeliveryStatuses(this IEnumerable<SimpleDeliveryStatus> statuses)
        {
            var list = new List<string>();

            foreach (var status in statuses)
            {
                list.Add(status.ToString());
            }

            return list;
        }

        public static IEnumerable<string> ToDeliveryStatuses(this IEnumerable<DeliveryStatus> statuses)
        {
            var list = new List<string>();

            foreach (var status in statuses)
            {
                list.Add(status.ToString());
            }

            return list;
        }

        public static IEnumerable<string> ToTableOrderStatuses(this IEnumerable<TableOrderStatus> statuses)
        {
            var list = new List<string>();

            foreach (var status in statuses)
            {
                list.Add(status.ToString());
            }

            return list;
        }

        public static string ToCustomerDateFormat(this DateTime dateTime)
            => dateTime.ToString(DefaultCustomDateFormat);

        public static string ToSearchCustomerType(this SearchCustomerType type)
            => type switch
            {
                SearchCustomerType.Phone => "phone",
                SearchCustomerType.CardTrack => "cardTrack",
                SearchCustomerType.CardNumber => "cardNumber",
                SearchCustomerType.Email => "email",
                SearchCustomerType.Id => "id",
                _ => throw new Exception($"Fail to convert '{typeof(SearchCustomerType).FullName}' enum to string.")
            };
    }
}
