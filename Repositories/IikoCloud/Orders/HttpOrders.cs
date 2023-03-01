using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Orders;
using IikoTransport.Net.Entities.Requests.Orders.CreateOrder;
using IikoTransport.Net.Entities.Requests.Orders.Customers;
using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Orders;
using OrderItemRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.OrderItem;
using ComboRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Combo;
using Newtonsoft.Json;
using IikoTransport.Net.Entities.Requests.Orders.Payments;
using PaymentRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Payment;
using TipsRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Tips;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;

namespace IikoTransport.Net.Repositories.IikoCloud.Orders
{
    public class HttpOrders : HttpHelper, IOrders
    {
        #region Fields

        private const string DefaultCreateOrderUri = "https://api-ru.iiko.services/api/1/order/create";
        private const string DefaultRetrieveOrdersByIdsUri = "https://api-ru.iiko.services/api/1/order/by_id";
        private const string DefaultRetrieveOrdersByTablesUri = "https://api-ru.iiko.services/api/1/order/by_table";
        private const string DefaultAddOrderItemsUri = "https://api-ru.iiko.services/api/1/order/add_items";
        private const string DefaultCloseOrderUri = "https://api-ru.iiko.services/api/1/order/close";
        private const string DefaultPaymentsOfTableOrderUri = "https://api-ru.iiko.services/api/1/order/change_payments";
        private const string DefaultInitByTableUri = "https://api-ru.iiko.services/api/1/order/init_by_table";
        private const string DefaultInitByPosOrderUri = "https://api-ru.iiko.services/api/1/order/init_by_posOrder";
        private const string DefaultAddCustomerToOrderUri = "https://api-ru.iiko.services/api/1/order/add_customer";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpOrders(string token) => Token = token;

        #endregion

        #region Methods

        #region Orders https://api-ru.iiko.services/#tag/Orders

        public async Task<OrderWithOperationInfo> CreateTableOrderAsync(Guid organizationId, Guid terminalGroupId,
            TableOrder? order = null, OrderCreationSettings? createOrderSettings = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                terminalGroupId,
                order,
                createOrderSettings
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCreateOrderUri, body, Token);

            return JsonConvert.DeserializeObject<OrderWithOperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OrdersWithOperationInfo> RetrieveTableOrdersByIdAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null, IEnumerable<string>? sourceKeys = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationIds,
                orderIds,
                posOrderIds,
                sourceKeys
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveOrdersByIdsUri, body, Token);

            return JsonConvert.DeserializeObject<OrdersWithOperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OrdersWithOperationInfo> RetrieveTableOrdersByTablesAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> tableIds, IEnumerable<OrderStatus>? statuses = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, IEnumerable<string>? sourceKeys = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationIds,
                tableIds,
                statuses = statuses?.ToTableOrderStatuses(),
                dateFrom = dateFrom?.ToCustomerDateFormat(),
                dateTo = dateTo?.ToCustomerDateFormat(),
                sourceKeys
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveOrdersByTablesUri, body, Token);

            return JsonConvert.DeserializeObject<OrdersWithOperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> AddTableOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItemRequest> items,
            IEnumerable<ComboRequest> combos)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                orderId,
                items,
                combos
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultAddOrderItemsUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> CloseTableOrderAsync(Guid organizationId, Guid orderId,
            ChequeAdditionalInfo? chequeAdditionalInfo = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                orderId,
                chequeAdditionalInfo
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCloseOrderUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> ChangePaymentsForTableOrderAsync(Guid organizationId, Guid orderId, IEnumerable<PaymentRequest> payments,
            IEnumerable<TipsRequest>? tips = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                orderId,
                payments,
                tips
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultPaymentsOfTableOrderUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> InitTableOrdersByTablesAsync(Guid organizationId, Guid terminalGroupId, IEnumerable<Guid> tableIds)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                terminalGroupId,
                tableIds
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultInitByTableUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> InitTableOrdersByPOSOrdersAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> posOrderIds)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                terminalGroupId,
                posOrderIds
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultInitByPosOrderUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OperationInfo> AddCustomerToTableOrderAsync(Guid organizationId, Guid orderId, Customer customer)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                orderId,
                customer
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultAddCustomerToOrderUri, body, Token);

            return JsonConvert.DeserializeObject<OperationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #endregion
    }
}
