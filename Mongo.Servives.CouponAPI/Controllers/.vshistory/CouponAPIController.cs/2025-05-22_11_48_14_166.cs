using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Servives.CouponAPI.Data;
using Mongo.Servives.CouponAPI.Model;
using Mongo.Servives.CouponAPI.Model.DTO;

namespace Mongo.Servives.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ResponseDto _response; 
        private readonly IMapper _mapper;
        public CouponAPIController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
              
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
            }
            catch (Exception ex) 
            {
               _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon objList = _db.Coupons.First(x => x.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(objList);
             
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return  _response; 

        }
        
        [HttpGet]
        [Route("GetByCode{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                Coupon objList = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                if(objList == null)
                {
                    _response.IsSuccess = false;
                }
                _response.Result = _mapper.Map<CouponDTO>(objList);
             
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return  _response; 

        }
    }
}
