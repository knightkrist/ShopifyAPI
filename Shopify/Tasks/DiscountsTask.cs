using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shopify.Controllers;
using Shopify.DTO;
using Shopify.Enums;
using Shopify.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopify.Tasks
{
    public class DiscountsTask
    {
        public static IEnumerable<DiscountDto> GetDiscountCodes(RequestDto requestDto, HttpResponseMessage discountResponse)
        {
            var discountJsonString = discountResponse.Content.ReadAsStringAsync().Result;
            var discountResults = JsonConvert.DeserializeObject<ShopifyDiscountDto>(discountJsonString);

            return CompareDiscounts(requestDto, discountResults);
        }

        private static IEnumerable<DiscountDto> CompareDiscounts(RequestDto requestDto, ShopifyDiscountDto shopifyDiscounts)
        {
            var discountCodes = new List<DiscountDto>();
            foreach (var discount in requestDto.discounts)
            {
                var item = shopifyDiscounts.price_rules.Where(c => string.Equals(c.title, discount.code, StringComparison.InvariantCulture)).FirstOrDefault();
                if(item != null)
                {
                    var discountAmount = Math.Abs(Convert.ToDecimal(item.value, CultureInfo.InvariantCulture));

                    if(string.Equals(item.allocation_method, Allocation_Method.each.ToString(), StringComparison.InvariantCulture)) {

                        foreach (var productId in item.entitled_product_ids)
                        {
                            var _discount = CreateDiscountForProducts(requestDto, item, productId);
                            discountCodes.Add(_discount);
                        }
                    } else
                    {
                        var _discountRange = CreateOrderDiscount(requestDto, item);
                        discountCodes.AddRange(_discountRange);
                    }
                }
            }
            return discountCodes;
        }

        private static IEnumerable<DiscountDto> CreateOrderDiscount(RequestDto requestDto, ShopifyRuleDto pricerule)
        {
            var discountValue = ConvertToDecimal(pricerule.value);

            return requestDto.discounts.Select(c =>
            {
                return new DiscountDto()
                {
                    code = c.code,
                    amount = ConvertToDecimal(c.amount).ToString(),
                    type = pricerule.value_type
                };
            });
        }

        private static DiscountDto CreateDiscountForProducts(RequestDto requestDto, ShopifyRuleDto pricerule, string entitledProduct)
        {
            var orderItem = requestDto.order.items.Where(i => i.product_id == entitledProduct).FirstOrDefault();
            if(orderItem != null)
            {
                decimal productPrice = decimal.Parse(orderItem.price, CultureInfo.InvariantCulture);
                decimal discountValue = ConvertToDecimal(pricerule.value);
                decimal temporaryProductValue;

                if (pricerule.value_type == Discount_Types.percentage.ToString())
                {
                    temporaryProductValue = (productPrice * orderItem.quantity) * (discountValue / 100);
                }
                else
                {
                    temporaryProductValue = (productPrice * orderItem.quantity) - discountValue;
                }

                var calculatedDiscountForProduct = temporaryProductValue.ToString(CultureInfo.InvariantCulture);

                return new DiscountDto()
                {
                    code = pricerule.title,
                    amount = calculatedDiscountForProduct,
                    type = Discount_Types.fixed_amount.ToString()
                };
            }
            return null;
        }

        private static decimal ConvertToDecimal(string value)
        {
            return Math.Abs(Convert.ToDecimal(value, CultureInfo.InvariantCulture));
        }

        private static string ConvertFromDecimal(decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

    }
}
