using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shopify.Helpers;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Shopify.Enums;
using Shopify.Tasks;
using Shopify.DTO;
using Shopify.Mock;

namespace Shopify.Controllers
{
    public class OrderController : Controller
    {

        private IConfiguration _configuration;
        private readonly string _discountEndpoint; 
        private readonly string _endpoint;
        private readonly string _apiKey;
        private readonly string _pass; 
    
        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;

            _discountEndpoint = _configuration.GetValue<string>(Authentication_Types.DiscountEndPoint.ToString());
            _endpoint = _configuration.GetValue<string>(Authentication_Types.EndPoint.ToString());
            _apiKey = _configuration.GetValue<string>(Authentication_Types.APIKEY.ToString());
            _pass = _configuration.GetValue<string>(Authentication_Types.Password.ToString());

        }

        private async Task<HttpResponseMessage> CreateShopifyOrder(ShopifyRequestDto request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await Requests.Post(_endpoint, content, _apiKey, _pass);
            return response;
        }

        private async Task<ShopifyRequestDto> FormatPayload(RequestDto model)
        {
            var order = OrderTask.FormatOrder(model);
            var discountResponse = await Requests.Get(_discountEndpoint, _apiKey, _pass);

            var discountCodes = DiscountsTask.GetDiscountCodes(model, discountResponse);

            order.discount_codes = discountCodes;

            return new ShopifyRequestDto() { order = order };
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RequestDto model)
        {
            var shopifyPayload = await FormatPayload(model);
            var shopifyResponse = CreateShopifyOrder(shopifyPayload);

            if(shopifyResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var swiipeRequest = new RequestDto();
                var swiipeResponse = Mock.Api.Call(swiipeRequest);
                return Ok(APIResponse);
            } else
            {
                return BadRequest(shopifyResponse.Result.ReasonPhrase);
            }
        }
    }
}
