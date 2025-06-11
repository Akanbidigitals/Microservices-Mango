using AutoMapper;
using Mongo.Servives.CouponAPI.Model;
using Mongo.Servives.CouponAPI.Model.DTO;

namespace Mongo.Servives.CouponAPI
{
    public class MappingConfig
    { 
        public  static MapperConfiguration RegisterMaps()
        {
             var mappingConfig = new MapperConfiguration(config =>
             {
                 config.CreateMap<CouponDTO, Coupon>();
                 config.CreateMap<Coupon,CouponDTO>();
             }); 
            return mappingConfig;
        }
    }
}
