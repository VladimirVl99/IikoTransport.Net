using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Delivery.Retrieve;
using IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve;
using IikoTransport.Net.Entities.Responses.General.Operations;
using DeliveryOrder = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryOrder;
using DeliveryPoint = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.DeliveryPoint;
using OrderServiceType = IikoTransport.Net.Entities.Common.Orders.OrderServiceType;
using DeliveryStatusShort = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryStatus;
using DeliveryStatus = IikoTransport.Net.Entities.Common.Deliveries.DeliveryStatus;
using IikoTransport.Net.Entities.Common.Addresses.Regions;
using IikoTransport.Net.Entities.Common.Addresses.Cities;
using IikoTransport.Net.Entities.Common.Addresses.Streets;

namespace IikoTransport.Net.Repositories.IikoTransport.Delivery
{
    /// <summary>
    /// Delivery's methods of iikoTransport.
    /// </summary>
    public interface IDelivery
    {
        #region Deliveries: Create and update https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update

        /// <summary>
        /// Create delivery.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1create/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="order">Order.</param>
        /// <param name="terminalGroupId">Front group ID an order must be sent to.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="createOrderSettings">Order creation parameters.</param>
        /// <returns></returns>
        Task<OrderWithOperationInfo> CreateDeliveryAsync(Guid organizationId, DeliveryOrder order,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null);

        /// <summary>
        /// Update order problem.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1update_order_problem/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="hasProblem">Problem flag.</param>
        /// <param name="problem">[ 0 .. 1000 ] characters. Problem text.</param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryOrderProblemAsync(Guid organizationId, Guid orderId, bool hasProblem,
            string? problem = null);

