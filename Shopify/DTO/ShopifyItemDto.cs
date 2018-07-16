using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyItemDto
    {
            public string variant_id { get; set; }
            public int quantity { get; set; }
            public string price { get; set; }
    }
}
