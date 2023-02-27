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

        #endregion
    }
}
