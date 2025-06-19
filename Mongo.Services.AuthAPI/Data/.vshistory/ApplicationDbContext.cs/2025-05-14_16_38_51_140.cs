using Microsoft.EntityFrameworkCore;
using Mongo.Servives.CouponAPI.Model;

namespace Mongo.Servives.CouponAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Coupon>Coupons { get; set; } 
    }
}
