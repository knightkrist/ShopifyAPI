using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class DiscountDto
    {
        public string code { get; set; }
        public string amount { get; set; }
        public string type { get; set; }
    }
}
