using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.Orders.CreateOrder;
using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.Orders;
using OrderItem = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.OrderItem;
using Combo = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Combo;
using IikoTransport.Net.Entities.Requests.Orders;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using Customer = IikoTransport.Net.Entities.Requests.Orders.Customers.Customer;

namespace IikoTransport.Net.Repositories.IikoCloud.Orders
{
    public interface IOrders
    {
        #region Orders https://api-ru.iiko.services/#tag/Orders

        /// <summary>
        /// Create order.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1create/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Front group ID an order must be sent to.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="order">Order.</param>
        /// <param name="createOrderSettings">Order creation parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderWithOperationInfo> CreateTableOrderAsync(Guid organizationId, Guid terminalGroupId,
            TableOrder? order = null, OrderCreationSettings? createOrderSettings = null,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Retrieve orders by IDs.
        /// Allowed from version 7.4.6.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1by_id/post.
        /// </summary>
        /// <param name="organizationIds">Organization IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderIds">Order IDs.
        /// Required if "posOrderIds" is null. Must be null if "posOrderIds" is not null.</param>
        /// <param name="posOrderIds">POS order IDs.
        /// Required if "orderIds" is null. Must be null if "orderIds" is not null.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrdersWithOperationInfo> RetrieveTableOrdersByIdAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null,
            IEnumerable<string>? sourceKeys = null, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Retrieve orders by tables.
        /// Allowed from version 7.4.6.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1by_table/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="tableIds">Table IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.</param>
        /// <param name="statuses">Order statuses.</param>
        /// <param name="dateFrom">Order creation date (terminal time zone). Lower limit.</param>
        /// <param name="dateTo">Order creation date (terminal time zone). Upper limit.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrdersWithOperationInfo> RetrieveTableOrdersByTablesAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> tableIds, IEnumerable<OrderStatus>? statuses = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, IEnumerable<string>? sourceKeys = null, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Add order items.
        /// Allowed from version 7.4.6.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1add_items/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="items">Order items (may include ProductOrderItem or CompoundOrderItem).</param>
        /// <param name="combos">Combos. Allowed from version 7.6.1.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> AddTableOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItem> items,
            IEnumerable<Combo> combos, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Close order.
        /// Allowed from version 7.4.6.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1close/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="chequeAdditionalInfo">Cheque additional information according to russian federal law #54.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> CloseTableOrderAsync(Guid organizationId, Guid orderId,
            ChequeAdditionalInfo? chequeAdditionalInfo = null, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Change table order's payments.
        /// Method will fail if there are any processed payments in the order.
        /// If all payments in the order are unprocessed they will be removed and replaced with new ones.
        /// Allowed from version 7.7.4.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1change_payments/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="payments">Order payments.</param>
        /// <param name="tips">Order tips.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangePaymentsForTableOrderAsync(Guid organizationId, Guid orderId,
            IEnumerable<Payment> payments, IEnumerable<Tips>? tips = null, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Init orders, created on POS, by tables.
        /// Allowed from version 7.7.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1init_by_table/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="tableIds">Table IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> InitTableOrdersByTablesAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> tableIds, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Init orders, created on POS, by POS orders.
        /// Allowed from version 7.7.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1init_by_posOrder/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="posOrderIds">POS order IDs.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> InitTableOrdersByPOSOrdersAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> posOrderIds, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Add customer to order.
        /// Allowed from version 7.7.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Orders/paths/~1api~11~1order~1add_customer/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="customer">Guest info.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> AddCustomerToTableOrderAsync(Guid organizationId, Guid orderId, Customer customer,
            CancellationToken? cancellationToken = default);

        #endregion
    }
}
