using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyDiscountDto
    {
        public IEnumerable<ShopifyRuleDto> price_rules { get; set; }
    }
}
