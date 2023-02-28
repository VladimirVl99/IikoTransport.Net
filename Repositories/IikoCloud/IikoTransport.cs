using IikoTransport.Net.Entities.Common.Addresses.Cities;
using IikoTransport.Net.Entities.Common.Addresses.Regions;
using IikoTransport.Net.Entities.Common.Addresses.Streets;
using IikoTransport.Net.Entities.Common.Customers;
using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments;
using IikoTransport.Net.Entities.Requests.Delivery.Restrictions;
using IikoTransport.Net.Entities.Requests.Delivery.Retrieve;
using IikoTransport.Net.Entities.Requests.General.Notifications;
using IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.Customers;
using IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.DiscountsAndPromotions;
using IikoTransport.Net.Entities.Requests.Orders;
using IikoTransport.Net.Entities.Requests.Orders.CreateOrder;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections;
using IikoTransport.Net.Entities.Responses.Delivery.DeliveryRetrieve;
using IikoTransport.Net.Entities.Responses.Delivery.Drafts;
using IikoTransport.Net.Entities.Responses.Delivery.MarketingSources;
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions;
using IikoTransport.Net.Entities.Responses.Delivery.Restrictions.AllowedRestirctions;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Delivery;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.DiscountsAndSurcharges;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Order;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Payments;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.RemovalTypes;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.TipsTypes;
using IikoTransport.Net.Entities.Responses.General.Employees;
using IikoTransport.Net.Entities.Responses.General.Employees.Couriers;
using IikoTransport.Net.Entities.Responses.General.Menu.Combo;
using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature;
using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature.ExternalMenus;
using IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems;
using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations;
using IikoTransport.Net.Entities.Responses.General.Terminals.AvailabilityOfGroupOfTerminals;
using IikoTransport.Net.Entities.Responses.General.Terminals.AwakeTerminalGroups;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.CustomerCategories;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.Customers;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.ManualConditions;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs;
using IikoTransport.Net.Entities.Responses.Orders;
using IikoTransport.Net.Entities.Responses.Webhooks;
using IikoTransport.Net.Entities.Responses.Webhooks.Filters;
using CustomerRequest = IikoTransport.Net.Entities.Requests.Orders.Customers.Customer;
using CustomerOfDeliveryRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers.Customer;
using OrderItemRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.OrderItem;
using ComboRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Combo;
using OrderWithOperationInfoResponse = IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate.OrderWithOperationInfo;
using DeliveryOrderRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryOrder;
using DeliveryPointRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses.DeliveryPoint;
using OrderServiceType = IikoTransport.Net.Entities.Common.Orders.OrderServiceType;
using GuestDetailsRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers.GuestDetails;
using DeliveryAddressRequest = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryAddress;
using DeliveryStatus = IikoTransport.Net.Entities.Common.Deliveries.DeliveryStatus;
using SimpleDeliveryStatus = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.DeliveryStatus;
using DeliveryRestrictionItemRequest = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryRestrictionItem;
using DeliveryZoneRequest = IikoTransport.Net.Entities.Requests.Delivery.Restrictions.DeliveryZone;
using IikoTransport.Net.Repositories.IikoCloud.General;
using System.Net;
using OrderStatus = IikoTransport.Net.Entities.Common.Orders.OrderStatus;
using IikoTransport.Net.Repositories.IikoCloud.Delivery;

namespace IikoTransport.Net.Repositories.IikoCloud
{
    /// <summary>
    /// 
    /// </summary>
    public class IikoTransport : IIikoTransport
    {
        #region Fields

        /// <summary>
        /// API login.
        /// </summary>
        private readonly string _apiLogin;

        /// <summary>
        /// Token.
        /// </summary>
        private string _token;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpGeneral _httpGeneral;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpDelivery _httpDelivery;

        #endregion

        #region Properties

        /// <summary>
        /// API login.
        /// </summary>
        public string ApiLogin => _apiLogin;

        /// <summary>
        /// Token.
        /// </summary>
        public string Token => _token;

        #endregion

        #region Constructors

