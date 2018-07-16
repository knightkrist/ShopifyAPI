using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class SwiipeResponseDto
    {
        public bool verified_card { get; set; }
        public bool succeded { get; set; }
        public string order_id { get; set; }
    }
}
