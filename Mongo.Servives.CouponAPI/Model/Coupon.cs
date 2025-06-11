using System.ComponentModel.DataAnnotations;

namespace Mongo.Servives.CouponAPI.Model
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
