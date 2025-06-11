using Microsoft.EntityFrameworkCore;
using Mongo.Servives.CouponAPI.Model;

namespace Mongo.Servives.CouponAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Coupon>Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Deed data to the coupon database
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20,
            });  
            
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40,
            });  
            
            
        }
    }
}
