using IikoTransport.Net.Entities.Common.Addresses.Cities;
using IikoTransport.Net.Entities.Common.Addresses.Regions;
using IikoTransport.Net.Entities.Common.Addresses.Streets;
using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Delivery.Restrictions;
using IikoTransport.Net.Entities.Requests.Delivery.Retrieve;
using IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve;
using IikoTransport.Net.Entities.Responses.Delivery.Drafts;
using IikoTransport.Net.Entities.Responses.Delivery.MarketingSources;
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions;
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions.AllowedRestirctions;
using IikoTransport.Net.Entities.Responses.General.Operations;
using DeliveryOrderRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryOrder;
using DeliveryPointRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.DeliveryPoint;
using DeliveryAddressRequest = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryAddress;


namespace IikoTransport.Net.Repositories.IikoCloud.Delivery
{
    public class HttpDelivery : HttpHelper, IDelivery
    {
        #region Fields

        private const string DefaultCreateDeliveryUri = "https://api-ru.iiko.services/api/1/deliveries/create";
        private const string DefaultUpdateOrderProblemUri = "https://api-ru.iiko.services/api/1/deliveries/update_order_problem";
        private const string DefaultUpdateDeliveryStatusUri
            = "https://api-ru.iiko.services/api/1/deliveries/update_order_delivery_status";
        private const string DefaultUpdateOrderCourierUri = "https://api-ru.iiko.services/api/1/deliveries/update_order_courier";
        private const string DefaultAddOrderItemsUri = "https://api-ru.iiko.services/api/1/deliveries/add_items";
        private const string DefaultCloseOrderUri = "https://api-ru.iiko.services/api/1/deliveries/close";
        private const string DefaultCancelDeliveryOrderUri = "https://api-ru.iiko.services/api/1/deliveries/cancel";
        private const string DefaultChangeTimeWhenClientWantsOrderToBeDeliveredUri
            = "https://api-ru.iiko.services/api/1/deliveries/change_complete_before";
        private const string DefaultChangeDeliveryPointInformationOfOrderUri
            = "https://api-ru.iiko.services/api/1/deliveries/change_delivery_point";
        private const string DefaultChangeDeliveryTypeOfOrderUri
            = "https://api-ru.iiko.services/api/1/deliveries/change_service_type";
        private const string DefaultChangePaymentOfOrderUri = "https://api-ru.iiko.services/api/1/deliveries/change_payments";
        private const string DefaultChangeCommentOfOrderUri = "https://api-ru.iiko.services/api/1/deliveries/change_comment";
        private const string DefaultPrintDeliveryBillUri = "https://api-ru.iiko.services/api/1/deliveries/print_delivery_bill";
        private const string DefaultConfirmDeliveryUri = "https://api-ru.iiko.services/api/1/deliveries/confirm";
        private const string DefaultCancelDeliveryConfirmationUri 
            = "https://api-ru.iiko.services/api/1/deliveries/cancel_confirmation";
        private const string DefaultAssignOrChangeOrderOperatorUri = "https://api-ru.iiko.services/api/1/deliveries/change_operator";
        private const string DefaultRetrieveOrdersByIdsUri = "https://api-ru.iiko.services/api/1/deliveries/by_id";
        private const string DefaultRetrieveOrdersByStatusesAndDatesUri
            = "https://api-ru.iiko.services/api/1/deliveries/by_delivery_date_and_status";
        private const string DefaultRetrieveOrdersChangedFromTimeRevisionWasPassedUri
            = "https://api-ru.iiko.services/api/1/deliveries/by_revision";
        private const string DefaultRetrieveOrdersByTelephoneDatesAndRevisionUri
            = "https://api-ru.iiko.services/api/1/deliveries/by_delivery_date_and_phone";
        private const string DefaultSearchOrdersByAdditionalFiltersUri
            = "https://api-ru.iiko.services/api/1/deliveries/by_delivery_date_and_source_key_and_filter";
        private const string DefaultRetrieveRegionsUri = "https://api-ru.iiko.services/api/1/regions";
        private const string DefaultRetrieveCitiesUri = "https://api-ru.iiko.services/api/1/cities";
        private const string DefaultRetrieveStreetsByCityUri = "https://api-ru.iiko.services/api/1/streets/by_city";
        private const string DefaultRetrieveDeliveryRestrictionsUri
            = "https://api-ru.iiko.services/api/1/delivery_restrictions";
        private const string DefaultUpdateDeliveryRestrictionsUri
            = "https://api-ru.iiko.services/api/1/delivery_restrictions/update";
        private const string DefaultGetSuitableTerminalGroupsForDeliveryRestrictionsUri
            = "https://api-ru.iiko.services/api/1/delivery_restrictions/allowed";
        private const string DefaultRetrieveMarketingSourcesUri = "https://api-ru.iiko.services/api/1/marketing_sources";
        private const string DefaultRetrieveOrderDraftByIdUri = "https://api-ru.iiko.services/api/1/deliveries/drafts/by_id";
        private const string DefaultRetrieveOrderDraftsByParametersUri
            = "https://api-ru.iiko.services/api/1/deliveries/drafts/by_filter";
        private const string DefaultStoreOrderDraftChangesToDbUri = "https://api-ru.iiko.services/api/1/deliveries/drafts/save";
        private const string DefaultAdmitOrderDraftChangesAndSendThemToFrontUri
            = "https://api-ru.iiko.services/api/1/deliveries/drafts/commit";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpDelivery(string token) => Token = token;

        #endregion

        #region Methods

        #region Deliveries: Create and update https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update

