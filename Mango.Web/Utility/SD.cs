using static System.Net.WebRequestMethods;

namespace Mango.Web.Utility
{
    public class SD
    {
        public static string CouponAPIBase = "http://localhost:7001"; 
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE

        }
    }
}
