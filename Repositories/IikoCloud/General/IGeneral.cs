using IikoTransport.Net.Entities.Requests.General.Notifications;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Delivery;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.DiscountsAndSurcharges;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Order;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.Payments;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.RemovalTypes;
using IikoTransport.Net.Entities.Responses.General.Dictionaries.TipsTypes;
using IikoTransport.Net.Entities.Responses.General.Employees.Couriers;
using IikoTransport.Net.Entities.Responses.General.Employees;
using IikoTransport.Net.Entities.Responses.General.Menu.Combo;
using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature.ExternalMenus;
using IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature;
using IikoTransport.Net.Entities.Responses.General.Menu.OutOfStockItems;
using IikoTransport.Net.Entities.Responses.General.Operations;
using IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations;
using IikoTransport.Net.Entities.Responses.General.Terminals.AvailabilityOfGroupOfTerminals;
using IikoTransport.Net.Entities.Responses.General.Terminals.AwakeTerminalGroups;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;

namespace IikoTransport.Net.Repositories.IikoCloud.General
{
    /// <summary>
    /// General methods of iikoTransport.
    /// </summary>
    public interface IGeneral
    {
        #region Authorization https://api-ru.iiko.services/#tag/Authorization

        /// <summary>
        /// Retrieve session key for API user.
        /// Source: https://api-ru.iiko.services/#tag/Authorization.
        /// </summary>
        /// <param name="apiLogin">API login. It is set in iikoWeb.</param>
        /// <returns></returns>
        Task<string> RetrieveSessionKeyForApiUserAsync(string apiLogin);

        #endregion

        #region Notifications https://api-ru.iiko.services/#tag/Notifications

        /// <summary>
        /// Send notification to external systems (iikoFront and iikoWeb).
        /// Source: https://api-ru.iiko.services/#tag/Notifications/paths/~1api~11~1notifications~1send/post.
        /// </summary>
        /// <param name="orderSource">Order source.</param>
        /// <param name="orderId">Order ID.</param>
        /// <param name="additionalInfo">Additional info about the problem.</param>
        /// <param name="messageType">Type of message.</param>
        /// <param name="organizationId">Organization UOC Id.</param>
        /// <returns></returns>
        Task SendNotificationToExternalSystemsAsync(string orderSource, Guid orderId,
            string additionalInfo, MessageType messageType, Guid organizationId);

        #endregion

        #region Organizations https://api-ru.iiko.services/#tag/Organizations

        /// <summary>
        /// Returns organizations available to api-login user.
        /// Source: https://api-ru.iiko.services/#tag/Organizations/paths/~1api~11~1organizations/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which have to be returned.
        /// By default - all organizations from apiLogin.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="returnAdditionalInfo">A sign whether additional information about the organization
        /// should be returned (RMS version, country, restaurantAddress, etc.),
        /// or only minimal information should be returned (id and name).</param>
        /// <param name="includeDisabled">Attribute that shows that response contains disabled
        /// organizations.</param>
        /// <returns></returns>
        Task<OrganizationInfo> RetrieveAvailableOrganizationsAsync(IEnumerable<Guid>? organizationIds = null,
            bool returnAdditionalInfo = false, bool includeDisabled = false);

        #endregion

        #region Terminal groups https://api-ru.iiko.services/#tag/Terminal-groups

        /// <summary>
        /// Method that returns information on groups of delivery terminals.
        /// Source: https://api-ru.iiko.services/#tag/Terminal-groups/paths/~1api~11~1terminal_groups/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs for which information is requested.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="includeDisabled">Attribute that shows that response contains disabled terminal groups.</param>
        /// <returns></returns>
        Task<DeliveryTerminalGroupInfo> RetrieveGroupsOfDeliveryTerminalsAsync(IEnumerable<Guid> organizationIds,
            bool includeDisabled = false);

        /// <summary>
        /// Returns information on availability of group of terminals.
        /// Source: https://api-ru.iiko.services/#tag/Terminal-groups/paths/~1api~11~1terminal_groups~1is_alive/post.
        /// </summary>
        /// <param name="organizationIds">Organization IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupIds">List of terminal groups IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <returns></returns>
        Task<AvailabilityTerminalGroupInfo> RetrieveInformationOnAvailabilityOfGroupOfTerminalsAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<Guid> terminalGroupIds);