        /// <summary>
        /// Update delivery status.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1update_order_delivery_status/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="deliveryStatus">Delivery status. Can be only switched between these three statuses.</param>
        /// <param name="deliveryDate">The date and time when the order was received by
        /// the guest (Local for delivery terminal).</param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryStatusAsync(Guid organizationId, Guid orderId, DeliveryStatusShort deliveryStatus,
            DateTime? deliveryDate = null);

        /// <summary>
        /// Update order courier.
        /// Allowed from version 7.1.5.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1update_order_courier/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="employeeId">Courier ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/employees/couriers operation.</param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryOrderCourierAsync(Guid organizationId, Guid orderId, Guid employeeId);

        /// <summary>
        /// Add order items.
        /// Allowed from version 7.4.6.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1add_items/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="items">Order items (may include ProductOrderItem or CompoundOrderItem).</param>
        /// <param name="combos">Combos. Allowed from version 7.6.1.</param>
        /// <returns></returns>
        Task<OperationInfo> AddDeliveryOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItem> items,
            IEnumerable<Combo>? combos = null);

        /// <summary>
        /// Close order.
        /// Before version 8.0.6 it's possible to close deliveries with DeliveryByClient orderServiceType only,
        /// starting from version 8.0.6 it's also possible to close DeliveryByCourier deiveries in the DeliveryStatus OnWay or Delivered.
        /// Allowed from version 7.4.6.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1close/post.
        /// </summary>
        /// <param name="deliveryDate">Actual delivery time. If empty local iikoFront time will used.
        /// Allowed from version 8.0.6.</param>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <returns></returns>
        Task<OperationInfo> CloseDeliveryOrderAsync(Guid organizationId, Guid orderId, DateTime? deliveryDate = null);

        /// <summary>
        /// Cancel delivery order.
        /// Allowed from version 7.5.4.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1cancel/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="movedOrderId">Fill this field with id of the new order if current order
        /// has been moved to the new RMS/terminal group.</param>
        /// <param name="cancelCauseId">Cancel order dictionary item id. Allowed from version 7.7.1.</param>
        /// <param name="removalTypeId">Removal type (for delete printed order items). Allowed from version 7.7.1.</param>
        /// <param name="userIdForWriteoff">User for writeoff (for delete printed order items).
        /// Allowed from version 7.7.1.</param>
        /// <returns></returns>
        Task<OperationInfo> CancelDeliveryOrderAsync(Guid organizationId, Guid orderId, Guid? movedOrderId = null,
            Guid? cancelCauseId = null, Guid? removalTypeId = null, Guid? userIdForWriteoff = null);

        /// <summary>
        /// Change time when client wants the order to be delivered.
        /// Allowed from version 7.5.4.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_complete_before/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="newCompleteBefore">New time when client wants the order to be delivered (Local for delivery terminal).</param>
        /// <returns></returns>
        Task<OperationInfo> ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(Guid organizationId, Guid orderId,
            DateTime newCompleteBefore);

        /// <summary>
        /// Change order's delivery point information.
        /// Allowed from version 7.5.4.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_delivery_point/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="newDeliveryPoint">New address of delivery.</param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryPointForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            DeliveryPoint newDeliveryPoint);

        /// <summary>
        /// Change order's delivery type.
        /// Allowed from version 7.5.4.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_service_type/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="newServiceType">Service type of a delivery order.</param>
        /// <param name="deliveryPoint">Address of delivery. Required if newServiceType is 'DeliveryByCourier'.</param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryTypeForOrderAsync(Guid organizationId, Guid orderId, OrderServiceType newServiceType,
            DeliveryPoint? deliveryPoint = null);

        /// <summary>
        /// Change order's payments.
        /// Method will fail if there are any processed payments in the order.
        /// If all payments in the order are unprocessed they will be removed and replaced with new ones.
        /// Allowed from version 7.6.3.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_payments/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="payments">Order payments.</param>
        /// <param name="tips">Order tips.</param>
        /// <returns></returns>
        Task<OperationInfo> ChangePaymentForDeliveryOrderAsync(Guid organizationId, Guid orderId, IEnumerable<Payment> payments,
            IEnumerable<Tips>? tips = null);

        /// <summary>
        /// Change delivery comment.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_comment/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="comment">New comment.</param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryCommentAsync(Guid organizationId, Guid orderId, string comment);

        /// <summary>
        /// Print delivery bill.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1print_delivery_bill/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <returns></returns>
        Task<OperationInfo> PrintDeliveryBillAsync(Guid organizationId, Guid orderId);

        /// <summary>
        /// Confirm delivery.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1confirm/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <returns></returns>
        Task<OperationInfo> ConfirmDeliveryAsync(Guid organizationId, Guid orderId);

        /// <summary>
        /// Cancel delivery confirmation.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1cancel_confirmation/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <returns></returns>
        Task<OperationInfo> CancelDeliveryConfirmationAsync(Guid organizationId, Guid orderId);

        /// <summary>
        /// Assign/change the order operator.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1change_operator/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="operatorId">Operator to assign the order to.</param>
        /// <returns></returns>
        Task<OperationInfo> AssignOrChangeDeliveryOrderOperatorAsync(Guid organizationId, Guid orderId,
            Guid operatorId);

        #endregion

        #region Deliveries: Retrieve https://api-ru.iiko.services/#tag/Deliveries:-Retrieve

        /// <summary>
        /// Retrieve orders by IDs.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_id/post.
        /// </summary>
        /// <param name="organizationId">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderIds">IDs of orders information on which is required.
        /// Required if "posOrderIds" is null. Must be null if "posOrderIds" is not null.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="posOrderIds">POS order IDs information on which is required.
        /// Required if "orderIds" is null. Must be null if "orderIds" is not null.</param>
        /// <returns></returns>
        Task<OrderInfoWithOperation> RetrieveDeliveryOrdersByIdsAsync(Guid organizationId,
            IEnumerable<Guid>? orderIds = null, IEnumerable<string>? sourceKeys = null,
            IEnumerable<Guid>? posOrderIds = null);

        /// <summary>
        /// Retrieve list of orders by statuses and dates.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_delivery_date_and_status/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="deliveryDateFrom">Order delivery date (Local for delivery terminal). Lower limit.</param>
        /// <param name="deliveryDateTo">Order delivery date (Local for delivery terminal). Upper limit.</param>
        /// <param name="statuses">Allowed order statuses.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByStatusesAndDatesAsync(
            IEnumerable<Guid> organizationIds, DateTime deliveryDateFrom, DateTime? deliveryDateTo = null,
            IEnumerable<DeliveryStatusShort>? statuses = null, IEnumerable<string>? sourceKeys = null);

        /// <summary>
        /// Retrieve list of orders changed from the time revision was passed.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_revision/post.
        /// </summary>
        /// <param name="startRevision">Revision start number beginning from which (but not including)
        /// new/edited orders will be returned.</param>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(long startRevision,
            IEnumerable<Guid> organizationIds, IEnumerable<string>? sourceKeys = null);

        /// <summary>
        /// Retrieve list of orders by telephone number, dates and revision.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_delivery_date_and_phone/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="phone">Delivery order phone number.</param>
        /// <param name="deliveryDateFrom">Order delivery date (Local for delivery terminal). Lower limit.</param>
        /// <param name="deliveryDateTo">Order delivery date (Local for delivery terminal). Upper limit.</param>
        /// <param name="startRevision">Revision start number beginning from which (but not including)
        /// new/edited orders will be returned.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="rowsCount">Maximum number of items returned. If null, all items will be returned.</param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(
            IEnumerable<Guid> organizationIds, string? phone = null, DateTime? deliveryDateFrom = null,
            DateTime? deliveryDateTo = null, long? startRevision = null, IEnumerable<string>? sourceKeys = null,
            int? rowsCount = null);

        /// <summary>
        /// Search orders by search text and additional filters (date, problem, statuses and other).
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_delivery_date_and_source_key_and_filter/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="sortProperty">Sorting property.</param>
        /// <param name="sortDirection">Sorting direction.</param>
        /// <param name="terminalGroupIds">List of terminal groups IDs.</param>
        /// <param name="deliveryDateFrom">Order delivery date (Local for delivery terminal). Lower limit.</param>
        /// <param name="deliveryDateTo">Order delivery date (Local for delivery terminal). Upper limit.</param>
        /// <param name="statuses">Allowed order statuses.</param>
        /// <param name="hasProblem">If true, delivery has a problem.</param>
        /// <param name="orderServiceType">Order service type.</param>
        /// <param name="searchText">Value for search. Used for prefix search.</param>
        /// <param name="timeToCookingErrorTimeout">Error timeout for status time to cooking, in seconds.</param>
        /// <param name="cookingTimeout">Expected cooking time, in seconds.</param>
        /// <param name="rowsCount">Maximum number of items returned.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="orderIds">Order IDs.</param>
        /// <param name="posOrderIds">POS order IDs. Must be null if "orderIds" is not null.</param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByAdditionalFiltersAsync(IEnumerable<Guid> organizationIds,
            SortProperty sortProperty, SortDirection sortDirection, IEnumerable<Guid>? terminalGroupIds = null,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, IEnumerable<DeliveryStatus>? statuses = null,
            bool? hasProblem = null, OrderServiceType? orderServiceType = null, string? searchText = null,
            int? timeToCookingErrorTimeout = null, int? cookingTimeout = null, int? rowsCount = null,
            IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null);

        #endregion

        #region Addresses https://api-ru.iiko.services/#tag/Addresses

        /// <summary>
        /// Regions.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1regions/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<RegionWithOperation> RetrieveRegionsAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Cities.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1cities/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<CitiesWithOperation> RetrieveCitiesAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Streets by city.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1streets~1by_city/post.
        /// </summary>
        /// <param name="organizationId">Organization ID details of which have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cityId">City ID.</param>
        /// <returns></returns>
        Task<StreetsWithOperation> RetrieveStreetsByCity(Guid organizationId, Guid cityId);

        #endregion

        #region Delivery restrictions https://api-ru.iiko.services/#tag/Delivery-restrictions



        #endregion
    }
}
