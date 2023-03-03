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
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions;
using DeliveryRestrictionItem = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryRestrictionItem;
using DeliveryZone = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryZone;
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions.AllowedRestirctions;
using IikoTransport.Net.Entities.Requests.Delivery.Restrictions;
using Coordinate = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.Coordinate;
using IikoTransport.Net.Entities.Responses.Delivery.MarketingSources;
using IikoTransport.Net.Entities.Responses.Delivery.Drafts;
using DeliveryAddress = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryAddress;

namespace IikoTransport.Net.Repositories.IikoCloud.Delivery
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderWithOperationInfo> CreateDeliveryAsync(Guid organizationId, DeliveryOrder order,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null,
            CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryOrderProblemAsync(Guid organizationId, Guid orderId, bool hasProblem,
            string? problem = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryStatusAsync(Guid organizationId, Guid orderId, DeliveryStatusShort deliveryStatus,
            DateTime? deliveryDate = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryOrderCourierAsync(Guid organizationId, Guid orderId, Guid employeeId,
            CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> AddDeliveryOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItem> items,
            IEnumerable<Combo>? combos = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> CloseDeliveryOrderAsync(Guid organizationId, Guid orderId, DateTime? deliveryDate = null,
            CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> CancelDeliveryOrderAsync(Guid organizationId, Guid orderId, Guid? movedOrderId = null,
            Guid? cancelCauseId = null, Guid? removalTypeId = null, Guid? userIdForWriteoff = null,
            CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(Guid organizationId, Guid orderId,
            DateTime newCompleteBefore, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryPointForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            DeliveryPoint newDeliveryPoint, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryTypeForOrderAsync(Guid organizationId, Guid orderId, OrderServiceType newServiceType,
            DeliveryPoint? deliveryPoint = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangePaymentForDeliveryOrderAsync(Guid organizationId, Guid orderId, IEnumerable<Payment> payments,
            IEnumerable<Tips>? tips = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ChangeDeliveryCommentAsync(Guid organizationId, Guid orderId, string comment,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Print delivery bill.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1print_delivery_bill/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> PrintDeliveryBillAsync(Guid organizationId, Guid orderId, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Confirm delivery.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1confirm/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> ConfirmDeliveryAsync(Guid organizationId, Guid orderId, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Cancel delivery confirmation.
        /// Allowed from version 7.6.1.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update/paths/~1api~11~1deliveries~1cancel_confirmation/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> CancelDeliveryConfirmationAsync(Guid organizationId, Guid orderId, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> AssignOrChangeDeliveryOrderOperatorAsync(Guid organizationId, Guid orderId,
            Guid operatorId, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderInfoWithOperation> RetrieveDeliveryOrdersByIdsAsync(Guid organizationId,
            IEnumerable<Guid>? orderIds = null, IEnumerable<string>? sourceKeys = null,
            IEnumerable<Guid>? posOrderIds = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByStatusesAndDatesAsync(
            IEnumerable<Guid> organizationIds, DateTime deliveryDateFrom, DateTime? deliveryDateTo = null,
            IEnumerable<DeliveryStatusShort>? statuses = null, IEnumerable<string>? sourceKeys = null,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Retrieve list of orders changed from the time revision was passed.
        /// Source: https://api-ru.iiko.services/#tag/Deliveries:-Retrieve/paths/~1api~11~1deliveries~1by_revision/post.
        /// </summary>
        /// <param name="startRevision">Revision start number beginning from which (but not including)
        /// new/edited orders will be returned.</param>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(long startRevision,
            IEnumerable<Guid> organizationIds, IEnumerable<string>? sourceKeys = null,
            CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(
            IEnumerable<Guid> organizationIds, string? phone = null, DateTime? deliveryDateFrom = null,
            DateTime? deliveryDateTo = null, long? startRevision = null, IEnumerable<string>? sourceKeys = null,
            int? rowsCount = null, CancellationToken? cancellationToken = default);

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RevisionOrderInfo> RetrieveDeliveryOrdersByAdditionalFiltersAsync(IEnumerable<Guid> organizationIds,
            SortProperty sortProperty, SortDirection sortDirection, IEnumerable<Guid>? terminalGroupIds = null,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, IEnumerable<DeliveryStatus>? statuses = null,
            bool? hasProblem = null, OrderServiceType? orderServiceType = null, string? searchText = null,
            int? timeToCookingErrorTimeout = null, int? cookingTimeout = null, int? rowsCount = null,
            IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null,
            CancellationToken? cancellationToken = default);

        #endregion

        #region Addresses https://api-ru.iiko.services/#tag/Addresses

        /// <summary>
        /// Regions.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1regions/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RegionWithOperation> RetrieveRegionsAsync(IEnumerable<Guid> organizationIds,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Cities.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1cities/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CitiesWithOperation> RetrieveCitiesAsync(IEnumerable<Guid> organizationIds,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Streets by city.
        /// Source: https://api-ru.iiko.services/#tag/Addresses/paths/~1api~11~1streets~1by_city/post.
        /// </summary>
        /// <param name="organizationId">Organization ID details of which have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cityId">City ID.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StreetsWithOperation> RetrieveStreetsByCityAsync(Guid organizationId, Guid cityId,
            CancellationToken? cancellationToken = default);

        #endregion

        #region Delivery restrictions https://api-ru.iiko.services/#tag/Delivery-restrictions

        /// <summary>
        /// Retrieve list of delivery restrictions.
        /// Allowed from version 6.4.16.
        /// Source: https://api-ru.iiko.services/#tag/Delivery-restrictions/paths/~1api~11~1delivery_restrictions/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which delivery restrictions have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DeliveryRestrictionsWithOperation> RetrieveDeliveryRestrictionsAsync(IEnumerable<Guid> organizationIds,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Update delivery restrictions.
        /// Allowed from version 6.4.16.
        /// Source: https://api-ru.iiko.services/#tag/Delivery-restrictions/paths/~1api~11~1delivery_restrictions~1update/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="deliveryGeocodeServiceType">Geocoding service type.</param>
        /// <param name="defaultDeliveryDurationInMinutes">General standard of delivery time.</param>
        /// <param name="defaultSelfServiceDurationInMinutes">Default pickup time.</param>
        /// <param name="useSameDeliveryDuration">Indication that all delivery points in all delivery zones
        /// use common delivery time limits.</param>
        /// <param name="useSameMinSum">Indication that all delivery points for all delivery zones use the total
        /// minimum order amount.</param>
        /// <param name="useSameWorkTimeInterval">Indication that all delivery points in all zones use common
        /// time limits.</param>
        /// <param name="useSameRestrictionsOnAllWeek">Indication that all delivery points in all zones use
        /// the same schedule for all days of the week.</param>
        /// <param name="restrictions">Restrictions.</param>
        /// <param name="deliveryZones">Delivery zones.</param>
        /// <param name="rejectOnGeocodingError">Reject delivery if we could not geocode the address.</param>
        /// <param name="addDeliveryServiceCost">Add shipping cost to order.</param>
        /// <param name="useSameDeliveryServiceProduct">Indication that the cost is the same for all
        /// points of delivery.</param>
        /// <param name="useExternalAssignationService">Use external delivery distribution service.</param>
        /// <param name="frontTrustsCallCenterCheck">Indication whether or not to trust on the fronts the call
        /// center mapping restrictions from the call center if the composition of the order has not changed since
        /// the last check. If true, then trust.</param>
        /// <param name="requireExactAddressForGeocoding">Require an exact geocoding address.</param>
        /// <param name="zonesMode">Delivery restrictions mode.</param>
        /// <param name="autoAssignExternalDeliveries">Automatically assigned delivery method based on cartography.</param>
        /// <param name="actionOnValidationRejection">Action on problems with auto-assignment.</param>
        /// <param name="deliveryRegionsMapUrl">Link to the map of delivery service regions.</param>
        /// <param name="defaultMinSum">Total minimum order amount.</param>
        /// <param name="defaultFrom">The beginning of the interval of the total work time for all points and delivery zones,
        /// in minutes from the beginning of the day.</param>
        /// <param name="defaultTo">End of the total work time interval for all points and delivery zones,
        /// in minutes from the beginning of the day.</param>
        /// <param name="defaultDeliveryServiceProductId">Link to "delivery service payment".</param>
        /// <param name="externalAssignationServiceUrl">Address of external delivery distribution service.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> UpdateDeliveryRestrictionsAsync(Guid organizationId, int deliveryGeocodeServiceType,
            long defaultDeliveryDurationInMinutes, long defaultSelfServiceDurationInMinutes, bool useSameDeliveryDuration,
            bool useSameMinSum, bool useSameWorkTimeInterval, bool useSameRestrictionsOnAllWeek,
            IEnumerable<DeliveryRestrictionItem> restrictions, IEnumerable<DeliveryZone> deliveryZones,
            bool rejectOnGeocodingError, bool addDeliveryServiceCost, bool useSameDeliveryServiceProduct,
            bool useExternalAssignationService, bool frontTrustsCallCenterCheck, bool requireExactAddressForGeocoding,
            int zonesMode, bool autoAssignExternalDeliveries, int actionOnValidationRejection,
            string? deliveryRegionsMapUrl = null, double? defaultMinSum = null, int? defaultFrom = null,
            int? defaultTo = null, Guid? defaultDeliveryServiceProductId = null, string? externalAssignationServiceUrl = null,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Get suitable terminal groups for delivery restrictions.
        /// Allowed from version 6.4.16.
        /// Source: https://api-ru.iiko.services/#tag/Delivery-restrictions/paths/~1api~11~1delivery_restrictions~1allowed/post.
        /// </summary>
        /// <param name="organizationIds">Organization IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="isCourierDelivery">Type of delivery service.</param>
        /// <param name="deliveryAddress">Delivery address.</param>
        /// <param name="orderLocation">Order location.</param>
        /// <param name="orderItems">Order list.</param>
        /// <param name="deliveryDate">Delivery date (Local for delivery terminal).</param>
        /// <param name="deliverySum">Sum.</param>
        /// <param name="discountSum">Discounts sum.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SuitableTerminalGroupsWithOperation> GetSuitableTerminalGroupsForDeliveryRestrictionsAsync(
            IEnumerable<Guid> organizationIds, bool isCourierDelivery, DeliveryAddress? deliveryAddress = null,
            Coordinate? orderLocation = null, IEnumerable<RestrictionsOrderItem>? orderItems = null,
            DateTime? deliveryDate = null, double? deliverySum = null, double? discountSum = null,
            CancellationToken? cancellationToken = default);

        #endregion

        #region Marketing sources https://api-ru.iiko.services/#tag/Marketing-sources

        /// <summary>
        /// Marketing sources.
        /// Allowed from version 7.2.5.
        /// Source: https://api-ru.iiko.services/#tag/Marketing-sources/paths/~1api~11~1marketing_sources/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which marketing sources have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MarketingSourceWithOperation> RetrieveMarketingSourcesAsync(IEnumerable<Guid> organizationIds,
            CancellationToken? cancellationToken = default);

        #endregion

        #region Drafts https://api-ru.iiko.services/#tag/Drafts

        /// <summary>
        /// Retrieve order draft by ID.
        /// Source: https://api-ru.iiko.services/#tag/Drafts/paths/~1api~11~1deliveries~1drafts~1by_id/post.
        /// </summary>
        /// <param name="organizationId">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="employeeId">ID of the employee who wants to get this draft for editing.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderDraftWithOperation> RetrieveOrderDraftByIdAsync(Guid organizationId, Guid orderId,
            Guid employeeId, CancellationToken? cancellationToken = default);

        /// <summary>
        /// Retrieve order drafts list by parameters.
        /// Source: https://api-ru.iiko.services/#tag/Drafts/paths/~1api~11~1deliveries~1drafts~1by_filter/post.
        /// </summary>
        /// <param name="organizationIds">Organization ID for which an order drafts search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="deliveryDateFrom">Order delivery date (Local for delivery terminal). Lower limit.</param>
        /// <param name="deliveryDateTo">Order delivery date (Local for delivery terminal). Upper limit.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="limit">Desirable size of result set (50 by default).</param>
        /// <param name="offset">Offset from the beginning of full result set for paging.</param>
        /// <param name="sourceKeys">Delivery sources (DeliveryClub, PH and etc.)</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderDraftsListWithOperation> RetrieveOrderDraftsByParametersAsync(IEnumerable<Guid> organizationIds,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, string? phone = null,
            int? limit = null, int? offset = null, IEnumerable<string>? sourceKeys = null,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Store order draft changes to DB.
        /// Source: https://api-ru.iiko.services/#tag/Drafts/paths/~1api~11~1deliveries~1drafts~1save/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="order">Order item.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OperationInfo> StoreOrderDraftChangesToDbAsync(Guid organizationId, DeliveryOrder order,
            CancellationToken? cancellationToken = default);

        /// <summary>
        /// Admit order draft changes and send them to Front.
        /// Source: https://api-ru.iiko.services/#tag/Drafts/paths/~1api~11~1deliveries~1drafts~1commit/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new order.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="orderId">ID of an order.</param>
        /// <param name="terminalGroupId">Front group ID an order must be sent to.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="createOrderSettings">Order creation parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderWithOperationInfo> AdmitOrderDraftChangesAndSendThemToFrontAsync(Guid organizationId,
            Guid orderId, Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null,
            CancellationToken? cancellationToken = default);

        #endregion
    }
}
