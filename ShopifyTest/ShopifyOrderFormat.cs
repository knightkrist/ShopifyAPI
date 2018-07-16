using Shopify.DTO;
using Shopify.Tasks;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShopifyTest
{
    public class ConvertOrderToShopifyOrder
    {
        [Fact]
        public void FormatOrder()
        {
            // arrange
            var requestDto = new RequestDto()
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
                     }
                  },
                    total_price = "200"
                },
                billing = new AddressDto()
                {
                    address = "Svej",
                    city = "copnehagen",
                    country = "Denamrk",
                    email = "KMK@Gmail.dk",
                    name = "CKKKK kkkkk",
                    phone = "51244255",
                    zip = "2000"
                },
                discounts = null,
                payment = null,
                shipping = null
            };

            // assign

            var shopifyOrderDto = OrderTask.FormatOrder(requestDto);

            // assert
            Assert.Equal(shopifyOrderDto.email, requestDto.billing.email);
            Assert.Equal(shopifyOrderDto.billing_address.address1, requestDto.billing.address);

        }
    }
}
