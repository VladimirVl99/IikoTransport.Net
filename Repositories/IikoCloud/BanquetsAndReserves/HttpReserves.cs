using IikoTransport.Net.Entities.Requests.BanquetsAndReserves.CreateReserve;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Customers;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves;
using IikoTransport.Net.Entities.Responses.BanquetsAndReserves.RestaurantSections;
using IikoTransport.Net.Entities.Responses.General.Organizations.AvailableOrganizations;
using IikoTransport.Net.Entities.Responses.General.Terminals.GroupsOfDeliveryTerminals;
using Newtonsoft.Json;

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

        #region Banquets/reserves https://api-ru.iiko.services/#tag/Banquetsreserves

        public async Task<OrganizationInfo> RetrieveOrganizationsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid>? organizationIds = null, bool returnAdditionalInfo = false, bool includeDisabled = false)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationIds,
                returnAdditionalInfo,
                includeDisabled
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveOrganizationsForWhichReserveBookingAreAvailableUri,
                body, Token);

            return JsonConvert.DeserializeObject<OrganizationInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<DeliveryTerminalGroupInfo> RetrieveTerminalGroupsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> organizationIds)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationIds
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveTerminalGroupsForWhichReserveBookingAreAvailableUri,
                body, Token);

            return JsonConvert.DeserializeObject<DeliveryTerminalGroupInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<RestaurantSectionsWithOperation> RetrieveRestaurantSectionsForWhichReserveBookingAreAvailableAsync(
            IEnumerable<Guid> terminalGroupIds, bool returnSchema = false, long? revision = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                terminalGroupIds,
                returnSchema,
                revision
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveRestaurantSectionsForWhichReserveBookingAreAvailableUri,
                body, Token);

            return JsonConvert.DeserializeObject<RestaurantSectionsWithOperation>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ReservesWithOperation> RetrieveReservesForPassedRestaurantSectionsAsync(
            IEnumerable<Guid> restaurantSectionIds, DateTime dateFrom, DateTime? dateTo = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                restaurantSectionIds,
                dateFrom = dateFrom.ToCustomerDateFormat(),
                dateTo = dateTo?.ToCustomerDateFormat()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveReservesForPassedRestaurantSectionsUri,
                body, Token);

            return JsonConvert.DeserializeObject<ReservesWithOperation>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<BanquetWithOperation> CreateReserveAsync(Guid organizationId, Guid terminalGroupId,
            Customer customer, string phone, long durationInMinutes, bool shouldRemind, IEnumerable<Guid> tableIds,
            DateTime estimatedStartTime, Guid? id = null, string? externalNumber = null, ReserveOrder? order = null,
            string? comment = null, int? transportToFrontTimeout = null, GuestDetails? guests = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                terminalGroupId,
                customer,
                phone,
                durationInMinutes,
                shouldRemind,
                tableIds,
                estimatedStartTime = estimatedStartTime.ToCustomerDateFormat(),
                id,
                externalNumber,
                order,
                comment,
                transportToFrontTimeout,
                guests
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCreateReserveUri,
                body, Token);

            return JsonConvert.DeserializeObject<BanquetWithOperation>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ReservesWithOperation> RetrieveReservesStatusesByIdsAsync(Guid organizationId,
            IEnumerable<Guid> reserveIds, IEnumerable<string>? sourceKeys = null)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                reserveIds,
                sourceKeys
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultRetrieveReservesStatusesByIdsUri,
                body, Token);

            return JsonConvert.DeserializeObject<ReservesWithOperation>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #endregion
    }
}
