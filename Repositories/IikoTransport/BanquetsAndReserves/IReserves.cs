using IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections;
using IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;

namespace IikoTransport.Net.Repositories.IikoTransport.BanquetsAndReserves
{
    public interface IReserves
    {
        #region Banquets/reserves https://api-ru.iiko.services/#tag/Banquetsreserves

        /// <summary>
        /// Returns all organizations of current account (determined by Authorization request header)
        /// for which banquet/reserve booking are available.
        /// Allowed from version 7.1.5.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1available_organizations/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs which have to be returned.
        /// By default - all organizations from apiLogin.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="returnAdditionalInfo">A sign whether additional information about the organization should be returned
        /// (RMS version, country, restaurantAddress, etc.), or only minimal information should be returned (id and name).</param>
        /// <param name="includeDisabled">Attribute that shows that response contains disabled organizations.</param>
        /// <returns></returns>
        Task<OrganizationInfo> RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid>? organizationIds = null, bool returnAdditionalInfo = false,
            bool includeDisabled = false);

        /// <summary>
        /// Returns all terminal groups of specified organizations, for which banquet/reserve booking are available.
        /// Allowed from version 7.1.5.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1available_terminal_groups/post.
        /// </summary>
        /// <param name="organizationIds">Organizations IDs for which information is requested.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<DeliveryTerminalGroupInfo> RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> organizationIds);

        /// <summary>
        /// Returns all restaurant sections of specified terminal groups, for which banquet/reserve booking are available.
        /// Allowed from version 7.1.5.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1available_restaurant_sections/post.
        /// </summary>
        /// <param name="terminalGroupIds">Collection of terminal group ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="returnSchema">Indicates whether table layout information should be returned.</param>
        /// <param name="revision">Last modified time after.</param>
        /// <returns></returns>
        Task<RestaurantSectionsWithOperation> RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> terminalGroupIds, bool returnSchema = false, long? revision = null);

        /// <summary>
        /// Returns all banquets/reserves for passed restaurant sections.
        /// Allowed from version 7.1.5.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1restaurant_sections_workload/post.
        /// </summary>
        /// <param name="restaurantSectionIds">Collection of restaurant section ID.
        /// Can be obtained by https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections operation.</param>
        /// <param name="dateFrom">Estimated start time (Local for the terminal). Lower limit.</param>
        /// <param name="dateTo">Estimated start time (Local for the terminal). Upper limit.</param>
        /// <returns></returns>
        Task<ReservesWithOperation> RetrieveReservesForPassedRestaurantSectionsAsync(IEnumerable<Guid> restaurantSectionIds,
            DateTime dateFrom, DateTime? dateTo = null);

        /// <summary>
        /// Create banquet/reserve.
        /// Allowed from version 7.1.5.
        /// This method is a command. Use https://api-ru.iiko.services/api/1/commands/status method to get the progress status.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1create/post.
        /// </summary>
        /// <param name="organizationId">Organization ID of a new banquet/reserve.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="terminalGroupId">Front group ID an banquet/reserve must be sent to.
        /// Can be obtained by https://api-ru.iiko.services/api/1/terminal_groups operation.</param>
        /// <param name="customer">Customer.</param>
        /// <param name="phone">Telephone number. Must begin with symbol "+" and must be at least 8 digits.</param>
        /// <param name="durationInMinutes">Estimated banquet duration.</param>
        /// <param name="shouldRemind">Whether to remind staff to prepare table beforehand.</param>
        /// <param name="tableIds">Reserved tables.</param>
        /// <param name="estimatedStartTime">Estimated time when reserve will be closed or banquet will be started
        /// (Local for the terminal). Reservation can be made up to 90 days prior to the date.</param>
        /// <param name="id">Banquet/reserve ID. Must be unique.</param>
        /// <param name="externalNumber">[ 0 .. 50 ] characters. Banquet/reserve external number.
        /// Allowed from version 8.0.6.</param>
        /// <param name="order">Order. Used only at a banquet.</param>
        /// <param name="comment">Banquet/reserve comment.</param>
        /// <param name="transportToFrontTimeout">Timeout in seconds that specifies how much time is given for
        /// banquet/reserve to reach iikoFront. After this time, banquet/reserve is nullified if iikoFront
        /// doesn't take it. By default - 8 seconds.</param>
        /// <param name="guests">Guests information.</param>
        /// <returns></returns>
        Task<BanquetWithOperation> CreateReserveAsync(Guid organizationId, Guid terminalGroupId, Customer customer, string phone,
            long durationInMinutes, bool shouldRemind, IEnumerable<Guid> tableIds, DateTime estimatedStartTime, Guid? id = null,
            string? externalNumber = null, ReserveOrder? order = null, string? comment = null, int? transportToFrontTimeout = null,
            GuestDetails? guests = null);

        /// <summary>
        /// Retrieve banquets/reserves statuses by IDs.
        /// Allowed from version 7.1.5.
        /// Source: https://api-ru.iiko.services/#tag/Banquetsreserves/paths/~1api~11~1reserve~1status_by_id/post.
        /// </summary>
        /// <param name="organizationId">Organization ID for which an order search will be performed.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="reserveIds">IDs of banquets/reserves information on which is required.</param>
        /// <param name="sourceKeys">Source keys.</param>
        /// <returns></returns>
        Task<ReservesWithOperation> RetrieveReservesStatusesByIdsAsync(Guid organizationId, IEnumerable<Guid> reserveIds,
            IEnumerable<string>? sourceKeys = null);

        #endregion
    }
}
