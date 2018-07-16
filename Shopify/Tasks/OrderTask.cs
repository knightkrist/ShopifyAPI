using Shopify.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Tasks
{
    public static class OrderTask
    {
        public static ShopifyOrderDto FormatOrder(RequestDto request)
        {
            var order = new ShopifyOrderDto();
            order.line_items = request.order.items.Select(c =>
            {
                return new ShopifyItemDto()
                {
                    quantity = c.quantity,
                    variant_id = c.variant_id,
                    price = c.price
                };
            });

            var firstname = "";
            var lastname = "";
            var split = request.billing.name.Split(" ");
            firstname = split[0];
            lastname = split[1];

            order.customer = new ShopifyCustomerDto()
            {
                first_name = firstname,
                last_name = lastname,
                email = request.billing.email
            };

            order.send_receipt = true;
            order.email = request.billing.email;

            order.billing_address = new ShopifyAddressDto(request.billing);

            if (request.shipping != null)
            {
                order.shipping_address = new ShopifyAddressDto(request.shipping);
            }
            else
            {
                order.shipping_address = order.billing_address;
            }

            order.transactions = new List<ShopifyTransactionDto>() {
                new ShopifyTransactionDto()
                {
                    amount = Convert.ToDecimal(request.order.total_price, CultureInfo.InvariantCulture),
                    kind = Enums.Transaction_Kind.authorization.ToString(),
                    status = "success"
                }
            };

            order.financial_status = Enums.Financial_Status.authorized.ToString();

            return order;
        }
    }
}
