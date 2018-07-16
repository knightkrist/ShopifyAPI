using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Models
{
    public class AddressDTO
    {
        public string address1 { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public virtual string ISOcountry { get; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        
    }
}
