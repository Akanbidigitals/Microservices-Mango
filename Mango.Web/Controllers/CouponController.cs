using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Mongo.Web.Model;
using Mongo.Web.Models;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task <IActionResult> CouponIndex()
        {
            List<CouponDTO>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponAsync();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
            
        }
    }
}
