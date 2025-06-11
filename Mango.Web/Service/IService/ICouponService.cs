using Mongo.Web.Model;
using Mongo.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> DeleteCouponByIdAsync(int id);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDTO);

    }
}
