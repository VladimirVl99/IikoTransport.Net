﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Common.Orders.Errors
{
    /// <summary>
    /// Error code.
    /// </summary>
    public enum Code
    {
        Common,
        IllegalDeliveryStatus,
        CustomerNameNotSpecified,
        ProductNotFound,
        MarketingSourceNotFound,
        PaymentTypeNotFound,
        ProductSizeNotFound,
        ProductGroupNotFound,
        OrderNotFound,
        ConceptionNotFound,
        DuplicatedOrderId,
        TerminalGroupIdNotDetermined,
        TerminalGroupUnregistered,
        InvalidPhone,
        ModifierDuplicated,
        ProductCanBuyFromCashdesk,
        DeliveryOpinionMarkInvalid,
        WrongDeliveryStatusForOpinion,
        OpinionCommentTooLong,
        SurveyItemNotFound,
        PaymentTypeCanNotBeUsedAsExternal,
        AddressNotFound,
        HomeNotFound,
        IikonetPaymentAdditionalDataCanNotBeParsed,
        IikonetPaymentExternalIdNotFound,
        IikonetPaymentSumLessThanMarketingDiscount,
        DiscountCardNotFound,
        DiscountCardTypeModeForbidden,
        Iikocard5PaymentAdditionalDataCanNotBeParsed,
        Iikocard5PaymentExternalIdNotFound,
        Iikocard5PaymentSumLessThanMarketingDiscount,
        Iikocard5PaymentCanNotCreateCustomData,
        CourierIdDoesNotExist,
        CourierDoesNotOwnOrder,
        WrongDeliveryStatus,
        CanNotAssignCourierToOrder,
        UserNotFoundByExternalPassword,
        UserNotFound,
        Iikocard51PaymentAdditionalDataCanNotBeParsed,
        Iikocard51PaymentCredentialNotFound,
        Iikocard51PaymentSearchScopeNotFound,
        ComboDuplicated,
        InvalidReferenceToCombo,
        InvalidComboItemsAmount,
        InvalidComboItemsGuest,
        InvalidReferenceToGuest,
        GuestDuplicated,
        GuestNameNotSpecified,
        OrderTypeNotFound,
        OrderServiceTypeDoesNotMatchSelfServiceMode,
        DeliveryDateNotSpecified,
        OrderStatusChangedInIikoFront,
        PaymentAdditionalDataTooLong,
        PaymentSumShouldBePositive,
        DiscountSumNotSpecified,
        InvalidDiscountItem,
        RequestProductPriceIsNotEqualToFrontPrice,
        OrderItemsNotExists,
        EntityAlreadyInUse,
        DiscountItemPositionNotFound,
        DiscountItemDuplicatePositions,
        NonUnqiueOrderItemPosition,
        EmptyOrderItemPosition,
        IncorrectOrderType,
        Incorrect,
        TerminalGroupDisabled,
        OrganizationUnregistered,
        OrganizationDisabled,
        TooSmallDeliveryDate,
        IikoFrontTooOldVersion,
        InternalServerError,
        UnknownError
    }
}
