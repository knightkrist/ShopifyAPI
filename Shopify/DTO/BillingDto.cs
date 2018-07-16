using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class AddressDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string country { get; set; } = "Denmark";
        public string zip { get; set; }
    }
}