        /// <summary>
        /// Awake terminal groups from sleep mode.
        /// Source: https://api-ru.iiko.services/#tag/Terminal-groups/paths/~1api~11~1terminal_groups~1awake/post.
        /// </summary>
        /// <param name="organizationIds">Organization IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupIds">List of terminal groups IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <returns></returns>
        Task<AwakeTerminalGroupsResult> AwakeTerminalGroupsFromSleepModeAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<Guid> terminalGroupIds);

        #endregion

        #region Dictionaries https://api-ru.iiko.services/#tag/Dictionaries

        /// <summary>
        /// Delivery cancel causes.
        /// Allowed from version 7.7.1.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1cancel_causes/post.
        /// </summary>
        /// <param name="organizationIds">Organizations ids which delivery cancel causes needs to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<CancelCauseInfo> RetrieveDeliveryCancelCausesAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Order types.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1deliveries~1order_types/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which payment types have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<OrderTypeInfo> RetrieveOrderTypes(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Discounts / surcharges.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1discounts/post.
        /// </summary>
        /// <param name="organizationIds">Organization IDs that require discounts return.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<DiscountInfo> RetrieveDiscountsAndSurchargesAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Payment types.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1payment_types/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which payment types have to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<PaymentInfo> RetrievePaymentTypesAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Removal types (reasons for deletion).
        /// Allowed from version 7.5.3.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1removal_types/post.
        /// </summary>
        /// <param name="organizationIds">Organizations ids which removal types needs to be returned.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<RemovalTypeInfo> RetrieveRemovalTypesAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Get tips tipes for api-login`s rms group.
        /// Allowed from version 7.7.4.
        /// Source: https://api-ru.iiko.services/#tag/Dictionaries/paths/~1api~11~1tips_types/post.
        /// </summary>
        /// <returns></returns>
        Task<TipTypeInfo> RetrieveTipsTipesForRmsGroupAsync();

        #endregion

        #region Menu https://api-ru.iiko.services/#tag/Menu

        /// <summary>
        /// Menu.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1nomenclature/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="startRevision">Initial revision.
        /// Items list will be received only in case there is a newer revision in the database.</param>
        /// <returns></returns>
        Task<MenuInfo> RetrieveMenuAsync(Guid organizationId, long? startRevision = null);

        /// <summary>
        /// External menus with price categories.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~12~1menu/post.
        /// </summary>
        /// <returns></returns>
        Task<ExternalMenuInfo> RetrieveExternalMenusWithPriceCategoriesAsync();

        /// <summary>
        /// Retrieve external menu by ID.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~12~1menu~1by_id/post.
        /// </summary>
        /// <param name="externalMenuId">External menu id.
        /// Can be obtained by https://api-ru.iiko.services/api/2/menu operation.</param>
        /// <param name="organizationIds">Organization IDs.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="priceCategoryId">Price category id.
        /// Can be obtained by https://api-ru.iiko.services/api/2/menu operation.</param>
        /// <param name="version">Version of the result data model.</param>
        /// <returns></returns>
        Task<Menu> RetrieveExternalMenuByIdAsync(string externalMenuId, IEnumerable<Guid> organizationIds,
            string? priceCategoryId = null, int? version = null);

        /// <summary>
        /// Out-of-stock items.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1stop_lists/post.
        /// </summary>
        /// <param name="organizationIds">Organizations for which out-of-stock lists will be requested.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<OutOfStockInfo> RetrieveOutOfStockItemsAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Get all organization's combos.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1combo/post.
        /// </summary>
        /// <param name="extraData">Extra data.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<ComboInfo> RetrieveCombosInfoAsync(bool extraData, Guid organizationId);

        /// <summary>
        /// Make combo price calculation.
        /// Source: https://api-ru.iiko.services/#tag/Menu/paths/~1api~11~1combo~1calculate/post.
        /// </summary>
        /// <param name="items">Items with modifiers included in combo.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<ComboPriceInfo> CalculateComboPriceAsync(IEnumerable<OrderItem> items,
            Guid organizationId);

        #endregion

        #region Operations https://api-ru.iiko.services/#tag/Operations

        /// <summary>
        /// Get status of command.
        /// Source: https://api-ru.iiko.services/#tag/Operations/paths/~1api~11~1commands~1status/post.
        /// </summary>
        /// <param name="organizationId">Organization id which "correlationId" belongs to.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="correlationId">Operation ID obtained from any command supporting operations.</param>
        /// <returns></returns>
        Task<CommandStatus> GetStatusOfCommandAsync(Guid organizationId, Guid correlationId);

        #endregion

        #region Employees https://api-ru.iiko.services/#tag/Employees

        /// <summary>
        /// Method of obtaining drivers' coordinates history.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1locations~1by_time_offset/post.
        /// </summary>
        /// <param name="organizationIds">List of organizations for drivers coordinates
        /// of which will be retrieved.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="offsetInSeconds">Interval in seconds from current server time.
        /// If driver coordinates were recorded in server storage within interval:
        /// ("current server time" - "offsetInSeconds", "current server time"],
        /// driver and their coordinates will be retrieved.</param>
        /// <returns></returns>
        Task<CoordinateHistory> RetrieveCoordinatesHistoryOfDriverAsync(IEnumerable<Guid> organizationIds,
            int? offsetInSeconds = null);

        /// <summary>
        /// Returns list of all employees which are delivery drivers in specified restaurants.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers/post.
        /// </summary>
        /// <param name="organizationIds">List of organizations.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<CouriersInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsAsync(IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Returns list of all employees which are delivery drivers in specified restaurants,
        /// and checks whether each employee has passed role.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1by_role/post.
        /// </summary>
        /// <param name="organizationIds">List of organizations.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="rolesToCheck">Employee's roles for check.</param>
        /// <returns></returns>
        Task<CouriersWithCheckRolesInfo> RetrieveDeliveryDriversInSpecifiedRestaurantsWithCheckRolesAsync(
            IEnumerable<Guid> organizationIds, IEnumerable<string> rolesToCheck);

        /// <summary>
        /// Returns list of all active (courier session is opened) courier's locations which are delivery
        /// drivers in specified restaurant and are clocked in on specified delivery terminal.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1active_location~1by_terminal/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">iikoFront terminals group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <returns></returns>
        Task<ActiveCouriersInfo> RetrieveActiveDeliveryDriversInSpecifiedRestaurantAndOnSpecifiedTerminalAsync(
            Guid organizationId, Guid terminalGroupId);

        /// <summary>
        /// Returns list of all active (courier session is opened) courier's locations which are delivery drivers in specified restaurants.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1couriers~1active_location/post.
        /// </summary>
        /// <param name="organizationIds">List of organizations.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<ActiveCouriersInfo> RetrieveActiveLocationsOfCourierInSpecifiedRestaurantsAsync(
            IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Returns employee info.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="id">Employee ID.</param>
        /// <returns></returns>
        Task<EmployeeInfo> RetrieveEmployeeInfoAsync(Guid organizationId, Guid id);

        /// <summary>
        /// Open personal session.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1shift~1clockin/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Delivery group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="employeeId">Employee ID.</param>
        /// <param name="roleId">Employee role ID.
        /// Must be null if the restaurant doesn't use roles, otherwise not-null role must be specified.</param>
        /// <returns></returns>
        Task<PersonalSessionActionResult> OpenPersonalSessionAsync(Guid organizationId,
            Guid terminalGroupId, Guid employeeId, Guid? roleId = null);

        /// <summary>
        /// Close personal session.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1shift~1clockout/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Delivery group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="employeeId">Employee ID.</param>
        /// <returns></returns>
        Task<PersonalSessionActionResult> ClosePersonalSessionAsync(Guid organizationId, Guid terminalGroupId, Guid employeeId);

        /// <summary>
        /// Check if personal session is open.
        /// Source: https://api-ru.iiko.services/#tag/Employees/paths/~1api~11~1employees~1shift~1is_open/post.
        /// </summary>
        /// <param name="organizationId">Organization ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Delivery group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="employeeId">Employee ID.</param>
        /// <returns></returns>
        Task<PersonalSessionInfo> CheckForOpenPersonalShiftAsync(Guid organizationId, Guid terminalGroupId, Guid employeeId);

        #endregion
    }
}
