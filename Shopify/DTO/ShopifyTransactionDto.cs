using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyTransactionDto
    {
        public string kind { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
    }
}
