using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shopify.DTO;
using Shopify.Enums;
using Shopify.Helpers;
using Shopify.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;
using System.Globalization;

namespace ShopifyTest
{
    
    public class Unittesting
    {

        private RequestDto requestDto = new RequestDto()
        {
            order = new OrderDto()
            {
                cart_token = "",
                items = new List<ItemDto>()
                  {
                     new ItemDto()
                     {
                          price = "100",
                          product_id = "123",
                          quantity = 2,
                          variant_id = "321"
                     },
                     new ItemDto()
                     {
                          price = "75",
                          product_id = "321",
                          quantity = 3,
                          variant_id = "321"
                     },
                     new ItemDto()
                     {
                          price = "25",
                          product_id = "231",
                          quantity = 5,
                          variant_id = "321"
                     }
                  }
            },
            billing = new AddressDto()
            {
                address = "Svej",
                city = "copnehagen",
                country = "Denamrk",
                email = "kmk@gmail.com",
                name = "Ckk KKKK",
                phone = "51244255",
                zip = "2000"
            },
            discounts = new List<DiscountDto>(){
                   new DiscountDto()
                   {
                       code = "SummerHeat"
                   }
                },
            payment = null,
            shipping = null
        };
        
        private void init()
        {
            requestDto.order.total_price = requestDto.order.items.Sum(c => c.quantity * Convert.ToDecimal(c.price, CultureInfo.InvariantCulture)).ToString();
        }

        // assigning this to a method or function in the project 

        private ShopifyDiscountDto discountResp = new ShopifyDiscountDto()
        {
            price_rules = new List<ShopifyRuleDto>()
                {
                    new ShopifyRuleDto()
                    {
                       allocation_method = "each",
                       value_type = "percentage",
                       title = "SummerHeat",
                       value = "-10.00",
                       entitled_product_ids = new List<string>() { "123", "321" }

                    }
                }

        };

        [Fact]
        public void testingfordiscounts() {

            // arranging in json request to the shopify

            init();

            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(discountResp), UTF8Encoding.UTF8, "application/json");

            var discounts = Shopify.Tasks.DiscountsTask.GetDiscountCodes(requestDto, response).FirstOrDefault();
                      
            Assert.NotNull(discounts);
        }

        [Fact]
        public void testingforMultipleProducts()
        {

            init();

            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(discountResp), UTF8Encoding.UTF8, "application/json");

            var discounts = Shopify.Tasks.DiscountsTask.GetDiscountCodes(requestDto, response);

            Assert.Equal(2, discounts.Count());
        }

        [Fact]
        public void testingforSingleDiscountAmount()
        {

            // arranging in json request to the shopify

            init();


            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(discountResp), UTF8Encoding.UTF8, "application/json");

            var discounts = Shopify.Tasks.DiscountsTask.GetDiscountCodes(requestDto, response);
            
            Assert.Equal(20m.ToString("F",CultureInfo.InvariantCulture), discounts.First().amount);
        }

        [Fact]
        public void testingforMultipleDiscountAmount()
        {

            // arranging in json request to the shopify

            init();


            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(discountResp), UTF8Encoding.UTF8, "application/json");

            var discounts = Shopify.Tasks.DiscountsTask.GetDiscountCodes(requestDto, response);

            //Assert.Equal(20m.ToString("F", CultureInfo.InvariantCulture), discounts.First().amount);

            var amount = new List<string> {"20.00","22.50" };
            
            Assert.Equal(amount, discounts.Select(i=>i.amount));
        }
    }
}
