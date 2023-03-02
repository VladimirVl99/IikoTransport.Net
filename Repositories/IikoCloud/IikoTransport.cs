using IikoTransport.Net.Entities.Common.Addresses.Cities;
using IikoTransport.Net.Entities.Common.Addresses.Regions;
using IikoTransport.Net.Entities.Common.Addresses.Streets;
using IikoTransport.Net.Entities.Common.Customers;
using IikoTransport.Net.Entities.Common.Orders;
using IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Addresses;
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
using DeliveryOrderWithOperationInfoResponse = IikoTransport.Net.Entities.Responses.Delivery.CreateAndUpdate.OrderWithOperationInfo;
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
using TableOrderWithOperationInfo = IikoTransport.Net.Entities.Responses.Orders.OrderWithOperationInfo;
using PaymentRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Payment;
using TipsRequest = IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Payments.Tips;
using IikoTransport.Net.Repositories.IikoCloud.Orders;
using IikoTransport.Net.Repositories.IikoCloud.BanquetsAndReserves;
using IikoTransport.Net.Repositories.IikoCloud.Webhooks;
using IikoTransport.Net.Repositories.IikoCloud.LoyaltyAndDiscounts;

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
        private string? _webHooksUri;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpGeneral _httpGeneral;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpDelivery _httpDelivery;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpOrders _httpOrders;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpReserves _httpReserves;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpWebhooks _httpWebhooks;

        /// <summary>
        /// 
        /// </summary>
        private readonly HttpLoyalty _httpLoyalty;

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

        /// <summary>
        /// 
        /// </summary>
        public string? WebHooksUri => _webHooksUri;

        #endregion

        #region Constructors

        private IikoTransport(string apiLogin, string token, string? webHooksUri = null)
        {
            _apiLogin = apiLogin;
            _token = token;
            _webHooksUri = webHooksUri;
            _httpGeneral = new HttpGeneral(token);
            _httpDelivery = new HttpDelivery(token);
            _httpOrders = new HttpOrders(token);
            _httpReserves = new HttpReserves(token);
            _httpWebhooks = new HttpWebhooks(token);
            _httpLoyalty = new HttpLoyalty(token);
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="apiLogin"></param>
        /// <param name="webHooksUri"></param>
        /// <returns></returns>
        public async Task<IikoTransport> CreateAsync(string apiLogin, string? webHooksUri = null)
        {
            var token = await RetrieveSessionKeyForApiUserAsync(apiLogin);
            return new IikoTransport(apiLogin, token, webHooksUri);
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

        public async Task<DeliveryOrderWithOperationInfoResponse> CreateDeliveryAsync(Guid organizationId, DeliveryOrderRequest order,
            Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            try
            {
                return await _httpDelivery.CreateDeliveryAsync(organizationId, order, terminalGroupId, createOrderSettings);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.CreateDeliveryAsync(organizationId, order, terminalGroupId, createOrderSettings);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> UpdateDeliveryOrderProblemAsync(Guid organizationId, Guid orderId, bool hasProblem,
            string? problem = null)
        {
            try
            {
                return await _httpDelivery.UpdateDeliveryOrderProblemAsync(organizationId, orderId, hasProblem, problem);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.UpdateDeliveryOrderProblemAsync(organizationId, orderId, hasProblem, problem);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> UpdateDeliveryStatusAsync(Guid organizationId, Guid orderId, SimpleDeliveryStatus deliveryStatus,
            DateTime? deliveryDate = null)
        {
            try
            {
                return await _httpDelivery.UpdateDeliveryStatusAsync(organizationId, orderId, deliveryStatus, deliveryDate);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.UpdateDeliveryStatusAsync(organizationId, orderId, deliveryStatus, deliveryDate);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> UpdateDeliveryOrderCourierAsync(Guid organizationId, Guid orderId, Guid employeeId)
        {
            try
            {
                return await _httpDelivery.UpdateDeliveryOrderCourierAsync(organizationId, orderId, employeeId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.UpdateDeliveryOrderCourierAsync(organizationId, orderId, employeeId);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> AddDeliveryOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItemRequest> items,
            IEnumerable<ComboRequest>? combos = null)
        {
            try
            {
                return await _httpDelivery.AddDeliveryOrderItemsAsync(organizationId, orderId, items, combos);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.AddDeliveryOrderItemsAsync(organizationId, orderId, items, combos);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> CloseDeliveryOrderAsync(Guid organizationId, Guid orderId, DateTime? deliveryDate = null)
        {
            try
            {
                return await _httpDelivery.CloseDeliveryOrderAsync(organizationId, orderId, deliveryDate);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.CloseDeliveryOrderAsync(organizationId, orderId, deliveryDate);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> CancelDeliveryOrderAsync(Guid organizationId, Guid orderId, Guid? movedOrderId = null,
            Guid? cancelCauseId = null, Guid? removalTypeId = null, Guid? userIdForWriteoff = null)
        {
            try
            {
                return await _httpDelivery.CancelDeliveryOrderAsync(organizationId, orderId, movedOrderId, cancelCauseId,
                    removalTypeId, userIdForWriteoff);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.CancelDeliveryOrderAsync(organizationId, orderId, movedOrderId, cancelCauseId,
                        removalTypeId, userIdForWriteoff);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(Guid organizationId,
            Guid orderId, DateTime newCompleteBefore)
        {
            try
            {
                return await _httpDelivery.ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(organizationId,
                    orderId, newCompleteBefore);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ChangeTimeWhenClientWantsOrderToBeDeliveredAsync(organizationId,
                        orderId, newCompleteBefore);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangeDeliveryPointForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            DeliveryPointRequest newDeliveryPoint)
        {
            try
            {
                return await _httpDelivery.ChangeDeliveryPointForDeliveryOrderAsync(organizationId, orderId,
                    newDeliveryPoint);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ChangeDeliveryPointForDeliveryOrderAsync(organizationId, orderId,
                        newDeliveryPoint);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangeDeliveryTypeForOrderAsync(Guid organizationId, Guid orderId,
            OrderServiceType newServiceType, DeliveryPointRequest? deliveryPoint = null)
        {
            try
            {
                return await _httpDelivery.ChangeDeliveryTypeForOrderAsync(organizationId, orderId,
                    newServiceType, deliveryPoint);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ChangeDeliveryTypeForOrderAsync(organizationId, orderId,
                        newServiceType, deliveryPoint);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangePaymentForDeliveryOrderAsync(Guid organizationId, Guid orderId,
            IEnumerable<PaymentRequest> payments, IEnumerable<TipsRequest>? tips = null)
        {
            try
            {
                return await _httpDelivery.ChangePaymentForDeliveryOrderAsync(organizationId, orderId,
                    payments, tips);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ChangePaymentForDeliveryOrderAsync(organizationId, orderId,
                        payments, tips);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangeDeliveryCommentAsync(Guid organizationId, Guid orderId, string comment)
        {
            try
            {
                return await _httpDelivery.ChangeDeliveryCommentAsync(organizationId, orderId, comment);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ChangeDeliveryCommentAsync(organizationId, orderId, comment);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> PrintDeliveryBillAsync(Guid organizationId, Guid orderId)
        {
            try
            {
                return await _httpDelivery.PrintDeliveryBillAsync(organizationId, orderId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.PrintDeliveryBillAsync(organizationId, orderId);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ConfirmDeliveryAsync(Guid organizationId, Guid orderId)
        {
            try
            {
                return await _httpDelivery.ConfirmDeliveryAsync(organizationId, orderId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.ConfirmDeliveryAsync(organizationId, orderId);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> CancelDeliveryConfirmationAsync(Guid organizationId, Guid orderId)
        {
            try
            {
                return await _httpDelivery.CancelDeliveryConfirmationAsync(organizationId, orderId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.CancelDeliveryConfirmationAsync(organizationId, orderId);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> AssignOrChangeDeliveryOrderOperatorAsync(Guid organizationId, Guid orderId,
            Guid operatorId)
        {
            try
            {
                return await _httpDelivery.AssignOrChangeDeliveryOrderOperatorAsync(organizationId, orderId,
                    operatorId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.AssignOrChangeDeliveryOrderOperatorAsync(organizationId, orderId,
                        operatorId);
                }

                throw e;
            }
        }

        #endregion

        #region Deliveries: Retrieve https://api-ru.iiko.services/#tag/Deliveries:-Retrieve

        public async Task<OrderInfoWithOperation> RetrieveDeliveryOrdersByIdsAsync(Guid organizationId,
            IEnumerable<Guid>? orderIds = null, IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? posOrderIds = null)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryOrdersByIdsAsync(organizationId, orderIds, sourceKeys,
                    posOrderIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryOrdersByIdsAsync(organizationId, orderIds, sourceKeys,
                        posOrderIds);
                }

                throw e;
            }
        }

        public async Task<RevisionOrderInfo> RetrieveDeliveryOrdersByStatusesAndDatesAsync(IEnumerable<Guid> organizationIds,
            DateTime deliveryDateFrom, DateTime? deliveryDateTo = null, IEnumerable<SimpleDeliveryStatus>? statuses = null,
            IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryOrdersByStatusesAndDatesAsync(organizationIds, deliveryDateFrom,
                    deliveryDateTo, statuses, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryOrdersByStatusesAndDatesAsync(organizationIds, deliveryDateFrom,
                        deliveryDateTo, statuses, sourceKeys);
                }

                throw e;
            }
        }

        public async Task<RevisionOrderInfo> RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(long startRevision,
            IEnumerable<Guid> organizationIds, IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(startRevision,
                    organizationIds, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryOrdersChangedFromTimeRevisionAsync(startRevision,
                        organizationIds, sourceKeys);
                }

                throw e;
            }
        }

        public async Task<RevisionOrderInfo> RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(IEnumerable<Guid> organizationIds,
            string? phone = null, DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, long? startRevision = null,
            IEnumerable<string>? sourceKeys = null, int? rowsCount = null)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(organizationIds, phone,
                    deliveryDateFrom, deliveryDateTo, startRevision, sourceKeys, rowsCount);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryOrdersByPhoneAndDatesAndRevisionAsync(organizationIds, phone,
                        deliveryDateFrom, deliveryDateTo, startRevision, sourceKeys, rowsCount);
                }

                throw e;
            }
        }

        public async Task<RevisionOrderInfo> RetrieveDeliveryOrdersByAdditionalFiltersAsync(IEnumerable<Guid> organizationIds,
            SortProperty sortProperty, SortDirection sortDirection, IEnumerable<Guid>? terminalGroupIds = null,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, IEnumerable<DeliveryStatus>? statuses = null,
            bool? hasProblem = null, OrderServiceType? orderServiceType = null, string? searchText = null,
            int? timeToCookingErrorTimeout = null, int? cookingTimeout = null, int? rowsCount = null,
            IEnumerable<string>? sourceKeys = null, IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryOrdersByAdditionalFiltersAsync(organizationIds, sortProperty,
                    sortDirection, terminalGroupIds, deliveryDateFrom, deliveryDateTo, statuses, hasProblem, orderServiceType,
                    searchText, timeToCookingErrorTimeout, cookingTimeout, rowsCount, sourceKeys, orderIds, posOrderIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryOrdersByAdditionalFiltersAsync(organizationIds, sortProperty,
                        sortDirection, terminalGroupIds, deliveryDateFrom, deliveryDateTo, statuses, hasProblem, orderServiceType,
                        searchText, timeToCookingErrorTimeout, cookingTimeout, rowsCount, sourceKeys, orderIds, posOrderIds);
                }

                throw e;
            }
        }

        #endregion

        #region Addresses https://api-ru.iiko.services/#tag/Addresses

        public async Task<RegionWithOperation> RetrieveRegionsAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpDelivery.RetrieveRegionsAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveRegionsAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<CitiesWithOperation> RetrieveCitiesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpDelivery.RetrieveCitiesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveCitiesAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<StreetsWithOperation> RetrieveStreetsByCityAsync(Guid organizationId, Guid cityId)
        {
            try
            {
                return await _httpDelivery.RetrieveStreetsByCityAsync(organizationId, cityId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveStreetsByCityAsync(organizationId, cityId);
                }

                throw e;
            }
        }

        #endregion

        #region Delivery restrictions https://api-ru.iiko.services/#tag/Delivery-restrictions

        public async Task<DeliveryRestrictionsWithOperation> RetrieveDeliveryRestrictionsAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpDelivery.RetrieveDeliveryRestrictionsAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveDeliveryRestrictionsAsync(organizationIds);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> UpdateDeliveryRestrictionsAsync(Guid organizationId, int deliveryGeocodeServiceType,
            long defaultDeliveryDurationInMinutes, long defaultSelfServiceDurationInMinutes, bool useSameDeliveryDuration,
            bool useSameMinSum, bool useSameWorkTimeInterval, bool useSameRestrictionsOnAllWeek,
            IEnumerable<DeliveryRestrictionItemRequest> restrictions, IEnumerable<DeliveryZoneRequest> deliveryZones,
            bool rejectOnGeocodingError, bool addDeliveryServiceCost, bool useSameDeliveryServiceProduct,
            bool useExternalAssignationService, bool frontTrustsCallCenterCheck, bool requireExactAddressForGeocoding,
            int zonesMode, bool autoAssignExternalDeliveries, int actionOnValidationRejection, string? deliveryRegionsMapUrl = null,
            double? defaultMinSum = null, int? defaultFrom = null, int? defaultTo = null, Guid? defaultDeliveryServiceProductId = null,
            string? externalAssignationServiceUrl = null)
        {
            try
            {
                return await _httpDelivery.UpdateDeliveryRestrictionsAsync(organizationId, deliveryGeocodeServiceType,
                    defaultDeliveryDurationInMinutes, defaultSelfServiceDurationInMinutes, useSameDeliveryDuration,
                    useSameMinSum, useSameWorkTimeInterval, useSameRestrictionsOnAllWeek, restrictions, deliveryZones,
                    rejectOnGeocodingError, addDeliveryServiceCost, useSameDeliveryServiceProduct, useExternalAssignationService,
                    frontTrustsCallCenterCheck, requireExactAddressForGeocoding, zonesMode, autoAssignExternalDeliveries,
                    actionOnValidationRejection, deliveryRegionsMapUrl, defaultMinSum, defaultFrom, defaultTo,
                    defaultDeliveryServiceProductId, externalAssignationServiceUrl);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.UpdateDeliveryRestrictionsAsync(organizationId, deliveryGeocodeServiceType,
                        defaultDeliveryDurationInMinutes, defaultSelfServiceDurationInMinutes, useSameDeliveryDuration,
                        useSameMinSum, useSameWorkTimeInterval, useSameRestrictionsOnAllWeek, restrictions, deliveryZones,
                        rejectOnGeocodingError, addDeliveryServiceCost, useSameDeliveryServiceProduct, useExternalAssignationService,
                        frontTrustsCallCenterCheck, requireExactAddressForGeocoding, zonesMode, autoAssignExternalDeliveries,
                        actionOnValidationRejection, deliveryRegionsMapUrl, defaultMinSum, defaultFrom, defaultTo,
                        defaultDeliveryServiceProductId, externalAssignationServiceUrl);
                }

                throw e;
            }
        }

        public async Task<SuitableTerminalGroupsWithOperation> GetSuitableTerminalGroupsForDeliveryRestrictionsAsync(
            IEnumerable<Guid> organizationIds, bool isCourierDelivery, DeliveryAddressRequest? deliveryAddress = null,
            Coordinate? orderLocation = null, IEnumerable<RestrictionsOrderItem>? orderItems = null,
            DateTime? deliveryDate = null, double? deliverySum = null, double? discountSum = null)
        {
            try
            {
                return await _httpDelivery.GetSuitableTerminalGroupsForDeliveryRestrictionsAsync(organizationIds,
                    isCourierDelivery, deliveryAddress, orderLocation, orderItems, deliveryDate, deliverySum,
                    discountSum);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.GetSuitableTerminalGroupsForDeliveryRestrictionsAsync(organizationIds,
                        isCourierDelivery, deliveryAddress, orderLocation, orderItems, deliveryDate, deliverySum,
                        discountSum);
                }

                throw e;
            }
        }

        #endregion

        #region Marketing sources https://api-ru.iiko.services/#tag/Marketing-sources

        public async Task<MarketingSourceWithOperation> RetrieveMarketingSourcesAsync(IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpDelivery.RetrieveMarketingSourcesAsync(organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveMarketingSourcesAsync(organizationIds);
                }

                throw e;
            }
        }

        #endregion

        #region Drafts https://api-ru.iiko.services/#tag/Drafts

        public async Task<OrderDraftWithOperation> RetrieveOrderDraftByIdAsync(Guid organizationId, Guid orderId,
            Guid employeeId)
        {
            try
            {
                return await _httpDelivery.RetrieveOrderDraftByIdAsync(organizationId, orderId, employeeId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveOrderDraftByIdAsync(organizationId, orderId, employeeId);
                }

                throw e;
            }
        }

        public async Task<OrderDraftsListWithOperation> RetrieveOrderDraftsByParametersAsync(IEnumerable<Guid> organizationIds,
            DateTime? deliveryDateFrom = null, DateTime? deliveryDateTo = null, string? phone = null, int? limit = null,
            int? offset = null, IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpDelivery.RetrieveOrderDraftsByParametersAsync(organizationIds, deliveryDateFrom,
                    deliveryDateTo, phone, limit, offset, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.RetrieveOrderDraftsByParametersAsync(organizationIds, deliveryDateFrom,
                        deliveryDateTo, phone, limit, offset, sourceKeys);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> StoreOrderDraftChangesToDbAsync(Guid organizationId, DeliveryOrderRequest order)
        {
            try
            {
                return await _httpDelivery.StoreOrderDraftChangesToDbAsync(organizationId, order);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.StoreOrderDraftChangesToDbAsync(organizationId, order);
                }

                throw e;
            }
        }

        public async Task<DeliveryOrderWithOperationInfoResponse> AdmitOrderDraftChangesAndSendThemToFrontAsync(Guid organizationId,
            Guid orderId, Guid? terminalGroupId = null, OrderCreationSettings? createOrderSettings = null)
        {
            try
            {
                return await _httpDelivery.AdmitOrderDraftChangesAndSendThemToFrontAsync(organizationId, orderId, terminalGroupId,
                    createOrderSettings);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpDelivery.AdmitOrderDraftChangesAndSendThemToFrontAsync(organizationId, orderId, terminalGroupId,
                        createOrderSettings);
                }

                throw e;
            }
        }

        #endregion

        #endregion

        #region Orders

        #region Orders https://api-ru.iiko.services/#tag/Orders

        public async Task<TableOrderWithOperationInfo> CreateTableOrderAsync(Guid organizationId, Guid terminalGroupId,
            TableOrder? order = null, OrderCreationSettings? createOrderSettings = null)
        {
            try
            {
                return await _httpOrders.CreateTableOrderAsync(organizationId, terminalGroupId, order, createOrderSettings);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.CreateTableOrderAsync(organizationId, terminalGroupId, order,
                        createOrderSettings);
                }

                throw e;
            }
        }

        public async Task<OrdersWithOperationInfo> RetrieveTableOrdersByIdAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid>? orderIds = null, IEnumerable<Guid>? posOrderIds = null, IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpOrders.RetrieveTableOrdersByIdAsync(organizationIds, orderIds, posOrderIds, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.RetrieveTableOrdersByIdAsync(organizationIds, orderIds, posOrderIds, sourceKeys);
                }

                throw e;
            }
        }

        public async Task<OrdersWithOperationInfo> RetrieveTableOrdersByTablesAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> tableIds, IEnumerable<OrderStatus>? statuses = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpOrders.RetrieveTableOrdersByTablesAsync(organizationIds, tableIds, statuses,
                    dateFrom, dateTo, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.RetrieveTableOrdersByTablesAsync(organizationIds, tableIds, statuses,
                        dateFrom, dateTo, sourceKeys);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> AddTableOrderItemsAsync(Guid organizationId, Guid orderId, IEnumerable<OrderItemRequest> items,
            IEnumerable<ComboRequest> combos)
        {
            try
            {
                return await _httpOrders.AddTableOrderItemsAsync(organizationId, orderId, items, combos);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.AddTableOrderItemsAsync(organizationId, orderId, items, combos);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> CloseTableOrderAsync(Guid organizationId, Guid orderId,
            ChequeAdditionalInfo? chequeAdditionalInfo = null)
        {
            try
            {
                return await _httpOrders.CloseTableOrderAsync(organizationId, orderId,
                    chequeAdditionalInfo);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.CloseTableOrderAsync(organizationId, orderId,
                        chequeAdditionalInfo);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> ChangePaymentsForTableOrderAsync(Guid organizationId, Guid orderId,
            IEnumerable<PaymentRequest> payments, IEnumerable<TipsRequest>? tips = null)
        {
            try
            {
                return await _httpOrders.ChangePaymentsForTableOrderAsync(organizationId, orderId,
                    payments, tips);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.ChangePaymentsForTableOrderAsync(organizationId, orderId,
                        payments, tips);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> InitTableOrdersByTablesAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> tableIds)
        {
            try
            {
                return await _httpOrders.InitTableOrdersByTablesAsync(organizationId, terminalGroupId,
                    tableIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.InitTableOrdersByTablesAsync(organizationId, terminalGroupId,
                        tableIds);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> InitTableOrdersByPOSOrdersAsync(Guid organizationId, Guid terminalGroupId,
            IEnumerable<Guid> posOrderIds)
        {
            try
            {
                return await _httpOrders.InitTableOrdersByPOSOrdersAsync(organizationId, terminalGroupId,
                    posOrderIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.InitTableOrdersByPOSOrdersAsync(organizationId, terminalGroupId,
                        posOrderIds);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> AddCustomerToTableOrderAsync(Guid organizationId, Guid orderId, CustomerRequest customer)
        {
            try
            {
                return await _httpOrders.AddCustomerToTableOrderAsync(organizationId, orderId, customer);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpOrders.AddCustomerToTableOrderAsync(organizationId, orderId, customer);
                }

                throw e;
            }
        }

        #endregion

        #endregion

        #region Reserves

        #region Banquets/reserves https://api-ru.iiko.services/#tag/Banquetsreserves

        public async Task<OrganizationInfo> RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid>? organizationIds = null, bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            try
            {
                return await _httpReserves.RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
                    organizationIds, returnAdditionalInfo, includeDisabled);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
                        organizationIds, returnAdditionalInfo, includeDisabled);
                }

                throw e;
            }
        }

        public async Task<DeliveryTerminalGroupInfo> RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> organizationIds)
        {
            try
            {
                return await _httpReserves.RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
                    organizationIds);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
                        organizationIds);
                }

                throw e;
            }
        }

        public async Task<RestaurantSectionsWithOperation> RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> terminalGroupIds, bool returnSchema = false, long? revision = null)
        {
            try
            {
                return await _httpReserves.RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
                    terminalGroupIds, returnSchema, revision);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
                        terminalGroupIds, returnSchema, revision);
                }

                throw e;
            }
        }

        public async Task<ReservesWithOperation> RetrieveReservesForPassedRestaurantSectionsAsync(
            IEnumerable<Guid> restaurantSectionIds, DateTime dateFrom, DateTime? dateTo = null)
        {
            try
            {
                return await _httpReserves.RetrieveReservesForPassedRestaurantSectionsAsync(
                    restaurantSectionIds, dateFrom, dateTo);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.RetrieveReservesForPassedRestaurantSectionsAsync(
                        restaurantSectionIds, dateFrom, dateTo);
                }

                throw e;
            }
        }

        public async Task<BanquetWithOperation> CreateReserveAsync(Guid organizationId, Guid terminalGroupId,
            CustomerOfDeliveryRequest customer, string phone, long durationInMinutes, bool shouldRemind,
            IEnumerable<Guid> tableIds, DateTime estimatedStartTime, Guid? id = null, string? externalNumber = null,
            ReserveOrder? order = null, string? comment = null, int? transportToFrontTimeout = null,
            GuestDetailsRequest? guests = null)
        {
            try
            {
                return await _httpReserves.CreateReserveAsync(organizationId, terminalGroupId, customer,
                    phone, durationInMinutes, shouldRemind, tableIds, estimatedStartTime, id, externalNumber,
                    order, comment, transportToFrontTimeout, guests);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.CreateReserveAsync(organizationId, terminalGroupId, customer,
                        phone, durationInMinutes, shouldRemind, tableIds, estimatedStartTime, id, externalNumber,
                        order, comment, transportToFrontTimeout, guests);
                }

                throw e;
            }
        }

        public async Task<ReservesWithOperation> RetrieveReservesStatusesByIdsAsync(Guid organizationId,
            IEnumerable<Guid> reserveIds, IEnumerable<string>? sourceKeys = null)
        {
            try
            {
                return await _httpReserves.RetrieveReservesStatusesByIdsAsync(organizationId,
                    reserveIds, sourceKeys);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpReserves.RetrieveReservesStatusesByIdsAsync(organizationId,
                        reserveIds, sourceKeys);
                }

                throw e;
            }
        }

        #endregion

        #endregion

        #region Webhooks

        #region Webhooks https://api-ru.iiko.services/#tag/Webhooks

        public async Task<WebhookSettings> GetWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId)
        {
            try
            {
                return await _httpWebhooks.GetWebhooksSettingsForSpecifiedOrganizationAsync(organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpWebhooks.GetWebhooksSettingsForSpecifiedOrganizationAsync(organizationId);
                }

                throw e;
            }
        }

        public async Task<OperationInfo> UpdateWebhooksSettingsForSpecifiedOrganizationAsync(Guid organizationId,
            string webHooksUri, string? authToken = null, Filter? webHooksFilter = null)
        {
            try
            {
                return await _httpWebhooks.UpdateWebhooksSettingsForSpecifiedOrganizationAsync(organizationId,
                    webHooksUri, authToken, webHooksFilter);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpWebhooks.UpdateWebhooksSettingsForSpecifiedOrganizationAsync(organizationId,
                        webHooksUri, authToken, webHooksFilter);
                }

                throw e;
            }
        }

        #endregion

        #endregion

        #region Loyalty And Discounts

        #region Discounts and promotions https://api-ru.iiko.services/#tag/Discounts-and-promotions

        public async Task<CheckinInfo> CalculateCheckinAsync(DeliveryOrderRequest order, Guid organizationId, string? coupon = null,
            Guid? referrerId = null, Guid? terminalGroupId = null, IEnumerable<DynamicDiscount>? dynamicDiscounts = null,
            IEnumerable<Guid>? availablePaymentMarketingCampaignIds = null, IEnumerable<Guid>? applicableManualConditions = null)
        {
            try
            {
                return await _httpLoyalty.CalculateCheckinAsync(order, organizationId, coupon, referrerId, terminalGroupId,
                    dynamicDiscounts, availablePaymentMarketingCampaignIds, applicableManualConditions);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.CalculateCheckinAsync(order, organizationId, coupon, referrerId, terminalGroupId,
                        dynamicDiscounts, availablePaymentMarketingCampaignIds, applicableManualConditions);
                }

                throw e;
            }
        }

        public async Task<ManualConditionInfos> GetManualConditionsAsync(Guid organizationId)
        {
            try
            {
                return await _httpLoyalty.GetManualConditionsAsync(organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetManualConditionsAsync(organizationId);
                }

                throw e;
            }
        }

        public async Task<ProgramInfos> GetProgramsAsync(Guid organizationId, bool? WithoutMarketingCampaigns = null)
        {
            try
            {
                return await _httpLoyalty.GetProgramsAsync(organizationId, WithoutMarketingCampaigns);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetProgramsAsync(organizationId, WithoutMarketingCampaigns);
                }

                throw e;
            }
        }

        public async Task<CouponInfos> GetCouponInfoAsync(Guid organizationId, string? number = null, string? series = null)
        {
            try
            {
                return await _httpLoyalty.GetCouponInfoAsync(organizationId, number, series);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCouponInfoAsync(organizationId, number, series);
                }

                throw e;
            }
        }

        public async Task<SeriesWithNotActivatedCouponInfos> GetCouponSeriesWithNonActivatedCouponsAsync(Guid organizationId)
        {
            try
            {
                return await _httpLoyalty.GetCouponSeriesWithNonActivatedCouponsAsync(organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCouponSeriesWithNonActivatedCouponsAsync(organizationId);
                }

                throw e;
            }
        }

        public async Task<NotActivatedCouponInfos> GetNonActivatedCouponsAsync(Guid organizationId, string? series = null,
            int? pageSize = null, int? page = null)
        {
            try
            {
                return await _httpLoyalty.GetNonActivatedCouponsAsync(organizationId, series, pageSize, page);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetNonActivatedCouponsAsync(organizationId, series, pageSize, page);
                }

                throw e;
            }
        }

        #endregion

        #region Customer categories https://api-ru.iiko.services/#tag/Customer-categories

        public async Task<CustomerCategoryInfos> GetCustomerCategoriesAsync(Guid organizationId)
        {
            try
            {
                return await _httpLoyalty.GetCustomerCategoriesAsync(organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerCategoriesAsync(organizationId);
                }

                throw e;
            }
        }

        public async Task AddCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.AddCategoryForCustomerAsync(customerId, categoryId, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.AddCategoryForCustomerAsync(customerId, categoryId, organizationId);
                    return;
                }

                throw e;
            }
        }

        public async Task RemoveCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.RemoveCategoryForCustomerAsync(customerId, categoryId, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.RemoveCategoryForCustomerAsync(customerId, categoryId, organizationId);
                    return;
                }

                throw e;
            }
        }

        #endregion

        #region Customers https://api-ru.iiko.services/#tag/Customers

        public async Task<CustomerInfo> GetCustomerInfoByCardNumberAsync(Guid organizationId, string cardNumber)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoByCardNumberAsync(organizationId, cardNumber);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoByCardNumberAsync(organizationId, cardNumber);
                }

                throw e;
            }
        }

        public async Task<CustomerInfo> GetCustomerInfoByCardTrackAsync(Guid organizationId, string cardTrack)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoByCardTrackAsync(organizationId, cardTrack);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoByCardTrackAsync(organizationId, cardTrack);
                }

                throw e;
            }
        }

        public async Task<CustomerInfo> GetCustomerInfoByEmailAsync(Guid organizationId, string email)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoByEmailAsync(organizationId, email);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoByEmailAsync(organizationId, email);
                }

                throw e;
            }
        }

        public async Task<CustomerInfo> GetCustomerInfoByIdAsync(Guid organizationId, Guid id)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoByIdAsync(organizationId, id);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoByIdAsync(organizationId, id);
                }

                throw e;
            }
        }

        public async Task<CustomerInfo> GetCustomerInfoByPhoneAsync(Guid organizationId, string phone)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoByPhoneAsync(organizationId, phone);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoByPhoneAsync(organizationId, phone);
                }

                throw e;
            }
        }

        public async Task<CustomerInfo> GetCustomerInfoBySpecifiedCriterionAsync(Guid organizationId, SearchCustomerType type,
            Guid? id = null, string? phone = null, string? cardTrack = null, string? cardNumber = null, string? email = null)
        {
            try
            {
                return await _httpLoyalty.GetCustomerInfoBySpecifiedCriterionAsync(organizationId, type, id, phone,
                    cardTrack, cardNumber, email);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.GetCustomerInfoBySpecifiedCriterionAsync(organizationId, type, id, phone,
                        cardTrack, cardNumber, email);
                }

                throw e;
            }
        }

        public async Task<Guid> CreateOrUpdateCustomerAsync(Guid organizationId, Guid? id = null, string? phone = null,
            string? cardTrack = null, string? cardNumber = null, string? name = null, string? middleName = null,
            string? surName = null, DateTime? birthday = null, string? email = null, Gender? sex = null,
            GuestConsentStatus? consentStatus = null, bool? shouldReceivePromoActionsInfo = null, Guid? referrerId = null,
            string? userData = null)
        {
            try
            {
                return await _httpLoyalty.CreateOrUpdateCustomerAsync(organizationId, id, phone, cardTrack, cardNumber,
                    name, middleName, surName, birthday, email, sex, consentStatus, shouldReceivePromoActionsInfo,
                    referrerId, userData);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.CreateOrUpdateCustomerAsync(organizationId, id, phone, cardTrack, cardNumber,
                        name, middleName, surName, birthday, email, sex, consentStatus, shouldReceivePromoActionsInfo,
                        referrerId, userData);
                }

                throw e;
            }
        }

        public async Task AddCardForCustomerAsync(Guid customerId, string cardTrack, string cardNumber, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.AddCardForCustomerAsync(customerId, cardTrack, cardNumber, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.AddCardForCustomerAsync(customerId, cardTrack, cardNumber, organizationId);
                    return;
                }

                throw e;
            }
        }

        public async Task<Guid> AddCustomerToProgramAsync(Guid customerId, Guid programId, Guid organizationId)
        {
            try
            {
                return await _httpLoyalty.AddCustomerToProgramAsync(customerId, programId, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.AddCustomerToProgramAsync(customerId, programId, organizationId);
                }

                throw e;
            }
        }

        public async Task CancelHoldMoneyOfCustomerAsync(Guid transactionId, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.CancelHoldMoneyOfCustomerAsync(transactionId, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.CancelHoldMoneyOfCustomerAsync(transactionId, organizationId);
                    return;
                }

                throw e;
            }
        }

        public async Task DeleteCardForCustomerAsync(Guid customerId, string cardTrack, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.DeleteCardForCustomerAsync(customerId, cardTrack, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.DeleteCardForCustomerAsync(customerId, cardTrack, organizationId);
                    return;
                }

                throw e;
            }
        }

        public async Task<Guid> HoldMoneyOfCustomerAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            Guid? transactionId = null, string? comment = null)
        {
            try
            {
                return await _httpLoyalty.HoldMoneyOfCustomerAsync(customerId, walletId, organizationId, sum,
                    transactionId, comment);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    return await _httpLoyalty.HoldMoneyOfCustomerAsync(customerId, walletId, organizationId, sum,
                        transactionId, comment);
                }

                throw e;
            }
        }

        public async Task RefillCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null)
        {
            try
            {
                await _httpLoyalty.RefillCustomerBalanceAsync(customerId, walletId, organizationId, sum, comment);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.RefillCustomerBalanceAsync(customerId, walletId, organizationId, sum, comment);
                    return;
                }

                throw e;
            }
        }

        public async Task WithdrawCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null)
        {
            try
            {
                await _httpLoyalty.WithdrawCustomerBalanceAsync(customerId, walletId, organizationId, sum, comment);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.WithdrawCustomerBalanceAsync(customerId, walletId, organizationId, sum, comment);
                    return;
                }

                throw e;
            }
        }

        #endregion

        #region Messages https://api-ru.iiko.services/#tag/Messages

        public async Task SendEmailAsync(string receiver, string subject, Guid organizationId, string? body = null)
        {
            try
            {
                await _httpLoyalty.SendEmailAsync(receiver, subject, organizationId, body);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.SendEmailAsync(receiver, subject, organizationId, body);
                    return;
                }

                throw e;
            }
        }

        public async Task SendSmsAsync(string phone, string text, Guid organizationId)
        {
            try
            {
                await _httpLoyalty.SendSmsAsync(phone, text, organizationId);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await UpdateSessionKeyForApiUserAsync();
                    await _httpLoyalty.SendSmsAsync(phone, text, organizationId);
                    return;
                }

                throw e;
            }
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
            _httpOrders.Token = _token;
            _httpReserves.Token = _token;
            _httpWebhooks.Token = _token;
            _httpLoyalty.Token = _token;

            return _token;
        }

        #endregion

        #endregion
    }
}
