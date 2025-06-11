using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mongo.Web.Model;
using Newtonsoft.Json;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {     
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Content-Type", "application/json");

            //Token 
            message.RequestUri = new Uri(requestDto.Url);
            if(requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert)
            }

        }
    }
}
