using IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections;
using IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;

namespace IikoTransport.Net.Repositories.IikoCloud.BanquetsAndReserves
{
    public class HttpReserves : HttpHelper, IReserves
    {
        #region Fields

        private const string DefaultRetrieveOrganizationsForWhichReserveBookingAreAvailableUri
            = "https://api-ru.iiko.services/api/1/reserve/available_organizations";
        private const string DefaultRetrieveTerminalGroupsForWhichReserveBookingAreAvailableUri
            = "https://api-ru.iiko.services/api/1/reserve/available_terminal_groups";
        private const string DefaultRetrieveRestaurantSectionsForWhichReserveBookingAreAvailableUri
            = "https://api-ru.iiko.services/api/1/reserve/available_restaurant_sections";
        private const string DefaultRetrieveReservesForPassedRestaurantSectionsUri
            = "https://api-ru.iiko.services/api/1/reserve/restaurant_sections_workload";
        private const string DefaultCreateReserveUri = "https://api-ru.iiko.services/api/1/reserve/create";
        private const string DefaultRetrieveReservesStatusesByIdsUri
            = "https://api-ru.iiko.services/api/1/reserve/status_by_id";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpReserves(string token) => Token = token;

        #endregion

        #region Methods



        #endregion

        public Task<BanquetWithOperation> CreateReserveAsync(Guid organizationId, Guid terminalGroupId,
            Customer customer, string phone, long durationInMinutes, bool shouldRemind, IEnumerable<Guid> tableIds,
            DateTime estimatedStartTime, Guid? id = null, string? externalNumber = null, ReserveOrder? order = null,
            string? comment = null, int? transportToFrontTimeout = null, GuestDetails? guests = null)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationInfo> RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(IEnumerable<Guid>? organizationIds = null, bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            throw new NotImplementedException();
        }

        public Task<ReservesWithOperation> RetrieveReservesForPassedRestaurantSectionsAsync(IEnumerable<Guid> restaurantSectionIds, DateTime dateFrom, DateTime? dateTo = null)
        {
            throw new NotImplementedException();
        }

        public Task<ReservesWithOperation> RetrieveReservesStatusesByIdsAsync(Guid organizationId, IEnumerable<Guid> reserveIds, IEnumerable<string>? sourceKeys = null)
        {
            throw new NotImplementedException();
        }

        public Task<RestaurantSectionsWithOperation> RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(IEnumerable<Guid> terminalGroupIds, bool returnSchema = false, long? revision = null)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryTerminalGroupInfo> RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(IEnumerable<Guid> organizationIds)
        {
            throw new NotImplementedException();
        }
    }
}