        private IikoTransport(string apiLogin, string token)
        {
            _apiLogin = apiLogin;
            _token = token;
            _httpGeneral = new HttpGeneral(token);
            _httpDelivery = new HttpDelivery(token);
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="apiLogin"></param>
        /// <returns></returns>
        public async Task<IikoTransport> CreateAsync(string apiLogin)
        {
            var token = await RetrieveSessionKeyForApiUserAsync(apiLogin);
            return new IikoTransport(apiLogin, token);
        }

        #region General

        #region Authorization https://api-ru.iiko.services/#tag/Authorization

        public async Task<string> RetrieveSessionKeyForApiUserAsync(string apiLogin)
            => await _httpGeneral.RetrieveSessionKeyForApiUserAsync(apiLogin);

        #endregion

        #region Notifications https://api-ru.iiko.services/#tag/Notifications

        public async Task SendNotificationToExternalSystemsAsync(string orderSource, Guid orderId, string additionalInfo,
            MessageType messageType, Guid organizationId)
        {
            try
            {
                await _httpGeneral.SendNotificationToExternalSystemsAsync(orderSource, orderId, additionalInfo,
                    messageType, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpGeneral.SendNotificationToExternalSystemsAsync(orderSource, orderId, additionalInfo,
                        messageType, organizationId);
                    return;
                }

                throw e;
            }
        }

        #endregion

        #region Organizations https://api-ru.iiko.services/#tag/Organizations

        public async Task<OrganizationInfo> RetrieveAvailableOrganizationsAsync(IEnumerable<Guid>? organizationIds = null,
            bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            try
            {
                return await _httpGeneral.RetrieveAvailableOrganizationsAsync(organizationIds, returnAdditionalInfo, includeDisabled);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveAvailableOrganizationsAsync(organizationIds, returnAdditionalInfo,
                        includeDisabled);
                }

                throw e;
            }
        }

        #endregion

        #region Terminal groups https://api-ru.iiko.services/#tag/Terminal-groups

        public async Task<DeliveryTerminalGroupInfo> RetrieveGroupsOfDeliveryTerminalsAsync(IEnumerable<Guid> organizationIds,
            bool includeDisabled = false)
        {
            try
            {
                return await _httpGeneral.RetrieveGroupsOfDeliveryTerminalsAsync(organizationIds, includeDisabled);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveGroupsOfDeliveryTerminalsAsync(organizationIds, includeDisabled);
                }

                throw e;
            }
        }

