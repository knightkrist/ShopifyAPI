using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.DTO
{
    public class ShopifyAddressDto
    {

        public ShopifyAddressDto(AddressDto dto)
        {
            this.address1 = dto.address;
            this.phone = dto.phone;
            this.city = dto.city;
            this.zip = dto.zip;
            this.country = dto.country;
            this.name = dto.name;
        }

        public string address1 { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public virtual string ISOcountry { get; }
        public string first_name
        {
            get
            {
                return name.Split(" ")[0];
            }
            private set { }
        }
        public string last_name
        {
            get
            {
                return name.Split(" ")[1];
            }
            private set { }
        }
        public string name { get; set; } = "- -";
        
    }
}
