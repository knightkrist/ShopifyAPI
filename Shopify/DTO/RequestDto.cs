using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class RequestDto
    {
        public OrderDto order { get; set; }
        public AddressDto billing { get; set; }
        public AddressDto shipping { get; set; }
        public PaymentDto payment { get; set; }
        public List<DiscountDto> discounts { get; set; }
    }
}