        public async Task<AvailabilityTerminalGroupInfo> RetrieveInformationOnAvailabilityOfGroupOfTerminalsAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<Guid> terminalGroupIds)
        {
            try
            {
                return await _httpGeneral.RetrieveInformationOnAvailabilityOfGroupOfTerminalsAsync(
                    organizationIds, terminalGroupIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveInformationOnAvailabilityOfGroupOfTerminalsAsync(organizationIds,
                        terminalGroupIds);
                }

                throw e;
            }
        }

        public async Task<AwakeTerminalGroupsResult> AwakeTerminalGroupsFromSleepModeAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> terminalGroupIds)
        {
            try
            {
                return await _httpGeneral.AwakeTerminalGroupsFromSleepModeAsync(organizationIds, terminalGroupIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.AwakeTerminalGroupsFromSleepModeAsync(organizationIds, terminalGroupIds);
                }

                throw e;
            }
        }

        #endregion

        #region Dictionaries https://api-ru.iiko.services/#tag/Dictionaries

        public async Task<CancelCauseInfo> RetrieveDeliveryCancelCausesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveDeliveryCancelCausesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveDeliveryCancelCausesAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<OrderTypeInfo> RetrieveOrderTypes(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveOrderTypes(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveOrderTypes(organizationIds);
                }

                throw e;
            }
        }

        public async Task<DiscountInfo> RetrieveDiscountsAndSurchargesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveDiscountsAndSurchargesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveDiscountsAndSurchargesAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<PaymentInfo> RetrievePaymentTypesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrievePaymentTypesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrievePaymentTypesAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<RemovalTypeInfo> RetrieveRemovalTypesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveRemovalTypesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveRemovalTypesAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<TipTypeInfo> RetrieveTipsTipesForRmsGroupAsync()
        {
            try
            {
                return await _httpGeneral.RetrieveTipsTipesForRmsGroupAsync();
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveTipsTipesForRmsGroupAsync();
                }

                throw e;
            }
        }

        #endregion

        #region Menu https://api-ru.iiko.services/#tag/Menu

        public async Task<MenuInfo> RetrieveMenuAsync(Guid organizationId, long? startRevision = null)
        {
            try
            {
                return await _httpGeneral.RetrieveMenuAsync(organizationId, startRevision);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveMenuAsync(organizationId, startRevision);
                }

                throw e;
            }
        }

        public async Task<ExternalMenuInfo> RetrieveExternalMenusWithPriceCategoriesAsync()
        {
            try
            {
                return await _httpGeneral.RetrieveExternalMenusWithPriceCategoriesAsync();
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveExternalMenusWithPriceCategoriesAsync();
                }

                throw e;
            }
        }

        public async Task<Menu> RetrieveExternalMenuByIdAsync(string externalMenuId, IEnumerable<Guid> organizationIds,
            string? priceCategoryId = null, int? version = null)
        {
            try
            {
                return await _httpGeneral.RetrieveExternalMenuByIdAsync(externalMenuId, organizationIds, priceCategoryId,
                    version);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveExternalMenuByIdAsync(externalMenuId, organizationIds,
                        priceCategoryId, version);
                }

                throw e;
            }
        }

        public async Task<OutOfStockInfo> RetrieveOutOfStockItemsAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveOutOfStockItemsAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveOutOfStockItemsAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<ComboInfo> RetrieveCombosInfoAsync(bool extraData, Guid organizationId)
        {
            try
            {
                return await _httpGeneral.RetrieveCombosInfoAsync(extraData, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveCombosInfoAsync(extraData, organizationId);
                }

                throw e;
            }
        }

        public async Task<ComboPriceInfo> CalculateComboPriceAsync(IEnumerable<OrderItemRequest> items, Guid organizationId)
        {
            try
            {
                return await _httpGeneral.CalculateComboPriceAsync(items, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.CalculateComboPriceAsync(items, organizationId);
                }

                throw e;
            }
        }

        #endregion

        #region Operations https://api-ru.iiko.services/#tag/Operations

        public async Task<CommandStatus> GetStatusOfCommandAsync(Guid organizationId, Guid correlationId)
        {
            try
            {
                return await _httpGeneral.GetStatusOfCommandAsync(organizationId, correlationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.GetStatusOfCommandAsync(organizationId, correlationId);
                }

                throw e;
            }
        }

        #endregion

        #region Employees https://api-ru.iiko.services/#tag/Employees

        public async Task<CoordinateHistory> RetrieveCoordinatesHistoryOfDriverAsync(IEnumerable<Guid> organizationIds,
            int? offsetInSeconds = null)
        {
            try
            {
                return await _httpGeneral.RetrieveCoordinatesHistoryOfDriverAsync(organizationIds, offsetInSeconds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveCoordinatesHistoryOfDriverAsync(organizationIds, offsetInSeconds);
                }

                throw e;
            }
        }

        public async Task<CouriersInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveDeliveryDriversInSpecifiedRestaurantsAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveDeliveryDriversInSpecifiedRestaurantsAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<CouriersWithCheckRolesInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsWithCheckRolesAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<string> rolesToCheck)
        {
            try
            {
                return await _httpGeneral.RetrieveDeliveryDriversInSpecifiedRestaurantsWithCheckRolesAsync(
                    organizationIds, rolesToCheck);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveDeliveryDriversInSpecifiedRestaurantsWithCheckRolesAsync(
                        organizationIds, rolesToCheck);
                }

                throw e;
            }
        }

        public async Task<ActiveCouriersInfo> RetrieveActiveDeliveryDriversInSpecifiedRestaurantAndOnSpecifiedTerminalAsync(
            Guid organizationId, Guid terminalGroupId)
        {
            try
            {
                return await _httpGeneral.RetrieveActiveDeliveryDriversInSpecifiedRestaurantAndOnSpecifiedTerminalAsync(
                    organizationId, terminalGroupId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveActiveDeliveryDriversInSpecifiedRestaurantAndOnSpecifiedTerminalAsync(
                        organizationId, terminalGroupId);
                }

                throw e;
            }
        }

        public async Task<ActiveCouriersInfo> RetrieveActiveLocationsOfCourierInSpecifiedRestaurantsAsync(
            IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpGeneral.RetrieveActiveLocationsOfCourierInSpecifiedRestaurantsAsync(
                    organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveActiveLocationsOfCourierInSpecifiedRestaurantsAsync(
                        organizationIds);
                }

                throw e;
            }
        }

        public async Task<EmployeeInfo> RetrieveEmployeeInfoAsync(Guid organizationId, Guid id)
        {
            try
            {
                return await _httpGeneral.RetrieveEmployeeInfoAsync(organizationId, id);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.RetrieveEmployeeInfoAsync(organizationId, id);
                }

                throw e;
            }
        }

        public async Task<PersonalSessionActionResult> OpenPersonalSessionAsync(Guid organizationId,
            Guid terminalGroupId, Guid employeeId, Guid? roleId = null)
        {
            try
            {
                return await _httpGeneral.OpenPersonalSessionAsync(organizationId, terminalGroupId,
                    employeeId, roleId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.OpenPersonalSessionAsync(organizationId, terminalGroupId,
                        employeeId, roleId);
                }

                throw e;
            }
        }

        public async Task<PersonalSessionActionResult> ClosePersonalSessionAsync(Guid organizationId,
            Guid terminalGroupId, Guid employeeId)
        {
            try
            {
                return await _httpGeneral.ClosePersonalSessionAsync(organizationId, terminalGroupId, employeeId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.ClosePersonalSessionAsync(organizationId, terminalGroupId, employeeId);
                }

                throw e;
            }
        }

        public async Task<PersonalSessionInfo> CheckForOpenPersonalShiftAsync(Guid organizationId, Guid terminalGroupId,
            Guid employeeId)
        {
            try
            {
                return await _httpGeneral.CheckForOpenPersonalShiftAsync(organizationId, terminalGroupId, employeeId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpGeneral.CheckForOpenPersonalShiftAsync(organizationId, terminalGroupId, employeeId);
                }

                throw e;
            }
        }

        #endregion

        #endregion

        #region Delivery

        #region Deliveries: Create and update https://api-ru.iiko.services/#tag/Deliveries:-Create-and-update

        public Task<OrderWithOperationInfoResponse> CreateDeliveryAsync(Guid organizationId, DeliveryOrderRequest order,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryOrderProblemAsync(Guid organizationId, Guid orderId, bool hasProblem,
            string? problem = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryStatusAsync(Guid organizationId, Guid orderId, SimpleDeliveryStatus deliveryStatus,
            DateTime? deliveryDate = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryOrderCourierAsync(Guid organizationId, Guid orderId, Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> AddDeliveryOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItemRequest> items,
            IEnumerable<ComboRequest>? combos = null)
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

        public Task<OperationInfo> ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(Guid organizationId,
            Guid orderId, DateTime newCompleteBefore)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeDeliveryPointForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            DeliveryPointRequest newDeliveryPoint)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangeDeliveryTypeForOrderAsync(Guid organizationId, Guid orderId,
            OrderServiceType newServiceType, DeliveryPointRequest? deliveryPoint = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangePaymentForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            IEnumerable<Payment> payments, IEnumerable<Tips>? tips = null)
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

        public Task<OperationInfo> AssignOrChangeDeliveryOrderOperatorAsync(Guid organizationId, Guid orderId,
            Guid operatorId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Deliveries: Retrieve https://api-ru.iiko.services/#tag/Deliveries:-Retrieve

        public Task<OrderInfoWithOperation> RetrieveDeliveryOrdersByIdsAsync(Guid organizationId, IEnumerable<Guid>? orderIds = null,
            IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? posOrderIds = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByStatusesAndDatesAsync(IEnumerable<Guid> organizationIds,
            DateTime deliveryDateFrom, DateTime? deliveryDateTo = null, IEnumerable<SimpleDeliveryStatus>? statuses = null,
            IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(long startRevision,
            IEnumerable<Guid> organizationIds, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(IEnumerable<Guid> organizationIds,
            string? phone = null, DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, long? startRevision = null,
            IEnumerable<string>? sourceKeys = null, int? rowsCount = null)
        {
            throw new NotImplementedException();
        }

        public Task<RevisionOrderInfo> RetrieveDeliveryOrdersByAdditionalFiltersAsync(IEnumerable<Guid> organizationIds,
            SortProperty sortProperty, SortDirection sortDirection, IEnumerable<Guid>? terminalGroupIds = null,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, IEnumerable<DeliveryStatus>? statuses = null,
            bool? hasProblem = null, OrderServiceType? orderServiceType = null, string? searchText = null,
            int? timeToCookingErrorTimeout = null, int? cookingTimeout = null, int? rowsCount = null,
            IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Addresses https://api-ru.iiko.services/#tag/Addresses

        public Task<RegionWithOperation> RetrieveRegionsAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<CitiesWithOperation> RetrieveCitiesAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<StreetsWithOperation> RetrieveStreetsByCityAsync(Guid organizationId, Guid cityId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delivery restrictions https://api-ru.iiko.services/#tag/Delivery-restrictions

        public Task<DeliveryRestrictionsWithOperation> RetrieveDeliveryRestrictionsAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateDeliveryRestrictionsAsync(Guid organizationId, int deliveryGeocodeServiceType,
            long defaultDeliveryDurationInMinutes, long defaultSelfServiceDurationInMinutes, bool useSameDeliveryDuration,
            bool useSameMinSum, bool useSameWorkTimeInterval, bool useSameRestrictionsOnAllWeek,
            IEnumerable<DeliveryRestrictionItemRequest> restrictions, IEnumerable<DeliveryZoneRequest> deliveryZones,
            bool rejectOnGeocodingError, bool addDeliveryServiceCost, bool useSameDeliveryServiceProduct,
            bool useExternalAssignationService, bool frontTrustsCallCenterCheck, bool requireExactAddressForGeocoding,
            int zonesMode, bool autoAssignExternalDeliveries, int actionOnValidationRejection, string? deliveryRegionsMapUrl = null,
            double? defaultMinSum = null, int? defaultFrom = null, int? defaultTo = null, Guid? defaultDeliveryServiceProductId = null,
            string? externalAssignationServiceUrl = null)
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

        #endregion

        #region Marketing sources https://api-ru.iiko.services/#tag/Marketing-sources

        public Task<MarketingSourceWithOperation> RetrieveMarketingSourcesAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Drafts https://api-ru.iiko.services/#tag/Drafts

        public Task<OrderDraftWithOperation> RetrieveOrderDraftByIdAsync(Guid organizationId, Guid orderId,
            Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDraftsListWithOperation> RetrieveOrderDraftsByParametersAsync(IEnumerable<Guid> organizationIds,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, string? phone = null, int? limit = null,
            int? offset = null, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> StoreOrderDraftChangesToDbAsync(Guid organizationId, DeliveryOrderRequest order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderWithOperationInfoResponse> AdmitOrderDraftChangesAndSendThemToFrontAsync(Guid organizationId, Guid odrerId,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Orders

        #region Orders https://api-ru.iiko.services/#tag/Orders

        public Task<OrderWithOperationInfo> CreateTableOrderAsync(Guid organizationId, Guid terminalGroupId,
            TableOrder? order = null, OrderCreationSettings? createOrderSettings = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersWithOperationInfo> RetrieveTableOrdersByIdAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersWithOperationInfo> RetrieveTableOrdersByTablesAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> tableIds, IEnumerable<OrderStatus>? statuses = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> AddTableOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItemRequest> items,
            IEnumerable<ComboRequest> combos)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> CloseTableOrderAsync(Guid organizationId, Guid orderId,
            ChequeAdditionalInfo? chequeAdditionalInfo = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> ChangePaymentsForTableOrderAsync(Guid organizationId, Guid orderId,
            IEnumerable<Payment> payments, IEnumerable<Tips>? tips = null)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> InitTableOrdersByTablesAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> tableIds)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> InitTableOrdersByPOSOrdersAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> posOrderIds)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> AddCustomerToTableOrderAsync(Guid organizationId, Guid orderId, CustomerRequest customer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Reserves

        #region Banquets/reserves https://api-ru.iiko.services/#tag/Banquetsreserves

        public Task<OrganizationInfo> RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid>? organizationIds = null, bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryTerminalGroupInfo> RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantSectionsWithOperation> RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> terminalGroupIds, bool returnSchema = false, long? revision = null)
        {
            throw new NotImplementedException();
        }

        public Task<ReservesWithOperation> RetrieveReservesForPassedRestaurantSectionsAsync(
            IEnumerable<Guid> restaurantSectionIds, DateTime dateFrom, DateTime? dateTo = null)
        {
            throw new NotImplementedException();
        }

        public Task<BanquetWithOperation> CreateReserveAsync(Guid organizationId, Guid terminalGroupId,
            CustomerOfDeliveryRequest customer, string phone, long durationInMinutes, bool shouldRemind,
            IEnumerable<Guid> tableIds, DateTime estimatedStartTime, Guid? id = null, string? externalNumber = null,
            ReserveOrder? order = null, string? comment = null, int? transportToFrontTimeout = null,
            GuestDetailsRequest? guests = null)
        {
            throw new NotImplementedException();
        }

        public Task<ReservesWithOperation> RetrieveReservesStatusesByIdsAsync(Guid organizationId,
            IEnumerable<Guid> reserveIds, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Webhooks

        #region Webhooks https://api-ru.iiko.services/#tag/Webhooks

        public Task<WebhookSettings> GetWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationInfo> UpdateWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId, string webHooksUri,
            string? authToken = null, Filter? webHooksFilter = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Loyalty And Discounts

        #region Discounts and promotions https://api-ru.iiko.services/#tag/Discounts-and-promotions

        public Task<CheckinInfo> CalculateCheckinAsync(DeliveryOrderRequest order, Guid organizationId, string? coupon = null,
            Guid? referrerId = null, Guid? terminalGroupId = null, IEnumerable<DynamicDiscount>? dynamicDiscounts = null,
            IEnumerable<Guid>? availablePaymentMarketingCampaignIds = null, IEnumerable<Guid>? applicableManualConditions = null)
        {
            throw new NotImplementedException();
        }

        public Task<ManualConditionInfos> GetManualConditionsAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramInfos> GetProgramsAsync(Guid organizationId, bool? WithoutMarketingCampaigns = null)
        {
            throw new NotImplementedException();
        }

        public Task<CouponInfos> GetCouponInfoAsync(Guid organizationId, string? number = null, string? series = null)
        {
            throw new NotImplementedException();
        }

        public Task<SeriesWithNotActivatedCouponInfos> GetCouponSeriesWithNonActivatedCouponsAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<NotActivatedCouponInfos> GetNonActivatedCouponsAsync(Guid organizationId, string? series = null,
            int? pageSize = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Customer categories https://api-ru.iiko.services/#tag/Customer-categories

        public Task<CustomerCategoryInfos> GetCustomerCategoriesAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task AddCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Customers https://api-ru.iiko.services/#tag/Customers

        public Task<CustomerInfo> GetCustomerInfoByCardNumberAsync(Guid organizationId, string cardNumber)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfo> GetCustomerInfoByCardTrackAsync(Guid organizationId, string cardTrack)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfo> GetCustomerInfoByEmailAsync(Guid organizationId, string email)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfo> GetCustomerInfoByIdAsync(Guid organizationId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfo> GetCustomerInfoByPhoneAsync(Guid organizationId, string phone)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerInfo> GetCustomerInfoBySpecifiedCriterionAsync(Guid organizationId, SearchCustomerType type,
            Guid? id = null, string? phone = null, string? cardTrack = null, string? cardNumber = null, string? email = null)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateOrUpdateCustomerAsync(Guid organizationId, Guid? id = null, string? phone = null,
            string? cardTrack = null, string? cardNumber = null, string? name = null, string? middleName = null,
            string? surName = null, DateTime? birthday = null, string? email = null, Gender? sex = null,
            GuestConsentStatus? consentStatus = null, bool? shouldReceivePromoActionsInfo = null, Guid? referrerId = null,
            string? userData = null)
        {
            throw new NotImplementedException();
        }

        public Task AddCardForCustomerAsync(Guid customerId, string cardTrack, string cardNumber, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> AddCustomerToProgramAsync(Guid customerId, Guid programId, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task CancelHoldMoneyOfCustomerAsync(Guid transactionId, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCardForCustomerAsync(Guid customerId, string cardTrack, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> HoldMoneyOfCustomerAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            Guid? transactionId = null, string? comment = null)
        {
            throw new NotImplementedException();
        }

        public Task RefillCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null)
        {
            throw new NotImplementedException();
        }

        public Task WithdrawCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Messages https://api-ru.iiko.services/#tag/Messages

        public Task SendEmailAsync(string receiver, string subject, Guid organizationId, string? body = null)
        {
            throw new NotImplementedException();
        }

        public Task SendSmsAsync(string phone, string text, Guid organizationId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #endregion

        #region Private

        /// <summary>
        /// Updates session key.
        /// </summary>
        /// <returns></returns>
        private async Task<string> UpdateSessionKeyForApiUserAsync()
        {
            _token = await RetrieveSessionKeyForApiUserAsync(_apiLogin);

            _httpGeneral.Token = _token;
            _httpDelivery.Token = _token;

            return _token;
        }

        #endregion

        #endregion
    }
}
