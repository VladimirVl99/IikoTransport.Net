using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.General.Notifications;
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
using Newtonsoft.Json;
using IikoTransport.Net.Entities.Responses.General.Authorizations;

namespace IikoTransport.Net.Repositories.IikoCloud.General
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpGeneral : HttpHelper, IGeneral
    {
        #region Fields

        private const string DefaultSessionKeyRetrieveUri = "https://api-ru.iiko.services/api/1/access_token";
        private const string DefaultSendNotificationToIikoFrontUri = "https://api-ru.iiko.services/api/1/notifications/send";
        private const string DefaultOrganizationsRetrieveUri = "https://api-ru.iiko.services/api/1/organizations";
        private const string DefaultGroupsOfDeliveryTerminalsRetrieveUri = "https://api-ru.iiko.services/api/1/terminal_groups";
        private const string DefaultAvailabilityOfGroupOfTerminalsRetrieveUri = "https://api-ru.iiko.services/api/1/terminal_groups/is_alive";
        private const string DefaultAwakeTerminalGroupsFromSleepModeUri = "https://api-ru.iiko.services/api/1/terminal_groups/awake";
        private const string DefaultDeliveryCancelCausesRetrieveUri = "https://api-ru.iiko.services/api/1/cancel_causes";
        private const string DefaultOrderTypesRetrieveUri = "https://api-ru.iiko.services/api/1/deliveries/order_types";
        private const string DefaultDiscountsRetrieveUri = "https://api-ru.iiko.services/api/1/discounts";
        private const string DefaultPaymentTypesRetrieveUri = "https://api-ru.iiko.services/api/1/payment_types";
        private const string DefaultRemovalTypesRetrieveUri = "https://api-ru.iiko.services/api/1/removal_types";
        private const string DefaultTipsTipesRetrieveUri = "https://api-ru.iiko.services/api/1/tips_types";
        private const string DefaultMenuRetrieveUri = "https://api-ru.iiko.services/api/1/nomenclature";
        private const string DefaultExternalMenusWithPriceCategoriesRetrieveUri = "https://api-ru.iiko.services/api/2/menu";
        private const string DefaultExternalMenuByIdRetrieveUri = "https://api-ru.iiko.services/api/2/menu/by_id";
        private const string DefaultOutOfStockItemsRetrieveUri = "https://api-ru.iiko.services/api/1/stop_lists";
        private const string DefaultCombosInfoRetrieveUri = "https://api-ru.iiko.services/api/1/combo";
        private const string DefaultCalculateComboPriceUri = "https://api-ru.iiko.services/api/1/combo/calculate";
        private const string DefaultStatusOfCommandRetrieveUri = "https://api-ru.iiko.services/api/1/commands/status";
        private const string DefaultCoordinatesHistoryOfDriverRetrieveUri
            = "https://api-ru.iiko.services/api/1/employees/couriers/locations/by_time_offset";
        private const string DefaultDeliveryDriversInSpecifiedRestaurantRetrieveUri
            = "https://api-ru.iiko.services/api/1/employees/couriers";
        private const string DefaultDeliveryDriversInSpecifiedRestaurantAndRolesToCheckRetrieveUri
            = "https://api-ru.iiko.services/api/1/employees/couriers/by_role";
        private const string DefaultActiveLocationsOfCourierWhichAreClockedInOnSpecifiedDeliveryRetrieveUri
            = "https://api-ru.iiko.services/api/1/employees/couriers/active_location/by_terminal";
        private const string DefaultActiveLocationsOfCourierBySpecifiedRestaurantsRetrieveUri
            = "https://api-ru.iiko.services/api/1/employees/couriers/active_location";
        private const string DefaultEmployeeInfoRetrieveUri = "https://api-ru.iiko.services/api/1/employees/info";
        private const string DefaultOpenPersonalSessionUri = "https://api-ru.iiko.services/api/1/employees/shift/clockin";
        private const string DefaultClosePersonalSessionUri = "https://api-ru.iiko.services/api/1/employees/shift/clockout";
        private const string DefaultCheckIfPersonalSessionIsOpenUri = "https://api-ru.iiko.services/api/1/employees/shift/is_open";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpGeneral(string token) => Token = token;

        #endregion

        #region Methods

        #region Authorization https://api-ru.iiko.services/#tag/Authorization

        public async Task<string> RetrieveSessionKeyForApiUserAsync(string apiLogin)
        {
            var body = JsonConvert.SerializeObject(new { apiLogin });
            string responseBody = await SendHttpPostBearerRequestAsync(DefaultSessionKeyRetrieveUri, body);
            var auth = JsonConvert.DeserializeObject<SessionKey>(responseBody);

            return !string.IsNullOrEmpty(auth?.Token)
                ? auth.Token : throw new Exception("The recieved authorization token via http request cannot be empty.");
        }

        #endregion

        #region Notifications https://api-ru.iiko.services/#tag/Notifications

        public async Task SendNotificationToExternalSystemsAsync(string orderSource, Guid orderId,
            string additionalInfo, MessageType messageType, Guid organizationId)
        {
            string body = JsonConvert.SerializeObject(new { orderSource, orderId, additionalInfo, messageType, organizationId });
            await SendHttpPostBearerRequestAsync(DefaultSendNotificationToIikoFrontUri, body, Token);
        }

        #endregion

        #region Organizations https://api-ru.iiko.services/#tag/Organizations

        public async Task<OrganizationInfo> RetrieveAvailableOrganizationsAsync(IEnumerable<Guid>? organizationIds = null,
            bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, returnAdditionalInfo, includeDisabled });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultOrganizationsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<OrganizationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Terminal groups https://api-ru.iiko.services/#tag/Terminal-groups

        public async Task<DeliveryTerminalGroupInfo> RetrieveGroupsOfDeliveryTerminalsAsync(IEnumerable<Guid> organizationIds,
            bool includeDisabled = false)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, includeDisabled });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultGroupsOfDeliveryTerminalsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<DeliveryTerminalGroupInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<AvailabilityTerminalGroupInfo> RetrieveInformationOnAvailabilityOfGroupOfTerminalsAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<Guid> terminalGroupIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, terminalGroupIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultAvailabilityOfGroupOfTerminalsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<AvailabilityTerminalGroupInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<AwakeTerminalGroupsResult> AwakeTerminalGroupsFromSleepModeAsync(IEnumerable<Guid> organizationIds,
            IEnumerable<Guid> terminalGroupIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, terminalGroupIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultAwakeTerminalGroupsFromSleepModeUri, body, Token);

            return JsonConvert.DeserializeObject<AwakeTerminalGroupsResult>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Dictionaries https://api-ru.iiko.services/#tag/Dictionaries

        public async Task<CancelCauseInfo> RetrieveDeliveryCancelCausesAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultDeliveryCancelCausesRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<CancelCauseInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OrderTypeInfo> RetrieveOrderTypes(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultOrderTypesRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<OrderTypeInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<DiscountInfo> RetrieveDiscountsAndSurchargesAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultDiscountsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<DiscountInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<PaymentInfo> RetrievePaymentTypesAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultPaymentTypesRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<PaymentInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<RemovalTypeInfo> RetrieveRemovalTypesAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRemovalTypesRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<RemovalTypeInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<TipTypeInfo> RetrieveTipsTipesForRmsGroupAsync()
        {
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultTipsTipesRetrieveUri, string.Empty, Token);

            return JsonConvert.DeserializeObject<TipTypeInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Menu https://api-ru.iiko.services/#tag/Menu

        public async Task<MenuInfo> RetrieveMenuAsync(Guid organizationId, long? startRevision = null)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, startRevision });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultMenuRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<MenuInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ExternalMenuInfo> RetrieveExternalMenusWithPriceCategoriesAsync()
        {
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultExternalMenusWithPriceCategoriesRetrieveUri,
                string.Empty, Token);

            return JsonConvert.DeserializeObject<ExternalMenuInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<Menu> RetrieveExternalMenuByIdAsync(string externalMenuId, IEnumerable<Guid> organizationIds,
            string? priceCategoryId = null, int? version = null)
        {
            string body = JsonConvert.SerializeObject(new { externalMenuId, organizationIds, priceCategoryId, version });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultExternalMenuByIdRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<Menu>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<OutOfStockInfo> RetrieveOutOfStockItemsAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultOutOfStockItemsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<OutOfStockInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ComboInfo> RetrieveCombosInfoAsync(bool extraData, Guid organizationId)
        {
            string body = JsonConvert.SerializeObject(new { extraData, organizationId });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCombosInfoRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<ComboInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ComboPriceInfo> CalculateComboPriceAsync(IEnumerable<OrderItem> items, Guid organizationId)
        {
            string body = JsonConvert.SerializeObject(new { items, organizationId });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCalculateComboPriceUri, body, Token);

            return JsonConvert.DeserializeObject<ComboPriceInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Operations https://api-ru.iiko.services/#tag/Operations

        public async Task<CommandStatus> GetStatusOfCommandAsync(Guid organizationId, Guid correlationId)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, correlationId });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultStatusOfCommandRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<CommandStatusInfo>(responseBody)?.State
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Employees https://api-ru.iiko.services/#tag/Employees

        public async Task<CoordinateHistory> RetrieveCoordinatesHistoryOfDriverAsync(IEnumerable<Guid> organizationIds,
            int? offsetInSeconds = null)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, offsetInSeconds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCoordinatesHistoryOfDriverRetrieveUri,
                body, Token);

            return JsonConvert.DeserializeObject<CoordinateHistory>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CouriersInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsAsync(IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultDeliveryDriversInSpecifiedRestaurantRetrieveUri,
                body, Token);

            return JsonConvert.DeserializeObject<CouriersInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<PersonalSessionInfo> CheckForOpenPersonalShiftAsync(Guid organizationId, Guid terminalGroupId,
            Guid employeeId)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, terminalGroupId, employeeId });
            var responseBody = await SendHttpPostBearerRequestAsync(
                DefaultCheckIfPersonalSessionIsOpenUri, body, Token);

            return JsonConvert.DeserializeObject<PersonalSessionInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<PersonalSessionActionResult> ClosePersonalSessionAsync(Guid organizationId, Guid terminalGroupId,
            Guid employeeId)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, terminalGroupId, employeeId });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultClosePersonalSessionUri, body, Token);

            return JsonConvert.DeserializeObject<PersonalSessionActionResult>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<PersonalSessionActionResult> OpenPersonalSessionAsync(Guid organizationId,
            Guid terminalGroupId, Guid employeeId, Guid? roleId = null)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, terminalGroupId, employeeId, roleId });
            var responseBody = await SendHttpPostBearerRequestAsync(DefaultOpenPersonalSessionUri, body, Token);

            return JsonConvert.DeserializeObject<PersonalSessionActionResult>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ActiveCouriersInfo> RetrieveActiveDeliveryDriversInSpecifiedRestaurantAndOnSpecifiedTerminalAsync(
            Guid organizationId, Guid terminalGroupId)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, terminalGroupId });
            var responseBody = await SendHttpPostBearerRequestAsync(
                DefaultActiveLocationsOfCourierWhichAreClockedInOnSpecifiedDeliveryRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<ActiveCouriersInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ActiveCouriersInfo> RetrieveActiveLocationsOfCourierInSpecifiedRestaurantsAsync(
            IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds });
            var responseBody = await SendHttpPostBearerRequestAsync(
                DefaultActiveLocationsOfCourierBySpecifiedRestaurantsRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<ActiveCouriersInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CouriersWithCheckRolesInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsWithCheckRolesAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<string> rolesToCheck)
        {
            string body = JsonConvert.SerializeObject(new { organizationIds, rolesToCheck });
            var responseBody = await SendHttpPostBearerRequestAsync(
                DefaultDeliveryDriversInSpecifiedRestaurantAndRolesToCheckRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<CouriersWithCheckRolesInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<EmployeeInfo> RetrieveEmployeeInfoAsync(Guid organizationId, Guid id)
        {
            string body = JsonConvert.SerializeObject(new { organizationId, id });
            var responseBody = await SendHttpPostBearerRequestAsync(
                DefaultEmployeeInfoRetrieveUri, body, Token);

            return JsonConvert.DeserializeObject<EmployeeInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #endregion
    }
}