        public Task<OrderWithOperationInfo> CreateDeliveryAsync(Guid organizationId, DeliveryOrderRequest order,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryOrderProblemAsync(Guid organizationId, Guid orderId, bool hasProblem,
            string? problem = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryStatusAsync(Guid organizationId, Guid orderId, DeliveryStatus deliveryStatus,
            DateTime? deliveryDate = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryOrderCourierAsync(Guid organizationId, Guid orderId, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> AddDeliveryOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItem> items,
            IEnumerable<Combo>? combos = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> CloseDeliveryOrderAsync(Guid organizationId, Guid orderId, DateTime? deliveryDate = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> CancelDeliveryOrderAsync(Guid organizationId, Guid orderId, Guid? movedOrderId = null,
            Guid? cancelCauseId = null, Guid? removalTypeId = null, Guid? userIdForWriteoff = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(Guid organizationId, Guid orderId,
            DateTime newCompleteBefore)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeDeliveryPointForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            DeliveryPointRequest newDeliveryPoint)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeDeliveryTypeForOrderAsync(Guid organizationId, Guid orderId, OrderServiceType newServiceType,
            DeliveryPointRequest? deliveryPoint = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangePaymentForDeliveryOrderAsync(Guid organizationId, Guid orderId, IEnumerable<Payment> payments,
            IEnumerable<Tips>? tips = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeDeliveryCommentAsync(Guid organizationId, Guid orderId, string comment)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> PrintDeliveryBillAsync(Guid organizationId, Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ConfirmDeliveryAsync(Guid organizationId, Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> CancelDeliveryConfirmationAsync(Guid organizationId, Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> AssignOrChangeDeliveryOrderOperatorAsync(Guid organizationId, Guid orderId, Guid operatorId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        public Task<OrderWithOperationInfo> AdmitOrderDraftChangesAndSendThemToFrontAsync(Guid organizationId, Guid odrerId,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            throw new NotImplementedException();
        }

        public Task<SuitableTerminalGroupsWithOperation> GetSuitableTerminalGroupsForDeliveryRestrictionsAsync(
            IEnumerable<Guid> organizationIds, bool isCourierDelivery, DeliveryAddressRequest? deliveryAddress = null,
            Coordinate? orderLocation = null, IEnumerable<RestrictionsOrderItem>? orderItems = null,
            DateTime? deliveryDate = null, double? deliverySum = null, double? discountSum = null)
        {
            throw new NotImplementedException();
        }

        public Task<CitiesWithOperation> RetrieveCitiesAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByAdditionalFiltersAsync(IEnumerable<Guid> organizationIds,
            SortProperty sortProperty, SortDirection sortDirection, IEnumerable<Guid>? terminalGroupIds = null,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, IEnumerable<DeliveryStatus>? statuses = null, bool? hasProblem = null, OrderServiceType? orderServiceType = null, string? searchText = null, int? timeToCookingErrorTimeout = null, int? cookingTimeout = null, int? rowsCount = null, IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrderInfoWithOperation> RetrieveDeliveryOrdersByIdsAsync(Guid organizationId, IEnumerable<Guid>? orderIds = null, IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? posOrderIds = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(IEnumerable<Guid> organizationIds, string? phone = null, DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, long? startRevision = null, IEnumerable<string>? sourceKeys = null, int? rowsCount = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByStatusesAndDatesAsync(IEnumerable<Guid> organizationIds, DateTime deliveryDateFrom, DateTime? deliveryDateTo = null, IEnumerable<Entities.Requests.Delivery.CreateAndUpdate.DeliveryStatus>? statuses = null, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(long startRevision, IEnumerable<Guid> organizationIds, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryRestrictionsWithOperation> RetrieveDeliveryRestrictionsAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<MarketingSourceWithOperation> RetrieveMarketingSourcesAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDraftWithOperation> RetrieveOrderDraftByIdAsync(Guid organizationId, Guid orderId, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDraftsListWithOperation> RetrieveOrderDraftsByParametersAsync(IEnumerable<Guid> organizationIds, DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, string? phone = null, int? limit = null, int? offset = null, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<RegionWithOperation> RetrieveRegionsAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<StreetsWithOperation> RetrieveStreetsByCityAsync(Guid organizationId, Guid cityId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> StoreOrderDraftChangesToDbAsync(Guid organizationId, Entities.Requests.Delivery.CreateAndUpdate.DeliveryOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryRestrictionsAsync(Guid organizationId, int deliveryGeocodeServiceType, long defaultDeliveryDurationInMinutes, long defaultSelfServiceDurationInMinutes, bool useSameDeliveryDuration, bool useSameMinSum, bool useSameWorkTimeInterval, bool useSameRestrictionsOnAllWeek, IEnumerable<Entities.Requests.Delivery.Restrictions.DeliveryRestrictionItem> restrictions, IEnumerable<Entities.Requests.Delivery.Restrictions.DeliveryZone> deliveryZones, bool rejectOnGeocodingError, bool addDeliveryServiceCost, bool useSameDeliveryServiceProduct, bool useExternalAssignationService, bool frontTrustsCallCenterCheck, bool requireExactAddressForGeocoding, int zonesMode, bool autoAssignExternalDeliveries, int actionOnValidationRejection, string? deliveryRegionsMapUrl = null, double? defaultMinSum = null, int? defaultFrom = null, int? defaultTo = null, Guid? defaultDeliveryServiceProductId = null, string? externalAssignationServiceUrl = null)
        {
            throw new NotImplementedException();
        }
    }
}
