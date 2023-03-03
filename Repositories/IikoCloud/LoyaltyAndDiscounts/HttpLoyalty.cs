using IikoTransport.Net.Entities.Common.Customers;
using IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate;
using IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.Customers;
using IikoTransport.Net.Entities.Requests.LoyaltyAndDiscounts.DiscountsAndPromotions;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.CustomerCategories;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.Customers;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Checkin;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Coupons;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.ManualConditions;
using IikoTransport.Net.Entities.Responses.LoyaltyAndDiscounts.DiscountsAndPromotions.Programs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IikoTransport.Net.Repositories.IikoCloud.LoyaltyAndDiscounts
{
    public class HttpLoyalty : HttpHelper, ILoyaltyAndDiscounts
    {
        #region Fields

        private const string DefaultLoyaltyCalculateUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/calculate";
        private const string DefaultManualConditionUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/manual_condition";
        private const string DefaultProgramUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/program";
        private const string DefaultCouponsInfoUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/coupons/info";
        private const string DefaultCouponsSeriesUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/coupons/series";
        private const string DefaultCouponsBySeriesUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/coupons/by_series";
        private const string DefaultCustomerCategoryUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer_category";
        private const string DefaultCustomerCategoryAddUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer_category/add";
        private const string DefaultCustomerCategoryRemoveUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer_category/remove";
        private const string DefaultCustomerInfoUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/info";
        private const string DefaultCustomerCreateOrUpdateUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/create_or_update";
        private const string DefaultCustomerProgramAddUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/program/add";
        private const string DefaultCustomerCardAddUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/card/add";
        private const string DefaultCustomerCardRemoveUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/card/remove";
        private const string DefaultCustomerWalletHoldUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/wallet/hold";
        private const string DefaultCustomerWalletCancelHoldUri
            = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/wallet/cancel_hold";
        private const string DefaultCustomerWalletTopupUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/wallet/topup";
        private const string DefaultCustomerWalletChargeoffUri
            = "https://api-ru.iiko.services/api/1/loyalty/iiko/customer/wallet/chargeoff";
        private const string DefaultMessageSendSmsUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/message/send_sms";
        private const string DefaultMessageSendEmailUri = "https://api-ru.iiko.services/api/1/loyalty/iiko/message/send_email";

        private const string DefaultNullableExceptionMessage = "Fail to convert json response to the object.";
        private const string DefaultFailGuidConvertionMessage = "Fail to convert json result - '{0}' to the Guid format.";

        #endregion

        #region Properties

        public string Token { get; set; }

        #endregion

        #region Constructors

        public HttpLoyalty(string token) => Token = token;

        #endregion

        #region Methods

        #region Discounts and promotions https://api-ru.iiko.services/#tag/Discounts-and-promotions

        public async Task<CheckinInfo> CalculateCheckinAsync(DeliveryOrder order, Guid organizationId, string? coupon = null,
            Guid? referrerId = null, Guid? terminalGroupId = null, IEnumerable<DynamicDiscount>? dynamicDiscounts = null,
            IEnumerable<Guid>? availablePaymentMarketingCampaignIds = null, IEnumerable<Guid>? applicableManualConditions = null,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                order,
                organizationId,
                coupon,
                referrerId,
                terminalGroupId,
                dynamicDiscounts,
                availablePaymentMarketingCampaignIds,
                applicableManualConditions
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultLoyaltyCalculateUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CheckinInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ManualConditionInfos> GetManualConditionsAsync(Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultManualConditionUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<ManualConditionInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<ProgramInfos> GetProgramsAsync(Guid organizationId, bool? WithoutMarketingCampaigns = null,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                WithoutMarketingCampaigns
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultProgramUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<ProgramInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CouponInfos> GetCouponInfoAsync(Guid organizationId, string? number = null, string? series = null,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                number,
                series
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCouponsInfoUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<CouponInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<SeriesWithNotActivatedCouponInfos> GetCouponSeriesWithNonActivatedCouponsAsync(Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCouponsSeriesUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<SeriesWithNotActivatedCouponInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<NotActivatedCouponInfos> GetNonActivatedCouponsAsync(Guid organizationId, string? series = null,
            int? pageSize = null, int? page = null, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                series,
                pageSize,
                page
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCouponsBySeriesUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<NotActivatedCouponInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        #endregion

        #region Customer categories https://api-ru.iiko.services/#tag/Customer-categories

        public async Task<CustomerCategoryInfos> GetCustomerCategoriesAsync(Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerCategoryUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerCategoryInfos>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task AddCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                categoryId,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerCategoryAddUri, body, Token, cancellationToken);
        }

        public async Task RemoveCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                categoryId,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerCategoryRemoveUri, body, Token, cancellationToken);
        }

        #endregion

        #region Customers https://api-ru.iiko.services/#tag/Customers

        public async Task AddCardForCustomerAsync(Guid customerId, string cardTrack, string cardNumber,
            Guid organizationId, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                cardTrack,
                cardNumber,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerCardAddUri, body, Token, cancellationToken);
        }

        public async Task<Guid> AddCustomerToProgramAsync(Guid customerId, Guid programId, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                programId,
                organizationId
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerProgramAddUri, body, Token,
                cancellationToken);

            var result = JsonConvert.DeserializeObject<JToken>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);

            if (!Guid.TryParse(result["userWalletId"]?.ToString(), out var userWalletId))
            {
                throw new Exception(string.Format(DefaultFailGuidConvertionMessage, result["userWalletId"]));
            }

            return userWalletId;
        }

        public async Task CancelHoldMoneyOfCustomerAsync(Guid transactionId, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                transactionId,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerWalletCancelHoldUri, body, Token,
                cancellationToken);
        }

        public async Task<Guid> CreateOrUpdateCustomerAsync(Guid organizationId, Guid? id = null,
            string? phone = null, string? cardTrack = null, string? cardNumber = null, string? name = null,
            string? middleName = null, string? surName = null, DateTime? birthday = null, string? email = null,
            Gender? sex = null, GuestConsentStatus? consentStatus = null, bool? shouldReceivePromoActionsInfo = null,
            Guid? referrerId = null, string? userData = null, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                id,
                phone,
                cardTrack,
                cardNumber,
                name,
                middleName,
                surName,
                birthday = birthday?.ToCustomerDateFormat(),
                email,
                sex,
                consentStatus,
                shouldReceivePromoActionsInfo,
                referrerId,
                userData
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerCreateOrUpdateUri, body, Token,
                cancellationToken);

            var result = JsonConvert.DeserializeObject<JToken>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);

            if (!Guid.TryParse(result["id"]?.ToString(), out var customerId))
            {
                throw new Exception(string.Format(DefaultFailGuidConvertionMessage, result["id"]));
            }

            return customerId;
        }

        public async Task DeleteCardForCustomerAsync(Guid customerId, string cardTrack, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                cardTrack,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerCardRemoveUri, body, Token, cancellationToken);
        }

        public async Task<CustomerInfo> GetCustomerInfoByCardNumberAsync(Guid organizationId, string cardNumber,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                cardNumber,
                type = SearchCustomerType.CardNumber.ToSearchCustomerType()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CustomerInfo> GetCustomerInfoByCardTrackAsync(Guid organizationId, string cardTrack,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                cardTrack,
                type = SearchCustomerType.CardTrack.ToSearchCustomerType()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CustomerInfo> GetCustomerInfoByEmailAsync(Guid organizationId, string email,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                email,
                type = SearchCustomerType.Email.ToSearchCustomerType()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CustomerInfo> GetCustomerInfoByIdAsync(Guid organizationId, Guid id,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                id,
                type = SearchCustomerType.Id.ToSearchCustomerType()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CustomerInfo> GetCustomerInfoByPhoneAsync(Guid organizationId, string phone,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                phone,
                type = SearchCustomerType.Phone.ToSearchCustomerType()
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token,
                cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<CustomerInfo> GetCustomerInfoBySpecifiedCriterionAsync(Guid organizationId, SearchCustomerType type,
            Guid? id = null, string? phone = null, string? cardTrack = null, string? cardNumber = null, string? email = null,
            CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                organizationId,
                type = type.ToSearchCustomerType(),
                id,
                phone,
                cardTrack,
                cardNumber,
                email
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerInfoUri, body, Token, cancellationToken);

            return JsonConvert.DeserializeObject<CustomerInfo>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);
        }

        public async Task<Guid> HoldMoneyOfCustomerAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            Guid? transactionId = null, string? comment = null, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                walletId,
                organizationId,
                sum,
                transactionId,
                comment
            });

            var responseBody = await SendHttpPostBearerRequestAsync(DefaultCustomerWalletHoldUri, body, Token,
                cancellationToken);

            var result = JsonConvert.DeserializeObject<JToken>(responseBody)
                ?? throw new Exception(DefaultNullableExceptionMessage);

            if (!Guid.TryParse(result["transactionId"]?.ToString(), out var id))
            {
                throw new Exception(string.Format(DefaultFailGuidConvertionMessage, result["transactionId"]));
            }

            return id;
        }

        public async Task RefillCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                walletId,
                organizationId,
                sum,
                comment
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerWalletTopupUri, body, Token, cancellationToken);
        }

        public async Task WithdrawCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null, CancellationToken? cancellationToken = default)
        {
            string body = JsonConvert.SerializeObject(new
            {
                customerId,
                walletId,
                organizationId,
                sum,
                comment
            });

            await SendHttpPostBearerRequestAsync(DefaultCustomerWalletChargeoffUri, body, Token, cancellationToken);
        }

        #endregion

        #region Messages https://api-ru.iiko.services/#tag/Messages

        public async Task SendEmailAsync(string receiver, string subject, Guid organizationId, string? body = null,
            CancellationToken? cancellationToken = default)
        {
            string requestBody = JsonConvert.SerializeObject(new
            {
                receiver,
                subject,
                organizationId,
                body
            });

            await SendHttpPostBearerRequestAsync(DefaultMessageSendEmailUri, requestBody, Token,
                cancellationToken);
        }

        public async Task SendSmsAsync(string phone, string text, Guid organizationId,
            CancellationToken? cancellationToken = default)
        {
            string requestBody = JsonConvert.SerializeObject(new
            {
                phone,
                text,
                organizationId
            });

            await SendHttpPostBearerRequestAsync(DefaultMessageSendSmsUri, requestBody, Token,
                cancellationToken);
        }

        #endregion

        #endregion
    }
}
