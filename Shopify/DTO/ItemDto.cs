using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ItemDto
    {
        public string variant_id { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        public string product_id { get; set; }
    }
}
