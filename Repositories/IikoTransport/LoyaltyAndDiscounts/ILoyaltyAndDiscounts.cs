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

namespace IikoTransport.Net.Repositories.IikoTransport.LoyaltyAndDiscounts
{
    /// <summary>
    /// Loyalty systems API.
    /// </summary>
    public interface ILoyaltyAndDiscounts
    {
        #region Discounts and promotions https://api-ru.iiko.services/#tag/Discounts-and-promotions

        /// <summary>
        /// Calculate discounts and other loyalty items for an order.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1calculate/post.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="coupon">Number of applied coupon. Can be null.</param>
        /// <param name="referrerId">Referrer id.</param>
        /// <param name="terminalGroupId">Identifier of a target terminal. Should be used only when auto distribution
        /// is off and no call center operator is available.</param>
        /// <param name="dynamicDiscounts">Applicable manual discounts.</param>
        /// <param name="availablePaymentMarketingCampaignIds">List of identifiers of applied campaigns.
        /// Should be empty if no payment method is used.</param>
        /// <param name="applicableManualConditions">List of manually applied to order conditions.</param>
        /// <returns></returns>
        Task<CheckinInfo> CalculateCheckinAsync(DeliveryOrder order, Guid organizationId, string? coupon = null,
            Guid? referrerId = null, Guid? terminalGroupId = null, IEnumerable<DynamicDiscount>? dynamicDiscounts = null,
            IEnumerable<Guid>? availablePaymentMarketingCampaignIds = null,
            IEnumerable<Guid>? applicableManualConditions = null);

        /// <summary>
        /// Get all organization's manual conditions.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1manual_condition/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<ManualConditionInfos> GetManualConditionsAsync(Guid organizationId);

        /// <summary>
        /// Get programs.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1program/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="WithoutMarketingCampaigns">Determines if marketing campaigns not required.</param>
        /// <returns></returns>
        Task<ProgramInfos> GetProgramsAsync(Guid organizationId, bool? WithoutMarketingCampaigns = null);

        /// <summary>
        /// Get coupon info.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1coupons~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="number">Number. Can be null.</param>
        /// <param name="series">Series. Can be null.</param>
        /// <returns></returns>
        Task<CouponInfos> GetCouponInfoAsync(Guid organizationId, string? number = null, string? series = null);

        /// <summary>
        /// Get a list of coupon series in which there are not deleted and not activated coupons.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1coupons~1series/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<SeriesWithNotActivatedCouponInfos> GetCouponSeriesWithNonActivatedCouponsAsync(Guid organizationId);

        /// <summary>
        /// Get list of non-activated coupons.
        /// Source: https://api-ru.iiko.services/#tag/Discounts-and-promotions/paths/~1api~11~1loyalty~1iiko~1coupons~1by_series/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="series">Series. Can be null.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="page">Page.</param>
        /// <returns></returns>
        Task<NotActivatedCouponInfos> GetNonActivatedCouponsAsync(Guid organizationId, string? series = null,
            int? pageSize = null, int? page = null);

        #endregion

        #region Customer categories https://api-ru.iiko.services/#tag/Customer-categories

        /// <summary>
        /// Get all organization's customer categories.
        /// Source: https://api-ru.iiko.services/#tag/Customer-categories/paths/~1api~11~1loyalty~1iiko~1customer_category/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<CustomerCategoryInfos> GetCustomerCategoriesAsync(Guid organizationId);

        /// <summary>
        /// Add specified category for customer.
        /// Source: https://api-ru.iiko.services/#tag/Customer-categories/paths/~1api~11~1loyalty~1iiko~1customer_category~1add/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="categoryId">Guest category id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task AddCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId);

        /// <summary>
        /// Remove specified category for customer.
        /// Source: https://api-ru.iiko.services/#tag/Customer-categories/paths/~1api~11~1loyalty~1iiko~1customer_category~1remove/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="categoryId">Guest category id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task RemoveCategoryForCustomerAsync(Guid customerId, Guid categoryId, Guid organizationId);

        #endregion

        #region Customers https://api-ru.iiko.services/#tag/Customers

        /// <summary>
        /// Get customer info by specified criterion.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="type">Specified criterion for searching.</param>
        /// <param name="id">Customer id.</param>
        /// <param name="phone">Customer phone number.</param>
        /// <param name="cardTrack">Customer card track.</param>
        /// <param name="cardNumber">Customer card number.</param>
        /// <param name="email">Customer email.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoBySpecifiedCriterionAsync(Guid organizationId, SearchCustomerType type, Guid? id = null,
            string? phone = null, string? cardTrack = null, string? cardNumber = null, string? email = null);

        /// <summary>
        /// Get customer info by phone.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="phone">Customer phone number.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoByPhoneAsync(Guid organizationId, string phone);

        /// <summary>
        /// Get customer info by card track.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cardTrack">Customer card track.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoByCardTrackAsync(Guid organizationId, string cardTrack);

        /// <summary>
        /// Get customer info by card number.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="cardNumber">Customer card number.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoByCardNumberAsync(Guid organizationId, string cardNumber);

        /// <summary>
        /// Get customer info by email.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="email">Customer email.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoByEmailAsync(Guid organizationId, string email);

