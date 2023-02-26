using IikoTransport.Net.Entities.Requests.Orders.Loyalties;
using Newtonsoft.Json;
using SourceDiscount = IikoTransport.Net.Entities.Requests.Orders.Loyalties.Discount;

namespace IikoTransport.Net.Entities.Requests.Delivery.CreateAndUpdate.Loyalties
{
    /// <summary>
    /// Information about a discount/surcharges.
    /// </summary>
    [JsonObject]
    public class Discount : SourceDiscount
    {
        /// <summary>
        /// Discount information for order items.
        /// </summary>
        [JsonProperty(PropertyName = "discountItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public new IEnumerable<IikoCardDiscountItem>? DiscountItems { get; set; }

        /// <summary>
        /// Use for 'RMS' type.
        /// </summary>
        /// <param name="discountTypeId">Discount type.</param>
        /// <param name="sum">Discount/surcharge sum.</param>
        /// <param name="selectivePositions">Order item positions.</param>
        public Discount(Guid discountTypeId, double sum, IEnumerable<Guid>? selectivePositions = null)
        {
            DiscountTypeId = discountTypeId;
            Sum = sum;
            SelectivePositions = selectivePositions;
            Type = DiscountType.RMS;
        }

        /// <summary>
        /// Use for 'iikoCard' type.
        /// </summary>
        /// <param name="programId">Card program ID.</param>
        /// <param name="programName">Card program name.</param>
        /// <param name="discountItems">Discount information for order items.</param>
        public Discount(Guid programId, string programName, IEnumerable<IikoCardDiscountItem> discountItems)
        {
            ProgramId = programId;
            ProgramName = programName;
            DiscountItems = discountItems;
            Type = DiscountType.IikoCard;
        }

        public Discount(DiscountType type, Guid? discountTypeId = null, double? sum = null,
            IEnumerable<Guid>? selectivePositions = null, Guid? programId = null,
            string? programName = null, IEnumerable<IikoCardDiscountItem>? discountItems = null)
        {
            Type = type;
            DiscountTypeId = discountTypeId;
            Sum = sum;
            SelectivePositions = selectivePositions;
            ProgramId = programId;
            ProgramName = programName;
            DiscountItems = discountItems;
        }
    }
}
