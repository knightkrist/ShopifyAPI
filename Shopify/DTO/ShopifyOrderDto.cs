using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyOrderDto
    {
        public IEnumerable<ShopifyItemDto> line_items { get; set; }
        public ShopifyCustomerDto customer { get; set; }
        public ShopifyAddressDto shipping_address { get; set; }
        public ShopifyAddressDto billing_address { get; set; }
        public IEnumerable<ShopifyTransactionDto> transactions { get; set; }
        public string financial_status { get; set; }
        public IEnumerable<DiscountDto> discount_codes { get; set; }
        public bool send_receipt { get; set; }
        public string email { get; set; }
    }
}