        /// <summary>
        /// Get customer info by ID.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1info/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="id">Customer id.</param>
        /// <returns></returns>
        Task<CustomerInfo> GetCustomerInfoByIdAsync(Guid organizationId, Guid id);

        /// <summary>
        /// Create or update customer info by id or phone or card track.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1create_or_update/post.
        /// </summary>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="id">Customer id.</param>
        /// <param name="phone">Customer phone. Can be null.</param>
        /// <param name="cardTrack">Card track. Required if cardNumber set. Can be null.</param>
        /// <param name="cardNumber">Card number. Required if cardTrack set. Can be null.</param>
        /// <param name="name">Customer name. Can be null.</param>
        /// <param name="middleName">Customer middle name. Can be null.</param>
        /// <param name="surName">Customer surname. Can be null.</param>
        /// <param name="birthday">Customer birthday.</param>
        /// <param name="email">Customer email. Can be null.</param>
        /// <param name="sex">Customer sex.</param>
        /// <param name="consentStatus">Customer consent status.</param>
        /// <param name="shouldReceivePromoActionsInfo">Customer get promo messages (email, sms). If null - unknown.</param>
        /// <param name="referrerId">Id for referrer guest. Null for old integrations, Guid.Empty - for referrer deletion.
        /// Can be null.</param>
        /// <param name="userData">Customer user data. Can be null.</param>
        /// <returns></returns>
        Task<Guid> CreateOrUpdateCustomerAsync(Guid organizationId, Guid? id = null, string? phone = null,
            string? cardTrack = null, string? cardNumber = null, string? name = null, string? middleName = null,
            string? surName = null, DateTime? birthday = null, string? email = null, Gender? sex = null,
            GuestConsentStatus? consentStatus = null, bool? shouldReceivePromoActionsInfo = null,
            Guid? referrerId = null, string? userData = null);

        /// <summary>
        /// Add new customer for program.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1program~1add/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="programId">Program id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task<Guid> AddCustomerToProgramAsync(Guid customerId, Guid programId, Guid organizationId);

        /// <summary>
        /// Add new card for customer.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1card~1add/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="cardTrack">Card track.</param>
        /// <param name="cardNumber">Card number.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task AddCardForCustomerAsync(Guid customerId, string cardTrack, string cardNumber, Guid organizationId);

        /// <summary>
        /// Delete existing card for customer.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1card~1remove/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="cardTrack">Card track.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task DeleteCardForCustomerAsync(Guid customerId, string cardTrack, Guid organizationId);

        /// <summary>
        /// Hold customer's money in loyalty program. Payment will be process on POS during processing of an order.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1wallet~1hold/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="walletId">Wallet id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="sum">Sum.</param>
        /// <param name="transactionId">Predefined transaction id. Random if empty.</param>
        /// <param name="comment">Additional information about holding. Can be null.</param>
        /// <returns></returns>
        Task<Guid> HoldMoneyOfCustomerAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            Guid? transactionId = null, string? comment = null);

        /// <summary>
        /// Cancel holding transaction that created earlier.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1wallet~1cancel_hold/post.
        /// </summary>
        /// <param name="transactionId">Transaction id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task CancelHoldMoneyOfCustomerAsync(Guid transactionId, Guid organizationId);

        /// <summary>
        /// Refill customer balance.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1wallet~1topup/post.
        /// </summary>
        /// <param name="customerId">Customer id.</param>
        /// <param name="walletId">Wallet id.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <param name="sum">Sum of balance change. Must be possible.</param>
        /// <param name="comment">Comment. Can be null.</param>
        /// <returns></returns>
        Task RefillCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null);

        /// <summary>
        /// Withdraw customer balance.
        /// Source: https://api-ru.iiko.services/#tag/Customers/paths/~1api~11~1loyalty~1iiko~1customer~1wallet~1chargeoff/post.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="walletId"></param>
        /// <param name="organizationId"></param>
        /// <param name="sum"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task WithdrawCustomerBalanceAsync(Guid customerId, Guid walletId, Guid organizationId, double sum,
            string? comment = null);

        #endregion

        #region Messages https://api-ru.iiko.services/#tag/Messages

        /// <summary>
        /// Send sms message to specified phone number. Sending proceed according iikoCard organization's settings.
        /// Source: https://api-ru.iiko.services/#tag/Messages/paths/~1api~11~1loyalty~1iiko~1message~1send_sms/post.
        /// </summary>
        /// <param name="phone">Customer's phone number. Can be null.</param>
        /// <param name="text">Message text.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task SendSmsAsync(string phone, string text, Guid organizationId);

        /// <summary>
        /// Send email message to specified email address. Sending proceed according iikoCard organization's settings.
        /// Source: https://api-ru.iiko.services/#tag/Messages/paths/~1api~11~1loyalty~1iiko~1message~1send_email/post.
        /// </summary>
        /// <param name="receiver">Email address.</param>
        /// <param name="subject">Message subject.</param>
        /// <param name="body">Message body.</param>
        /// <param name="organizationId">Organization id.
        /// Can be obtained by https://api-ru.iiko.services/api/1/organizations operation.</param>
        /// <returns></returns>
        Task SendEmailAsync(string receiver, string subject, Guid organizationId, string? body = null);

        #endregion
    }
}
