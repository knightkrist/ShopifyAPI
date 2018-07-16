using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class OrderDto
    {
        public string total_price { get; set; }
        public string cart_token { get; set; }
        public List<ItemDto> items { get; set; }
    }
}
