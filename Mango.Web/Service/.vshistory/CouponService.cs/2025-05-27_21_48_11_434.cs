using Mango.Web.Service.IService;
using Mongo.Web.Model;
using Mongo.Web.Models;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto> CreateCouponAsync(CouponDTO couponDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateCouponAsync(CouponDTO couponDTO)
        {
            throw new NotImplementedException();
        }
    }
}
